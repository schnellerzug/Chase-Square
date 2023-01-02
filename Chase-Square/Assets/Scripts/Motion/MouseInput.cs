using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour, IGetVectorInput
{
    public Vector3 GetInput()
    {
        var mouseX = Input.GetAxisRaw("Mouse X");
        var mouseY = Input.GetAxisRaw("Mouse Y");
        return new Vector3(mouseX, mouseY);
        
    }
}
