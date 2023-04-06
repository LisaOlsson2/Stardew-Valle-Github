using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FileTextCurrent : Button
{
    readonly Vector3[] beds = {new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(51, -22, 0), new Vector3(-22, 15, 0), new Vector3(26, 4, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) };
    readonly float[] wakeUpTimes = { 6, 6, 6, 6, 6, 6, 6, 6 };

    [SerializeField]
    int file;

    TextMesh text;

    [SerializeField]
    GameObject square;

    [SerializeField]
    GameObject[] buttons;

    int current;

    InfoToSave infoThingy;

    readonly float distance = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        infoThingy = FindObjectOfType<InfoToSave>();
        text = GetComponent<TextMesh>();

        if (PlayerPrefs.GetInt("file" + file + "Progress") != 0)
        {
            text.text = "Load";

            int player = (int)(PlayerPrefs.GetInt("file" + file + "Progress") / Mathf.Pow(10, infoThingy.progressLength - 1) - 1);
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == player)
                {
                    buttons[i].SetActive(true);
                    current = i;
                }
                else
                {
                    Destroy(buttons[i]);
                }
            }
        }
        else
        {
            current = file - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (square.transform.position.y > transform.position.y - distance / 2 && square.transform.position.y < transform.position.y + distance / 2)
        {
            if (text.text == "New")
            {
                if (Input.GetKeyDown("right"))
                {
                    buttons[current].SetActive(false);
                    if (current < buttons.Length - 1)
                    {
                        current++;
                    }
                    else
                    {
                        current = 0;
                    }
                    buttons[current].SetActive(true);
                }
                if (Input.GetKeyDown("left"))
                {
                    buttons[current].SetActive(false);
                    if (current > 0)
                    {
                        current--;
                    }
                    else
                    {
                        current = buttons.Length - 1;
                    }
                    buttons[current].SetActive(true);
                }
            }
        }
    }

    public override void Do()
    {
        if (text.text == "New")
        {
            PlayerPrefs.SetInt("file" + file + "Progress", (int)((current + 1) * Mathf.Pow(10, infoThingy.progressLength - 1)));
            PlayerPrefs.SetInt("file" + file + "Date", 1);
            text.text = "Load";
        }

        infoThingy.file = file;
        infoThingy.player = buttons[current].name;
        infoThingy.progress = PlayerPrefs.GetInt("file" + infoThingy.file + "Progress").ToString().ToCharArray();
        infoThingy.date = PlayerPrefs.GetInt("file" + infoThingy.file + "Date");
        infoThingy.bed = beds[current];
        infoThingy.spawn = beds[current];
        infoThingy.clock = wakeUpTimes[current] * 60;
        infoThingy.ChangeMusic(1);

        SceneManager.LoadScene("Houses");
    }
}