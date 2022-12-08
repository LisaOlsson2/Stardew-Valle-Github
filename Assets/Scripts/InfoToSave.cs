using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InfoToSave : MonoBehaviour
{
    public char[] progress;
    //0: season, 1: valle, 2: noah, 3: lisa, 4: lily, 5: frank, 6: eddie, 7: alex, 8: leo

    public string player;
    public int file;
    public Vector3 spawn;
    public float musicVolume;
    public float soundVolume;
    public float clock;
    public AudioSource[] musicAudio;
    public AudioSource currentMusic;
    public int season;
    public string currentScene;
    public Player playerScript;

    public static KeyCode[] keysInUse = { KeyCode.Z, KeyCode.X, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow};
    // not in use

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        soundVolume = PlayerPrefs.GetFloat("soundVolume");
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        musicAudio = transform.GetChild(0).GetComponents<AudioSource>();
        currentMusic = musicAudio[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript != null && !playerScript.inventory.activeSelf && !playerScript.dialogue.activeSelf)
        {
            clock += Time.deltaTime;
        }
    }

    public void SetMusicVolume()
    {
        foreach (AudioSource source in musicAudio)
        {
            source.volume = musicVolume;
        }
    }
}