using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePowerUp : MonoBehaviour
{
    public PowerUp powerUp;

    public void Use()
    {
       StartCoroutine( powerUp.UsePowerUp());
    }


}
