using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : BaseThings
{
    readonly float time = 6f;

    readonly Vector3 top = new(350, 190, 0);
    readonly Vector3 bottom= new(350, 130, 0);

    float hours;
    float minutes;

    GameObject analogueClock;
    RectTransform digitalClock;

    GameObject minutVisare;
    GameObject timVisare;
    Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        analogueClock = transform.GetChild(1).gameObject;
        digitalClock = transform.GetChild(0).GetComponent<RectTransform>();
        timeText = digitalClock.transform.GetChild(0).GetComponent<Text>();
        minutVisare = analogueClock.transform.GetChild(1).gameObject;
        timVisare = analogueClock.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        minutVisare.transform.localRotation = Quaternion.Euler(0, 0, -infoThingy.clock * time);
        timVisare.transform.localRotation = Quaternion.Euler(0, 0, -infoThingy.clock * (time/12));

        minutes = Mathf.Floor((360 - minutVisare.transform.localEulerAngles.z) / 6);

        if (infoThingy.clock < 720)
        {
            hours = Mathf.Floor((360 - timVisare.transform.localEulerAngles.z) / 30);
        }
        else if (infoThingy.clock < 1440)
        {
            hours = Mathf.Floor(12 + (360 - timVisare.transform.localEulerAngles.z) / 30);
        }
        else
        {
            infoThingy.date++;
            FindObjectOfType<CameraFollow>().Start();
            infoThingy.clock = 0;
        }

        if (minutes > 9)
        {
            timeText.text = hours + ":" + minutes;
        }
        else
        {
            timeText.text = hours + ":0" + minutes;
        }
    }
    public void SetDigitalPosition()
    {
        if (analogueClock.activeSelf)
        {
            digitalClock.anchoredPosition = bottom;
        }
        else
        {
            digitalClock.anchoredPosition = top;
        }
    }
}