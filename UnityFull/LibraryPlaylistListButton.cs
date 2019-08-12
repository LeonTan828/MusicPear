using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class creates the framework for the playlist objects that 
// will appear when the user chooses to add a song to a playlist, so a new panel
// of the user's playlist will appear with all the currently created playlists 
public class LibraryPlaylistListButton : MonoBehaviour
{
    [SerializeField]
    private Text playlistText;
    [SerializeField]
    private LibraryListController libraryControl;

    private string myTextString;
    private Playlist playlistObject;

    public void SetText(string textString)
    {
        myTextString = textString; // Saves the string
        playlistText.text = textString; // This will set the text on the button
    }

    public void setPlaylistObject(Playlist playlist)
    {
        playlistObject = playlist;
    }

    public Playlist getSongObject()
    {
        return playlistObject;
    }

    public void OnClick()
    {
        libraryControl.addSongToPlaylist(playlistObject);
    }
}
