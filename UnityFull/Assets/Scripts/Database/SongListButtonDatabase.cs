using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongListButtonDatabase : MonoBehaviour
{
    [SerializeField]
    private Text songText;
    [SerializeField]
    private SongListControlDatabase songListControl;

    private string myTextString;

    public void SetText(string textString)
    {

        myTextString = textString; // Saves the string

        songText.text = textString; // This will set the text on the button


    }

    public void OnClick()
    {
        songListControl.buttonClicked(myTextString);
    }

}
