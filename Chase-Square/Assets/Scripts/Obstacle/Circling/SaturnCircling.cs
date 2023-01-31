using UnityEngine;

public class SaturnCircling : MonoBehaviour, ICircleObject
{
    public void Circle(CirlingObjectChild[] objects)
    {

        for (int i = 0; i < objects.Length; i++)
        {
            var o = objects[i];
            var speed = i % 2 == 0 ? o.speed * -1 : o.speed;
            if (o != null)
                o.obstacle.transform.position = new Vector3(Mathf.Sin(Time.time * speed + o.offset) * o.distance, Mathf.Cos(Time.time * speed + o.offset) * o.distance, 0) + transform.position;

        }
    }
}
