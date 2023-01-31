
using System.Collections;
using System.Linq;
using System.Threading;
using UnityEngine;


public class ObjectsSpawner<T> : MonoBehaviour where T : MonoBehaviour 
{
    [SerializeField] private SpawnerData[] datas;

    public SpawnerData actuelData;
    public Camera mainCamera;

    private T[] childs;
    private IGetAvailableObjectFromList<T> _getAvailable;
    private IChooseObjectOfList<Prefab> _randomPrefab;
    private ISetObjectValues<T> _setObjectValues;
    private IAmTimer _timer;

    protected virtual void OnEnable()
    {
        _setObjectValues = GetComponent<ISetObjectValues<T>>();
        _getAvailable = GetComponent<IGetAvailableObjectFromList<T>>();
        _randomPrefab = GetComponent<IChooseObjectOfList<Prefab>>();
        _timer = GetComponent<IAmTimer>();
        
    }

    protected virtual void OnDisable()
    {

    }
    protected void Starting()
    {
        _timer.OnTimerEnd -= Spawn;
        _timer.OnTimerEnd += Spawn;
        childs = transform.GetComponentsInChildren<T>(true);
        for (int i = 0; i < actuelData.startAmount; i++)
        {
            SpawnClutter(false);
        }
        _timer.StartTimer(actuelData.duration);
    }

    protected void ChangeData(int phase)
    {
        if(phase >= datas.Length)
            phase = datas.Length - 1;

        actuelData = datas[phase];
        actuelData.maxSpriteHeight = actuelData.sprites.Max(x => x.bounds.size.y);
    }

    protected void StopAndDestroy(int destroyAmount, float stopTime)
    {
        if( destroyAmount < 0 ) 
        {
            destroyAmount= 0;
        }
        else if( destroyAmount > childs.Length)
        {
            destroyAmount = childs.Length;
        }
        for (int i = 0; i < destroyAmount ; i++)
        {
            childs[i].gameObject.SetActive(false);
            print(childs[i].gameObject);
        }
        _timer.StartTimer(stopTime);
    }
    protected void StopAndDestroy()
    {
        _timer.StopTimer();
        foreach (var obstacle in childs)
        {
            obstacle.gameObject.SetActive(false);
        }
    }

    protected void Spawn()
    {

        SpawnClutter(true);
        _timer.StartTimer(actuelData.duration);
    }

    protected virtual void SpawnClutter(bool outsidecamera)
    {
        var clutter = _getAvailable.GetAvailableObject(childs, _randomPrefab.ChooseObject(actuelData.prefabs).prefab.GetComponent<T>()).gameObject;
        _setObjectValues?.SetObjectValues(clutter,outsidecamera);
        clutter.SetActive(true);
        childs = transform.GetComponentsInChildren<T>(true);
    }

}

