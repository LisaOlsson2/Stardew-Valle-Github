using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseThings : MonoBehaviour
{
    public static InfoToSave infoThingy;
    
    public string[,] progressTriggers = new string[9, 10];
    // column 0 is empty to make things easier to keep track of

    /*
    void SetColumns()
    {
        progressTriggers = new string[infoThingy.progress.Length, 10];
    }
    */

    public void UpdateProgress(int place)
    {
        infoThingy.progress[place] = System.Convert.ToChar(infoThingy.progress[place] + 1); // add one to the progress
        BaseThings[] arvObjekt = FindObjectsOfType<BaseThings>();

        foreach (BaseThings objekt in arvObjekt)
        {
            if (objekt.progressTriggers[place, infoThingy.progress[place] - 48] != "")
            {
                objekt.Change(objekt.progressTriggers[place, infoThingy.progress[place] - 48]);
            }
        }
    }
    public virtual void Change(string command)
    {

    }
}