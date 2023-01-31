using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingObstacle : Obstacle
{
    [SerializeField]private CirclingData[] datas;
    private CirclingData actuelData;

    private CirlingObjectChild[] children;

    ICreateChildren _getAvailable;
    ICircleObject _circleObjects;
    ISetCirclingChilds _setValue;

    private void Awake()
    {
        _getAvailable= GetComponent<ICreateChildren>();
        _circleObjects= GetComponent<ICircleObject>();
        _setValue = GetComponent<ISetCirclingChilds>();
    }
    private void OnEnable()
    {
        if (!(GameManager.instance.phase < datas.Length))
            actuelData = datas[GameManager.instance.phase];
        else actuelData = datas[datas.Length-1];
        
        children = _setValue.CirclingChilds(_getAvailable.Create(transform,(int)(actuelData.minMaxChilds.x + (actuelData.minMaxChilds.y - actuelData.minMaxChilds.x) * Random.value),actuelData.circleObject), actuelData);
    }

    protected override void Update()
    {
        base.Update();
        _circleObjects.Circle(children);
    }

}
