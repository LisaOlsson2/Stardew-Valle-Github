using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LilySpecifically : Characters
{
    // will in most cases update number 3

    public override void Start()
    {
        base.Start();
        allLines = new string[][] { new string[] { "", "ok, cool", "i'm doing pretty good", "", "heh", "that's awesome" }};
    }
}