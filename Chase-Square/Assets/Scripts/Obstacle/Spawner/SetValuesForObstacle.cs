
using UnityEngine;


public class SetValuesForObstacle : MonoBehaviour, ISetObjectValues<Obstacle>
{
    private ObstacleSpawner obstacleSpawner;
    private Camera mainCamera;
    
    private void OnEnable()
    {
        obstacleSpawner = GetComponent<ObstacleSpawner>();
        mainCamera = obstacleSpawner.mainCamera;
    }
    public void SetObjectValues(GameObject clutter, bool outsideCamera)
    {
        if (obstacleSpawner == null)
            return;
        var actuelData = obstacleSpawner.actuelData;

        //Sprite
        var cluttersprite = actuelData.sprites[(int)(Random.value * actuelData.sprites.Length)];
        clutter.GetComponent<SpriteRenderer>().sprite = cluttersprite;
        //Position
        var xposition = -3f;
        var horizontalCameraSize = mainCamera.orthographicSize * 2 * mainCamera.aspect;
        xposition += outsideCamera ?
            -horizontalCameraSize / 2
            : horizontalCameraSize * Random.value - horizontalCameraSize / 2;
        var yposition = actuelData.minMaxHeight.x + (actuelData.minMaxHeight.y - actuelData.minMaxHeight.x) * Random.value;
        var localposition = new Vector3(xposition, yposition, actuelData.maxSpriteHeight / cluttersprite.bounds.size.y);
        clutter.transform.position = localposition + (Vector3)(Vector2)mainCamera.transform.position;
        //Size
        var size = actuelData.minMaxSize.x + (actuelData.minMaxSize.y - actuelData.minMaxSize.x) * Random.value;
        size *= actuelData.maxSpriteHeight / cluttersprite.bounds.size.y;
        clutter.transform.localScale = new Vector3(size, size, 0);
        //print(clutter.transform.position);
        //Speed
        var speed = actuelData.minMaxSpeed.x + (actuelData.minMaxSpeed.y - actuelData.minMaxSpeed.x) * Random.value;
        clutter.GetComponent<Obstacle>().speed = speed;


    }
}
