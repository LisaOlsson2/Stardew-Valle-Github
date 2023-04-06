using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : BaseThings
{
    [SerializeField]
    Button[] buttons;

    int current;

    readonly Vector3 scaleClosebutton = new (35, 35, 1);
    readonly Vector3 scaleOther = new (85, 35, 1);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && current < buttons.Length - 1)
        {
            buttons[current].transform.GetChild(0).gameObject.SetActive(false);
            current++;

            if (current == 1)
            {
                transform.localScale = scaleOther;
            }

            transform.position = buttons[current].transform.position;
            buttons[current].transform.GetChild(0).gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && current > 0)
        {
            buttons[current].transform.GetChild(0).gameObject.SetActive(false);
            current--;

            if (current == 0)
            {
                transform.localScale = scaleClosebutton;
            }

            transform.position = buttons[current].transform.position;
            buttons[current].transform.GetChild(0).gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (current == 0)
            {
                transform.parent.gameObject.SetActive(false);
            }
            else
            {
                buttons[current].transform.GetChild(0).gameObject.SetActive(false);
                current = 0;
                buttons[current].transform.GetChild(0).gameObject.SetActive(true);
                transform.position = buttons[current].transform.position;
                transform.localScale = scaleClosebutton;
                transform.parent.gameObject.SetActive(false);
            }
        }
        
        if ((Input.GetKeyDown(KeyCode.Z) && current != 0 && current != 4) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            buttons[current].Do();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            if (current == 0)
            {
                transform.parent.gameObject.SetActive(false);
            }
            else
            {
                infoThingy.SetPrefs();
                Destroy(infoThingy.gameObject);
                SceneManager.LoadScene(buttons[current].gameObject.name);
            }
        }
    }
}