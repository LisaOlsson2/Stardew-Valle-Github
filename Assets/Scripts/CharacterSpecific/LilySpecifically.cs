using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LilySpecifically : Characters
{

    public override void Start()
    {
        base.Start();

        progressTriggers[1, 2] = lineChangerString;

        allLines = new string[][] { new string[] { "", "ok, cool", "i'm doing pretty good", "", "heh", "that's awesome" }, new string[] {"", "woah", "awesome" } };

    }

    public override int GetRow()
    {
        if (infoThingy.progress[4] - 48 == 2)
        {
            return 1;
        }
        else
        {
            return base.GetRow();
        }
    }
}