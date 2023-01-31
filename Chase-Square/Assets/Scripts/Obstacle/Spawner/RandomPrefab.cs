
using UnityEngine;

public class RandomPrefab : MonoBehaviour, IChooseObjectOfList<Prefab>
{
    public Prefab ChooseObject(Prefab[] objects)
    {
        var a = 0f;
        var e = Random.value;

        for (int i = 0; i < objects.Length; i++)
        {

            if (e <= (objects[i].probability + a))
            {

                return objects[i];
            }
            else
            {
                a += objects[i].probability;
            }

        }
        return null;
    }
}
