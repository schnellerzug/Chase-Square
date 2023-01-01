using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData data;
    private IGetVectorInput _input;
    private ITranslateVectorInput _motion;

    private void Start()
    {
        _motion = GetComponent<ITranslateVectorInput>();
        _input = GetComponent<IGetVectorInput>();
        GetComponentInChildren<SpriteRenderer>().sprite = data.skin;
    }
    private void Update()
    {
        Movement();
    }

    private Vector3 input;
    private void Movement()
    {
        
        if(_input != null) input = _input.GetInput();
        if (input == Vector3.zero)
            return;

        if(_motion != null) input = _motion.InputTranslate(input);
        transform.Translate(input * data.speed * Time.deltaTime);
    }
}
