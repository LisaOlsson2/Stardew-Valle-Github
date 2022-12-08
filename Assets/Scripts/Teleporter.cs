using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : BaseThings
{
    public Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        infoThingy.currentScene = scene.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == infoThingy.player)
        {
            if (gameObject.name != "Houses")
            {
                // from Houses
                if (scene.name == "Houses")
                {
                    if (transform.parent.name == "FranksHus")
                    {
                        infoThingy.spawn = new Vector3(-8, 9, -0.3f);
                    }
                }


                // from Årsta
                if (scene.name == "Årsta")
                {
                    if (gameObject.name == "Enskede")
                    {
                        infoThingy.spawn = new Vector3(11, 48, -0.3f);
                    }
                    if (gameObject.name == "Gullmarsplan")
                    {
                        infoThingy.spawn = new Vector3(0, 0, -0.3f);
                    }
                }

                // from Enskede
                if (scene.name == "Enskede")
                {
                    if (gameObject.name == "Årsta")
                    {
                        infoThingy.spawn = new Vector3(-10, 33.5f, -0.3f);
                    }
                    if (gameObject.name == "Gullmarsplan")
                    {
                        infoThingy.spawn = new Vector3(0, 0, -0.3f);
                    }
                }

                // from Gullmarsplan
                if (scene.name == "Gullmarsplan")
                {
                    if (gameObject.name == "Årsta")
                    {
                        infoThingy.spawn = new Vector3(-67.5f, -30.5f, -0.3f);
                    }
                    if (gameObject.name == "Enskede")
                    {
                        infoThingy.spawn = new Vector3(0, 0, -0.3f);
                    }
                    if (gameObject.name == "Trollbäcken")
                    {
                        infoThingy.spawn = new Vector3(0, 0, -0.3f);
                    }
                }

                // from Trollbäcken
                if (scene.name == "Trollbäcken")
                {
                    if (gameObject.name == "Gullmarsplan")
                    {
                        infoThingy.spawn = new Vector3(0, 0, -0.3f);
                    }
                }
            }
            else
            {
                if (transform.parent.name == "FranksHus")
                {
                    infoThingy.spawn = new Vector3(-6, 10, -0.3f);
                }
            }

            SceneManager.LoadScene(gameObject.name);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}