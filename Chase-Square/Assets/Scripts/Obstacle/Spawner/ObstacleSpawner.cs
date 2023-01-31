

using System;

public class ObstacleSpawner : ObjectsSpawner<Obstacle> 
{
    protected override void OnEnable()
    {
        base.OnEnable();
        GameManager.instance.OnSpawn += Starting;
        GameManager.instance.DestroyStopSpawn += StopAndDestroy;
        GameManager.instance.DestroyStopSpawnComplete += StopAndDestroy;
        GameManager.instance.OnPhaseChange += ChangeData;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.instance.OnSpawn -= Starting;
        GameManager.instance.DestroyStopSpawn -= StopAndDestroy;
        GameManager.instance.DestroyStopSpawnComplete -= StopAndDestroy;
        GameManager.instance.OnPhaseChange -= ChangeData;
    }
}
