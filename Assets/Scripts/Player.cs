using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : CharactersBase
{
    public GameObject inventory;
    public GameObject dialogue;

    public Text text;
    public GameObject portrait;
    public InputField inputField;

    [SerializeField]
    GameObject inventoryAnimation;

    readonly float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        infoThingy = FindObjectOfType<InfoToSave>();
        AnotherStartThingy();

        if (infoThingy.player != gameObject.name)
        {
            Destroy(inventoryAnimation);
            Destroy(gameObject);
        }
        else
        {
            infoThingy.playerScript = this;
            infoThingy.SetSoundVolume();

            transform.position = infoThingy.spawn;
            text = dialogue.transform.GetChild(1).GetComponent<Text>();
            inputField = dialogue.transform.GetChild(3).GetComponent<InputField>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!inventory.activeSelf && !dialogue.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                inventory.SetActive(true);
            }

            if (Input.GetKey("up"))
            {
                animator.SetInteger("state", 3);
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            }
            if (Input.GetKey("down"))
            {
                animator.SetInteger("state", 2);
                transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            }
            if (Input.GetKey("left"))
            {
                if (infoThingy.player == "Valle" || infoThingy.player == "Lily")
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0); // this is supposed to be a change of animation, but i don't have one at the moment
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0); // flips the sprite
                }
                animator.SetInteger("state", 1);
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey("right"))
            {
                if (infoThingy.player == "Valle" || infoThingy.player == "Lily")
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                animator.SetInteger("state", 1);
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }


            if (!Input.GetKey("right") && !Input.GetKey("left") && !Input.GetKey("up") && !Input.GetKey("down"))
            {
                animator.SetInteger("state", 0);
            }
        }
    }

}