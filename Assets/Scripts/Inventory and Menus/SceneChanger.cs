using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : Button
{
    public override void Do()
    {
        SceneManager.LoadScene(gameObject.name);
    }
}
