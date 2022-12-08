using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : Button
{
    public override void Do()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
