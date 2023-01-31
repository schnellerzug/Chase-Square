using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/PowerUp/SpeedChanger")]
public class SpeedChangerPowerUp : PowerUp
{
    [Header("SpeedChanger")]
    [SerializeField] private float speedMulti;
    [SerializeField] private float speedAdd;

    private float speedChange;
    public override void Use()
    {
        speedChange = GameManager.instance.speed * speedMulti - GameManager.instance.speed;
        speedChange += speedAdd;
        GameManager.instance.speed += speedChange;
    }

    public override void StopUse()
    {
        GameManager.instance.speed -= speedChange;
    }
}
