
using System.Collections.Generic;
using UnityEngine;

public partial class CirlingObject : MonoBehaviour
{
    [SerializeField] private List<CirlingObjectChild> childs = new List<CirlingObjectChild>();
    [SerializeField] private CirclingData[] datas;

    public CirclingData actuelData;

    // Start is called before the first frame update
    void OnEnable()
    {
        GameManager.instance.OnPhaseChange += ChangeData;
        var newChilds = actuelData.minMaxChilds.x + (actuelData.minMaxChilds.y - actuelData.minMaxChilds.x) * Random.value;
        childs.Clear();
        GetChildsTo((int)newChilds);
        RandomValue();
    }

    private void OnDisable()
    {
        GameManager.instance.OnPhaseChange -= ChangeData;       
    }

    void RandomValue()
    {
        var currentChilds = transform.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < (currentChilds.Length - 1); i++)
        {
            var ob = new CirlingObjectChild();

            ob.obstacle = currentChilds[i + 1].gameObject;

            ob.distance = actuelData.minMaxDis.x + (actuelData.minMaxDis.y - actuelData.minMaxDis.x) * Random.value;
            var sp = actuelData.minMaxSpeed.x + (actuelData.minMaxSpeed.y - actuelData.minMaxSpeed.x) * Random.value;
            ob.speed = i % 2 == 0 ? sp * -1 : sp;
            var size = actuelData.minMaxSize.x + (actuelData.minMaxSize.y - actuelData.minMaxSize.x) * Random.value;
            ob.obstacle.transform.localScale = new Vector2(size, size);
            ob.obstacle.SetActive(true);
            childs.Add(ob);
        }


    }

    void GetChildsTo(int newChilds)
    {
        var currentChilds = transform.GetComponentsInChildren<Transform>(true);
        if (currentChilds.Length - 1 > newChilds)
        {
            for (int i = (int)newChilds; i < currentChilds.Length - 1; i++)
            {
                Destroy(currentChilds[i].gameObject);

            }
        }
        else if (currentChilds.Length - 1 < newChilds)
        {
            for (int i = currentChilds.Length - 1; i < (int)newChilds; i++)
            {
                Instantiate(actuelData.circleObject, transform);

            }
        }
    }
    void MoveChilds()
    {
        foreach (var o in childs)
        {
            if (o != null)
                o.obstacle.transform.position = new Vector3(Mathf.Sin(Time.time * o.speed + o.offset) * o.distance, Mathf.Cos(Time.time * o.speed + o.offset) * o.distance, 0) + transform.position;
        }
    }

    private void ChangeData(int phase)
    {
        if (phase >= datas.Length)
            phase = datas.Length - 1;

        actuelData = datas[phase];
    }

    // Update is called once per frame
    void Update()
    {
        MoveChilds();
    }
}
