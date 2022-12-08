using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer : Button
{

    [SerializeField]
    GameObject activate;
    [SerializeField]
    GameObject deactivate;

    public override void Do()
    {
        activate.SetActive(true);
        deactivate.SetActive(false);
    }
}
