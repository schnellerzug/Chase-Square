using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Item
{
    [Header("BoosterData")]
    public int amount;
    [SerializeField] private float cooldown;
    [HideInInspector] public float actuelCooldown;


    public override void Buy()
    {
        amount += 1;
    }

    public virtual IEnumerator UsePowerUp()
    {
        if (actuelCooldown > 0)
            yield break;

        //if (actuelDuration > 0)
        //    yield break;

        //actuelDuration = duration;
        Use();
        //while (actuelDuration > 0)
        //{
        //    actuelDuration -= Time.deltaTime;
        //    yield return null;
        //}
        StopUse();
        actuelCooldown = cooldown;
        while (actuelCooldown > 0)
        {
            actuelCooldown -= Time.deltaTime;
            yield return null;
        }
    }
}
