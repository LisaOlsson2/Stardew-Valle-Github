using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InfoToSave : MonoBehaviour
{
    char[] playerPrefs;

    public readonly int progressLength = 9;
    public char[] progress;
    //0: player, 1: valle, 2: noah, 3: lisa, 4: lily, 5: frank, 6: eddie, 7: alex, 8: leo

    public int file;

    public string player;
    public Player playerScript;
    public Vector3 bed;

    public float musicVolume;
    public float soundVolume;
    AudioSource[] musicAudio;
    AudioSource currentMusic;

    public Vector3 spawn;
    public int date;
    public float clock;

    public static KeyCode[] keysInUse = { KeyCode.Z, KeyCode.X, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow};
    // not in use

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.GetInt("actualPlayerPrefs") == 0)
        {
            PlayerPrefs.SetInt("actualPlayerPrefs", 155);
        }

        playerPrefs = PlayerPrefs.GetInt("actualPlayerPrefs").ToString().ToCharArray();
        soundVolume = (playerPrefs[1] - 48)/10f;
        musicVolume = (playerPrefs[2] - 48)/10f;
        musicAudio = transform.GetChild(0).GetComponents<AudioSource>();
        currentMusic = musicAudio[0];
        SetMusicVolume();
        SetSoundVolume();
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

    public void SetSoundVolume()
    {
        BaseThings[] baseThings = FindObjectsOfType<BaseThings>();

        foreach(BaseThings baseThing in baseThings)
        {
            if (baseThing.TryGetComponent(out AudioSource audioSource))
            {
                audioSource.volume = soundVolume;
            }
        }
    }

    public void ChangeMusic(int music)
    {
        currentMusic.enabled = false;
        musicAudio[music].enabled = true;
        currentMusic = musicAudio[music];
    }

    public void SetProgress()
    {
        string temp = "";
        foreach (char c in progress)
        {
            temp += c;
        }
        PlayerPrefs.SetInt("file" + file + "Progress", int.Parse(temp));
        PlayerPrefs.SetInt("file" + file + "Date", date);
    }

    public void SetPrefs()
    {
        string temp = "";
        foreach (char c in playerPrefs)
        {
            temp += c;
        }
        PlayerPrefs.SetInt("actualPlayerPrefs", int.Parse(temp));
    }
}