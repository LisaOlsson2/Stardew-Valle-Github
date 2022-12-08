using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mickael : Characters
{
    /*
    AudioSource sound;
    Animator animator;
    [SerializeField]
    Sprite mickaelSpeaking;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        sound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        
        sound.volume = book.soundVolume;

        if (Input.GetKeyDown(KeyCode.Z) && !player.inventory.activeSelf && interactable)
        {
            if (!condition)
            {
                if (talking == 1)
                {
                    animator.enabled = false;
                    gameObject.GetComponent<SpriteRenderer>().sprite = mickaelSpeaking;
                    sound.Play();
                }
                else if (talking == 2)
                {
                    animator.enabled = true;
                }
            }
            else
            {
                if (talking == 1)
                {
                    //player.dialogue.transform.GetChild(4).GetComponent<Text>().text = ""; 
                }
            }
        }
        if (!sound.isPlaying)
        {
            animator.enabled = true;
        }
    }
    */
}
