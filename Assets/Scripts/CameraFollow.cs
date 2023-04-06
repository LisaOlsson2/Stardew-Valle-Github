using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : BaseThings
{
    readonly Color[] seasons = { new Vector4(126 / 255f, 161 / 255f, 162 / 255f, 1), new Vector4(118 / 255f, 142 / 255f, 113 / 255f, 1), new Vector4(212 / 255f, 141 / 255f, 125 / 255f, 1), new Vector4(204 / 255f, 133 / 255f, 84 / 255f, 1) };

    // Start is called before the first frame update
    public void Start()
    {
        GetComponent<Camera>().backgroundColor = seasons[(int)Mathf.Ceil(infoThingy.date / 28f) % 4];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(infoThingy.playerScript.transform.position.x, infoThingy.playerScript.transform.position.y, -10);
    }
}