using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseThings : MonoBehaviour
{
    public static InfoToSave infoThingy;
    
    public readonly string[,] progressTriggers = new string[10, 9]; // [10, infothingy.progressLength]

    /* progressTriggers
    |   |   |   |   |   |   |   |   |   |   |   Leo
    |   |1,7|   |   |   |   |   |   |   |   |   Alex
    |   |   |   |   |   |   |   |   |   |   |   Eddie
    |   |   |   |   |   |   |   |   |   |   |   Frank
    |   |   |   |   |   |   |   |   |   |   |   Lisa
    |   |   |   |   |   |   |   |   |   |   |   Lily
    |   |   |   |   |   |   |   |   |   |   |   Noah
    |   |   |   |   |   |   |   |   |   |   |   Valle
    | X |   |   |   |   |   |   |   |   |   |   Player
    */

    public void UpdateProgress(int place)
    {
        if (place == 0 || infoThingy.progress[place] - 48 >= 9)
        {
            print("don't do that");
            return;
        }

        infoThingy.progress[place]++;

        BaseThings[] arvObjekt = FindObjectsOfType<BaseThings>();

        foreach (BaseThings objekt in arvObjekt)
        {
            if (objekt.progressTriggers[infoThingy.progress[place] - 48, place] != "")
            {
                objekt.Change(objekt.progressTriggers[infoThingy.progress[place] - 48, place]);
            }
        }
    }
    public virtual void Change(string command)
    {

    }
}