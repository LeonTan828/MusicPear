using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text myText;
    [SerializeField]
    private ButtonListControl playlistControl;


    private string myTextString;

    public void SetText(string textString) 
    {
        
        myTextString = textString; // Saves the string

        myText.text = textString; // This will set the text on the button

       
    }

    public void OnClick()
    {
        playlistControl.buttonClicked(myTextString);
    }

}
