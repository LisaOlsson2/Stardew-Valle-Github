using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOptions : InventoryThings
{
    readonly Button[,] onOffButtons = new Button[2,4];

    [SerializeField]
    Button[] columnLeft;
    [SerializeField]
    Button[] columnRight;

    [SerializeField]
    RectTransform[] soundButtons;

    int currentRow;
    int currentColumn;

    readonly Vector3 scaleSound = new (0.6f, 0.9f, 1);
    readonly Vector3 scaleOther = new (2.6f, 1.7f, 1);

    Image image;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < columnLeft.Length; i++)
        {
            onOffButtons[0, i] = columnLeft[i];
        }
        for(int i = 0; i < columnRight.Length; i++)
        {
            onOffButtons[1, i] = columnRight[i];
        }

        currentRow = -2;
        currentColumn = (int)((soundButtons[currentRow + 2].anchoredPosition.x + 40) * 10) / 80;
        transform.position = soundButtons[0].transform.position;
        transform.localScale = scaleSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentRow > -3)
        {
            currentRow--;
            if (currentRow > -3)
            {
                if (currentRow > -1)
                {
                    transform.position = onOffButtons[currentColumn, currentRow].transform.position;
                }
                else
                {
                    if (currentRow == -1)
                    {
                        transform.localScale = scaleSound;
                    }
                    currentColumn = (int)((soundButtons[currentRow + 2].anchoredPosition.x + 40) * 10) / 80;
                    transform.position = soundButtons[currentRow + 2].transform.position;
                }
            }
            else
            {
                currentRow = -2;
                Exit();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentRow < 3)
        {
            currentRow++;
            if (currentRow > -1)
            {
                if (currentRow == 0)
                {
                    transform.localScale = scaleOther;
                    currentColumn = 0;
                }
                transform.position = onOffButtons[currentColumn, currentRow].transform.position;
            }
            else
            {
                currentColumn = (int)(soundButtons[currentRow + 2].anchoredPosition.x + 40) / 8;
                transform.position = soundButtons[currentRow + 2].transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentRow > -1)
            {
                if (currentColumn < 1)
                {
                    currentColumn++;
                    transform.position = onOffButtons[currentColumn, currentRow].transform.position;
                }
            }
            else if (currentColumn < 10)
            {
                currentColumn++;
                soundButtons[currentRow + 2].anchoredPosition = new Vector3(currentColumn * 8 - 40, soundButtons[currentRow + 2].anchoredPosition.y, 0);
                transform.position = soundButtons[currentRow + 2].transform.position;

                if (currentRow == -1)
                {
                    infoThingy.soundVolume = currentColumn / 10f;
                }
                else
                {
                    infoThingy.musicVolume = currentColumn / 10f;
                    infoThingy.SetMusicVolume();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentColumn > 0)
        {
            currentColumn--;
            if (currentRow > -1)
            {
                transform.position = onOffButtons[currentColumn, currentRow].transform.position;
            }
            else
            {
                soundButtons[currentRow + 2].anchoredPosition = new Vector3(currentColumn * 8 - 40, soundButtons[currentRow + 2].anchoredPosition.y, 0);
                transform.position = soundButtons[currentRow + 2].transform.position;

                if (currentRow == -1)
                {
                    infoThingy.soundVolume = currentColumn / 10f;
                }
                else
                {
                    infoThingy.musicVolume = currentColumn / 10f;
                    infoThingy.SetMusicVolume();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            currentRow = -2;
            currentColumn = (int)(soundButtons[currentRow + 2].anchoredPosition.x + 40) / 8;
            transform.position = soundButtons[0].transform.position;
            transform.localScale = scaleSound;

            Exit();
        }

        if (Input.GetKeyDown(KeyCode.Z) && currentRow > -1)
        {
            onOffButtons[currentColumn, currentRow].Do();
            image = onOffButtons[currentColumn, currentRow].GetComponent<Image>();

            image.color = new Color(image.color.g, image.color.r, image.color.b);
            
            if (image.color.g > 0.5)
            {
                onOffButtons[currentColumn, currentRow].transform.GetChild(0).GetComponent<Text>().text = "On";
            }
            else
            {
                onOffButtons[currentColumn, currentRow].transform.GetChild(0).GetComponent<Text>().text = "Off";
            }

            if (onOffButtons[currentColumn, currentRow].gameObject.name == "Analogue")
            {
                FindObjectOfType<Clock>().SetDigitalPosition();
            }
        }
    }
}