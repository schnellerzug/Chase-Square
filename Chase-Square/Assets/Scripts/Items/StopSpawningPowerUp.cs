

using UnityEngine;

[CreateAssetMenu(menuName = "Items/PowerUp/StopSpawning")]
public class StopSpawningPowerUp : PowerUp
{
    [Header("StopSpawning")]
    public int destroyAmount;
    public float StopTime;

    public override void Use()
    {
        GameManager.instance.DestroyAndStop(destroyAmount,StopTime);
    }
}
