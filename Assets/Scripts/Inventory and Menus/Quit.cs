using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : Button
{
    InfoToSave infoThingy;

    void Start()
    {
        infoThingy = FindObjectOfType<InfoToSave>();
    }

    public override void Do()
    {
        Screen.fullScreen = true;

        infoThingy.SetPrefs();

        PlayerPrefs.Save();
        Application.Quit();
    }
}