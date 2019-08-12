using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class creates the framework for the songs objects that 
// will appear when the user chooses to view all the songs in their library 
public class LibrarySongListButton : MonoBehaviour
{
    [SerializeField]
    private Text songText;
    [SerializeField]
    private LibraryListController libraryControl;

    private string myTextString;
    private Song songObject;

    public void SetText(string textString)
    {
        myTextString = textString; // Saves the string
        songText.text = textString; // This will set the text on the button
    }

    public void setSongObject(Song song)
    {
        songObject = song;
    }

    public Song getSongObject()
    {
        return songObject;
    }

    public void OnClick()
    {
        libraryControl.songFromLibraryClicked(songObject);
    }
}
