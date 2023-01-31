using UnityEngine;

internal interface ISetCirclingChilds
{
    CirlingObjectChild[] CirclingChilds(Transform[] objects, CirclingData actuelData);
}