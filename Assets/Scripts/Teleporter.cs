using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : BaseThings
{
    public Scene scene;
    Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == infoThingy.player)
        {
            if (gameObject.name == scene.name)
            {
                WakeUp();
            }
            else
            {
                infoThingy.spawn = spawn;
                SceneManager.LoadScene(gameObject.name);
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    void WakeUp()
    {
        infoThingy.date++;
        infoThingy.clock = Random.Range(0f, 24f) * 60;
        infoThingy.SetProgress();
        infoThingy.spawn = infoThingy.bed;
        SceneManager.LoadScene("Houses");
    }
}