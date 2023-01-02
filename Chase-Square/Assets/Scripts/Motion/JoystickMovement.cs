
using UnityEngine;

public class JoystickMovement : MonoBehaviour , IGetVectorInput
{
    [SerializeField] private Joystick js;
    public Vector3 GetInput()
    {
        if (js == null)
            return Vector3.zero;

        var x = js.Horizontal;
        var y = js.Vertical;
        return new Vector3(x, y, 0);
    }
}
