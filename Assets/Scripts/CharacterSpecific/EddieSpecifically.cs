using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EddieSpecifically : Characters
{
    // will in most cases update number 6
    public override void Start()
    {
        base.Start();
        allLines = new string[][] { new string[] { "no", "" }, new string[] { "", "ge mig nåt bra att säga", "jag skulle verkligen uppskatta det", "","tack" } };
    }
}