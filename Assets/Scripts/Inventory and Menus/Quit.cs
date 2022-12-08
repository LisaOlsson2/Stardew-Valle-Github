using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : Button
{
    InfoToSave book;

    void Start()
    {
        book = FindObjectOfType<InfoToSave>();
    }

    public override void Do()
    {
        Screen.fullScreen = true;
        PlayerPrefs.SetFloat("musicVolume", book.musicVolume);
        PlayerPrefs.SetFloat("soundVolume", book.soundVolume);
        PlayerPrefs.Save();
        Application.Quit();
    }
}