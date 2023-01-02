using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTransformTranslate : MonoBehaviour, ITranslateVectorInput
{
    public void TranslateInput(Vector3 input, float speed)
    {
        transform.Translate(input * speed * Time.deltaTime);
    }
}
