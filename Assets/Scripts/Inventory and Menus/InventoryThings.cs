using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryThings : BaseThings
{
    [SerializeField]
    GameObject thingy;

    public void Exit()
    {
        thingy.SetActive(true);
        gameObject.SetActive(false);
    }
}
