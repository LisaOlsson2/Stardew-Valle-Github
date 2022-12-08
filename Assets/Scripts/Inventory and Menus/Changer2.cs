using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer2 : Button
{
    [SerializeField]
    GameObject theThing;

    public override void Do()
    {
        theThing.SetActive(!theThing.activeSelf);
    }

}
