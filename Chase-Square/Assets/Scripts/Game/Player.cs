using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private PlayerData data;
    [SerializeField]private Vector2 spawnpoint;
    private bool isAlive;

    private IGetVectorInput _input;
    private ITranslateVectorInput _motion;
    private IPutRotation _rotation;
    private IAmADeathCondition[] _conditions;

    private GameObject playerModel;
    private void OnEnable()
    {
        GameManager.instance.OnSpawn += Spawn;
        GameManager.instance.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        GameManager.instance.OnSpawn -= Spawn;
        GameManager.instance.OnGameOver -= GameOver;
    }

    private void Awake()
    {
        _motion = GetComponent<ITranslateVectorInput>();
        _input = GetComponent<IGetVectorInput>();
        _rotation= GetComponent<IPutRotation>();
        _conditions = GetComponents<IAmADeathCondition>();
    }
    private void Update()
    {
        if (!isAlive)
        {
            return;
        }
        Movement();
        
    }

    private Vector3 input;
    private void Movement()
    {
        
        if(_input != null) input = _input.GetInput();

        if (input == Vector3.zero)
            return;

        if(_rotation != null) _rotation.Rotate(input, data.rotationSpeed);
        if(_motion != null)  _motion.TranslateInput(input,data.speed);
    }

    private void Death()
    {
        if(isAlive)
        {
            GameManager.instance.GameOver();   
        }
              
    }

    private void GameOver()
    {
        isAlive = false;
        playerModel.SetActive(false);
        foreach (var condition in _conditions)
        {
            condition.OnCondition -= Death;
        }
    }
    private void Spawn()
    {
        if(playerModel == null) 
        { 
            playerModel = Instantiate(data.playerModel,this.transform);
        }
        transform.position = spawnpoint;
        playerModel.SetActive(true);
        isAlive = true;
        foreach (var condition in _conditions)
        {
            condition.OnCondition += Death;
        }
    }

 
}
