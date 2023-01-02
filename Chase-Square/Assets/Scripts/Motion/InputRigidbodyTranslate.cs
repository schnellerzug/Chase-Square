using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRigidbodyTranslate : MonoBehaviour , ITranslateVectorInput
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void TranslateInput(Vector3 input, float speed)
    {
        if ((input.x > 0 && rb.velocity.x < 0) || (input.x < 0 && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }
        if ((input.y > 0 && rb.velocity.y < 0) || (input.y < 0 && rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);

        }

        rb.AddForce((Vector2)input * speed * Time.fixedDeltaTime);
    }
}
