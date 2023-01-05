
using System.Collections;
using System.Linq;
using UnityEngine;


public class ObjectsSpawner<T> : MonoBehaviour where T : MonoBehaviour 
{
    [SerializeField] private SpawnerData[] datas;

    public SpawnerData actuelData;
    public Camera mainCamera;

    private T[] childs;
    private IGetAvailableObject<T> getAvailable;
    private IChooseObjectOfList<Prefab> randomPrefab;
    private ISetObjectValues<T> setObjectValues;

    private void OnEnable()
    {
        setObjectValues = GetComponent<ISetObjectValues<T>>();
        getAvailable = GetComponent<IGetAvailableObject<T>>();
        randomPrefab = GetComponent<IChooseObjectOfList<Prefab>>();
        GameManager.instance.OnSpawn += Starting;
        GameManager.instance.OnGameOver += StopAndDestroy;
        GameManager.instance.OnPhaseChange += ChangeData;
    }

    private void OnDisable()
    {
        GameManager.instance.OnSpawn -= Starting;
        GameManager.instance.OnGameOver -= StopAndDestroy;
        GameManager.instance.OnPhaseChange -= ChangeData;
    }
    private void Starting()
    {
        childs = transform.GetComponentsInChildren<T>(true);
        StartCoroutine(Spawning());
        for (int i = 0; i < actuelData.startAmount; i++)
        {
            SpawnClutter(true);
        }
    }

    private void ChangeData(int phase)
    {
        if(phase >= datas.Length)
            phase = datas.Length - 1;

        actuelData = datas[phase];
        actuelData.maxSpriteHeight = actuelData.sprites.Max(x => x.bounds.size.y);
    }

    private void StopAndDestroy()
    {
        StopAllCoroutines();
        foreach (var obstacle in childs)
        {
            obstacle.gameObject.SetActive(false);
        }
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            SpawnClutter(true);
            yield return new WaitForSeconds(actuelData.duration);
        }
    }

    protected virtual void SpawnClutter(bool outsidecamera)
    {

        var clutter = getAvailable.GetAvailableObject(childs, randomPrefab.ChooseObject(actuelData.prefabs).prefab.GetComponent<T>()).gameObject;
        setObjectValues.SetObjectValues(clutter,outsidecamera);
        clutter.SetActive(true);
        childs = transform.GetComponentsInChildren<T>(true);
    }

}

