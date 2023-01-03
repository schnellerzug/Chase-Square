using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private PlayerData data;

    private IGetVectorInput _input;
    private ITranslateVectorInput _motion;
    private IPutRotation _rotation;
    private IAmADeathCondition[] _conditions;

    private GameObject playerModel;
    private void OnEnable()
    {
        GameManager.instance.OnSpawn += Spawn;
    }

    private void OnDisable()
    {
        GameManager.instance.OnSpawn -= Spawn;
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
        Movement();
        DeathConditions();
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

    private void DeathConditions()
    {
        foreach (var condition in _conditions)
        {
            if (condition.Condition())
            {
                GameManager.instance.GameOver();
                playerModel.SetActive(false);
                return;
            }
        }
    }

    private void Spawn()
    {
        if(playerModel == null) 
        { 
            playerModel = Instantiate(data.playerModel,this.transform);
        }
        playerModel.SetActive(true);
    }

 
}
