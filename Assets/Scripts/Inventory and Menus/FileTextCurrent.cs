using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FileTextCurrent : Button
{
    [SerializeField]
    int file;

    TextMesh text;

    [SerializeField]
    GameObject square;

    [SerializeField]
    GameObject[] buttons;

    int current;

    InfoToSave book;

    readonly float distance = 0.7f;

    readonly int progressLength = 9;

    // Start is called before the first frame update
    void Start()
    {
        book = FindObjectOfType<InfoToSave>();
        text = GetComponent<TextMesh>();

        if (PlayerPrefs.GetString("file" + file) != "")
        {
            text.text = "Load";
            foreach (GameObject button in buttons)
            {
                if (button.name == PlayerPrefs.GetString("file" + file))
                {
                    button.SetActive(true);
                }
                else
                {
                    Destroy(button);
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
            if (PlayerPrefs.GetString("file" + file) == "")
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

    int GetOnes()
    {
        int ones = 0;
        for (int i = 0; i < progressLength; i++)
        {
            ones += (int)Mathf.Pow(10, i);
        }
        return ones;
    }

    public override void Do()
    {
        if (PlayerPrefs.GetString("file" + file) == "")
        {
            PlayerPrefs.SetInt("file" + file + "Progress", GetOnes());
            PlayerPrefs.SetString("file" + file, buttons[current].name);
            text.text = "Load";
        }

        book.player = PlayerPrefs.GetString("file" + file);
        book.file = file;
        book.progress = PlayerPrefs.GetInt("file" + book.file + "Progress").ToString().ToCharArray();
        book.season = book.progress[0] - 48;

        if (PlayerPrefs.GetString("file" + file) == "Valle")
        {
            book.spawn = new Vector3(-3.5f, 0, -0.3f);
        }
        if (PlayerPrefs.GetString("file" + file) == "Noah")
        {
            book.spawn = new Vector3(6, 15, -0.3f);
        }
        if (PlayerPrefs.GetString("file" + file) == "Lisa")
        {
            book.spawn = new Vector3(0, 0, -0.3f);
        }
        if (PlayerPrefs.GetString("file" + file) == "Lily")
        {
            book.spawn = new Vector3(-20, -30, -0.3f);
        }
        if (PlayerPrefs.GetString("file" + file) == "Frank")
        {
            book.spawn = new Vector3(-8, 11.5f, -0.3f);
        }
        if (PlayerPrefs.GetString("file" + file) == "Eddie")
        {
            book.spawn = new Vector3(5.5f, -9.5f, -0.3f);
        }
        if (PlayerPrefs.GetString("file" + file) == "Alex")
        {
            book.spawn = new Vector3(0, 0, -0.3f);
        }
        if (PlayerPrefs.GetString("file" + file) == "Leo")
        {
            book.spawn = new Vector3(-20.5f, -39, -0.3f);
        }

        book.clock = 0;
        book.currentMusic.enabled = false;
        book.musicAudio[1].enabled = true;
        book.currentMusic = book.musicAudio[1];

        SceneManager.LoadScene("Houses");
    }
}
