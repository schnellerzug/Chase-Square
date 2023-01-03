using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private SpawnerData[] datas;

    public SpawnerData actuelData;

    [SerializeField] private Camera mainCamera;

    private Obstacle[] childs;

    
    private float maxSpriteHeight;

    private void OnEnable()
    {
        
        
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
        childs = transform.GetComponentsInChildren<Obstacle>(true);
        StartCoroutine(Spawning());
        for (int i = 0; i < actuelData.startAmount; i++)
        {
            SpawnClutter(true);
        }
    }

    private void ChangeData(int phase)
    {
        actuelData = datas[phase];
        maxSpriteHeight = actuelData.sprites.Max(x => x.bounds.size.y);
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
            yield return new WaitForSeconds(actuelData.duration / GameManager.instance.speed);
        }
    }
       
    

    void SpawnClutter(bool outsidecamera)
    {

        var clutter = GetAvailableClutter();
        var cluttersprite = actuelData.sprites[(int)(Random.value * actuelData.sprites.Length)];
        var xposition = -3f;
        var horizontalCameraSize = mainCamera.orthographicSize * 2 * mainCamera.aspect;
        xposition += outsidecamera ?
            -horizontalCameraSize / 2
            : horizontalCameraSize * Random.value - horizontalCameraSize / 2;
        var yposition = actuelData.minMaxHeight.x + (actuelData.minMaxHeight.y - actuelData.minMaxHeight.x) * Random.value;
        var size = actuelData.minMaxSize.x + (actuelData.minMaxSize.y - actuelData.minMaxSize.x) * Random.value;
        size *= maxSpriteHeight / cluttersprite.bounds.size.y;
        var localposition = new Vector3(xposition, yposition, maxSpriteHeight / cluttersprite.bounds.size.y);
        var speed = actuelData.minMaxSpeed.x + (actuelData.minMaxSpeed.y - actuelData.minMaxSpeed.x) * Random.value;
        clutter.transform.localScale = new Vector3(size, size, 0);
        clutter.transform.position = localposition + (Vector3)(Vector2)mainCamera.transform.position;
        clutter.GetComponent<Obstacle>().speed = speed;
        clutter.GetComponent<SpriteRenderer>().sprite = cluttersprite;
        clutter.SetActive(true);
        
    }

    private GameObject GetAvailableClutter()
    {
        var pf = RandomPrefab();

        foreach (Obstacle g in childs)
        {
            if (g == null)
                break;
            if (!g.gameObject.activeInHierarchy)
            {
                if (g != this)
                {
                    if (g.type == pf.type)
                    {
                        g.gameObject.SetActive(true);
                        return g.gameObject;
                    }
                }

            }
        }

        var ng = Instantiate(pf.gameObject, transform);
        childs = transform.GetComponentsInChildren<Obstacle>(true);
        return ng;

    }


    private Obstacle RandomPrefab()
    {
        var a = 0f;
        var e = Random.value;

        for (int i = 0; i < actuelData.prefabs.Length; i++)
        {

            if (e <= (actuelData.prefabs[i].probability + a))
            {

                return actuelData.prefabs[i].prefab.GetComponent<Obstacle>();
            }
            else
            {
                a += actuelData.prefabs[i].probability;
            }

        }
        return null;
    }
}

