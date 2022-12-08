using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMenus : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;
    // change to Button later


    float bottomY;
    float topY;

    int current;

    readonly float distance = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        bottomY = buttons[0].transform.position.y;
        topY = buttons[^1].transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") && transform.position.y < topY - distance / 2)
        {
            current++;
            transform.position = buttons[current].transform.position;
        }

        if (Input.GetKeyDown("down") && transform.position.y > bottomY + distance / 2)
        {
            current--;
            transform.position = buttons[current].transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Z) && buttons[current].TryGetComponent<Button>(out Button button))
        {
            button.Do();
        }
    }
}