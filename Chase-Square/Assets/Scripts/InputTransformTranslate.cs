using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTransformTranslate : MonoBehaviour, ITranslateVectorInput
{
    public Vector3 InputTranslate(Vector3 input)
    {
        return input;
    }
}
