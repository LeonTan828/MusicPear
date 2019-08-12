using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingColor : MonoBehaviour
{
    public GameObject panel;

    public SpriteRenderer head;
    public SpriteRenderer body;
    public Image squareDisplay;

    public int whatColor = 0;

    public Color[] colors;

    public void Update()
    {
        squareDisplay.color = head.color;
        body.color = head.color;

        for (int i = 0; i < colors.Length; i++)
        {
            if(i == whatColor)
            {
                head.color = colors[i];
            }
        }

    }

    public void ChangePanelState(bool state)
    {
        panel.SetActive(state);
    }

    public void ChangeColor(int index)
    {
        whatColor = index;
    }
}
