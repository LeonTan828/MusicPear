using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    [SerializeField]
    InputField newPlaylistInput;
    [SerializeField]
    ButtonListControl playlistList;


    public GameObject panel;
    public Text currentPlaylistName;

    public string[] allSongs;

    public List<Playlist> allPlaylists;

    private void Start()
    {
        // Initialize playlist
        
        if (UserGlobal.Instance != null)
        {
            allPlaylists = UserGlobal.Instance.userPlaylists;
        } else
        {
            allPlaylists = new List<Playlist>();
        }

    }


    public string[] getPlaylistList()
    {
        string[] temp = new string[0]; // Initialize empty playlist

        // If there are playlists in the list, then reinitialize playlists
        if (allPlaylists.Count != 0)
        {
            string[] tempNew = new string[allPlaylists.Count];

            for (int i = 0; i < allPlaylists.Count; i++)
            {
                tempNew[i] = allPlaylists[i].getPlaylistName();
            }

            temp = tempNew;
        }


        return temp;
    }

    // This method creates a local playlist
    public void createNewPlaylist()
    {
        string newPlaylistName = newPlaylistInput.text;

        if (newPlaylistName.Equals(""))
        {
            newPlaylistName = "<Untitiled>";
        }

        Playlist newPlaylist = new Playlist(newPlaylistName); // Constructs a new playlist object

        allPlaylists.Add(newPlaylist); // Adds to list of playlists 

    }

    public void deletePlaylist()
    {
        // Find the index that the playlist you want to delete is at
        int deleteIndex = -1;

        for (int i = 0; i < allPlaylists.Count; i++)
        {
            if (allPlaylists[i].getPlaylistName().Equals(currentPlaylistName.text))
            {
                if (deleteIndex < 0)
                {
                    deleteIndex = i;
                }
                
            }
        }

        allPlaylists.RemoveAt(deleteIndex); // Delete item
    }

    public void ChangePanelState(bool state)
    {
        panel.SetActive(state); // Reveals playlist panel
    }
}
