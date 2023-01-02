using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalVerticalInput : MonoBehaviour , IGetVectorInput
{
  public Vector3 GetInput()
  {
        var inputX = Input.GetAxisRaw("Horizontal");
        var inputY = Input.GetAxisRaw("Vertical");
        return new Vector3(inputX,inputY, 0);
    }
}
