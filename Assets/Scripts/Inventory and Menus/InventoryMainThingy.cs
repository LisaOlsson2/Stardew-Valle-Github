using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMainThingy : InventoryThings
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GetComponent<Animator>().enabled = !GetComponent<Animator>().enabled;
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Exit();
        }

    }
}
