using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characters : CharactersBase
{
    bool interactable;

    string greeting;

    [SerializeField]
    GameObject portraitObject;

    public readonly string lineChangerString = "change lines";

    readonly string[,] namesAndGreets = { { "Valle", "YOO" }, { "Noah", "Whats up motherfuckers" }, { "Lisa", "Helo :)" }, { "Lily", "Hey" }, { "Frank", "Sup?" }, { "Eddie", "Good morning" }, { "Alex", "Greetings mortal" }, { "Leo", "Hello" } };
    public string[][] allLines; // lines are set seperately in every npc script
                               //each array/row is a dialogue

    string[] currentLines;

    int line;
    public bool talkable;

    // Start is called before the first frame update
    public virtual void Start()
    {
        AnotherStartThingy();

        //destroys the npc equivelent of the character you are playing as
        if (gameObject.name == infoThingy.player + 2)
        {
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < namesAndGreets.Length / 2; i++)
            {
                if (namesAndGreets[i, 0] + 2 == gameObject.name)
                {
                    greeting = namesAndGreets[i, 1];

                    if (gameObject.name == "Valle2")
                    {
                        greeting += " " + infoThingy.player + "!";
                    }

                    break;
                }
                greeting = "woof";
            }
        }
    }

    public virtual void Update()
    {

        // talking

        if (interactable && Input.GetKeyDown(KeyCode.Z) && !infoThingy.playerScript.inventory.activeSelf)
        {

            if (!infoThingy.playerScript.dialogue.activeSelf)
            {
                line++;
                animator.SetInteger("state", 0);
                infoThingy.playerScript.animator.SetInteger("state", 0);
                infoThingy.playerScript.dialogue.SetActive(true);
                portraitObject.SetActive(true);
                infoThingy.playerScript.text.text = greeting;
            }
            else if (line > 0)
            {
                if (talkable && line < currentLines.Length + 1)
                {
                    if (!infoThingy.playerScript.inputField.isFocused)
                    {
                        if (currentLines[line - 1] == "")
                        {
                            infoThingy.playerScript.inputField.interactable = true;
                            infoThingy.playerScript.inputField.ActivateInputField();
                            if (portraitObject.activeSelf)
                            {
                                infoThingy.playerScript.portrait.SetActive(true);
                                portraitObject.SetActive(false);
                            }
                        }
                        else if(!portraitObject.activeSelf)
                        {
                            portraitObject.SetActive(true);
                            infoThingy.playerScript.portrait.SetActive(false);
                        }
                        infoThingy.playerScript.inputField.text = "";
                        infoThingy.playerScript.inputField.interactable = false;
                        infoThingy.playerScript.text.text = currentLines[line - 1];
                        line++;
                    }
                }
                else
                {
                    infoThingy.playerScript.text.text = "";

                    if (infoThingy.playerScript.portrait.activeSelf)
                    {
                        infoThingy.playerScript.portrait.SetActive(false);
                    }
                    if (portraitObject.activeSelf)
                    {
                        portraitObject.SetActive(false);
                    }

                    infoThingy.playerScript.dialogue.SetActive(false);
                    line = 0;
                }
            }
        }
    }

    void SetNewLines(int row)
    {
        currentLines = new string[allLines[row].Length];
        for(int i = 0; i < allLines[row].Length; i++)
        {
            currentLines[i] = allLines[row][i];
        }
    }

    public override void Change(string command)
    {
        if (command == lineChangerString)
        {
            SetNewLines(GetRow());
        }
    }

    public virtual int GetRow()
    {
        return 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
    }
}