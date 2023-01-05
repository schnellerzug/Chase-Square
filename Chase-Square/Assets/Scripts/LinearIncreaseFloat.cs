
using UnityEngine;

public class LinearIncreaseFloat : MonoBehaviour , IChangeFloat
{
    public float speed = 1;
    public float ChangeFloat(float value)
    {
        return value + speed * Time.deltaTime;
    }
}
