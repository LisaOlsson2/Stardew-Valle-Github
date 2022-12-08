using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualInventory : InventoryThings
{
    RectTransform rectTransform;

    int currentColumn;
    int currentRow;

    readonly int distance = 34;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentColumn < 4)
        {
            currentColumn++;
            rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x + distance, rectTransform.anchoredPosition.y, 0);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentColumn > 0)
        {
            currentColumn--;
            rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x - distance, rectTransform.anchoredPosition.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && currentRow < 3)
        {
            currentRow++;
            rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - distance, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentRow > -1)
        {
            currentRow--;

            if (currentRow == -1)
            {
                rectTransform.anchoredPosition = new Vector3(-28, 34, 0);
                currentColumn = 0;
                currentRow = 0;
                Exit();
            }
            else
            {
                rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + distance, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            currentColumn = 0;
            currentRow = 0;
            rectTransform.anchoredPosition = new Vector3(-28, 34, 0);
            Exit();
        }

    }
}
