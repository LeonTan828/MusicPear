using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 
// This class controls the entire library regarding the "ViewALLUI"
// Under this UI, the user can view their entire library of songs,
// delete songs from their library, and add songs from their library into playlists they have already created 
//
public class LibraryListController : MonoBehaviour
{
    [SerializeField]
    private GameObject songButtonTemplate;
    [SerializeField]
    private GameObject playlistButtonTemplate;
    [SerializeField]
    private Global globalControl; // Need this to access the current playlists

    public GameObject songSelectedPanel; // This displays the panel when a song is selected 
    public Text songSelectedPanelText; // This is the main text on the songSelected Panel

    public GameObject allSongScrollList; // This will display all songs in the users library
    public GameObject allPlaylistScrollList; // This object will be displayed when song is selected, and user wishes to add to an existing playlist

    // These gameobjects are assigned to the other UI panels that need to be hidden
    public GameObject hidePlaylistPanel;
    public GameObject hideSongPlaylistPanel;
    

    private bool isOn = false; // This boolean corresonds with songs are active

    // All the songs in the library in displayable string form
    private string[] allLibrarySongs;
    // All the songs as their song objects
    private List<Song> librarySongs;
    // Current number of songs in the library
    int currSongCount;
    // All the songs as buttons
    private List<GameObject> songButtons;


    // All the playlists in the library in displayable string form
    private string[] allLibraryPlaylists;
    // All the songs as their library objects 
    private List<Playlist> libraryPlaylists;
    // Current number of playlists in the library 
    int currPlaylistCount;
    // All the playlist as buttons
    private List<GameObject> playlistButtons;

    Song currSong; // The current Song that is being selected by user
    Playlist currPlaylist;

    private void Awake()
    {
        // HERE WE NEED TO INITIALIZE THE USER'S LIBRARY OF SONGS 
        // VIA LIBRARY SONGS 
    }
    private void Start()
    {
        playlistButtons = new List<GameObject>(); // Create a new list of buttons that will display the playlists (playlist -> button)
        songButtons = new List<GameObject>(); // Create a new list of buttons that will display the songs (song -> button)

        // TESTING PURPOSES ONLY
        librarySongs = new List<Song>
        {
            new Song("LIBRARYSONG_A"),
            new Song("LIBRARYSONG_B"),
            new Song("LIBRARYSONG_C"),
            new Song("LIBRARYSONG_D"),
            new Song("LIBRARYSONG_E"),
            new Song("LIBRARYSONG_F"),
            new Song("LIBRARYSONG_G"),
            new Song("LIBRARYSONG_H"),
            new Song("LIBRARYSONG_I"),
            new Song("LIBRARYSONG_J"),
            new Song("LIBRARYSONG_K"),
        };
    }

    // This method displays all the songs from the current list of songs 
    // It also updates the array of strings containing the necessary text to display 
    public void displayLibrary()
    {
        // Convert the list of Song objects into a displayable string array
        // by populating the string array allLibrarySongs with the necessary text from librarySongs song objects
        allLibrarySongs = new string[librarySongs.Count];
        for (int i = 0; i < librarySongs.Count; i++)
        {
            allLibrarySongs[i] = librarySongs[i].getSongName();
        }

        currSongCount = allLibrarySongs.Length;
        // This locally holds the current number of songs (used to update list if user deletes any song and needs to update number of songs 

        // Updates the list of song buttons by clearing out the current buttons and repopulating 
        clearSongButtons();

        int indexOfSong = 0; // This is used when assigning song objects to the song buttons 

        foreach (string i in allLibrarySongs)
        {
            GameObject button = Instantiate(songButtonTemplate) as GameObject; // This creates a new song button
            button.SetActive(true);

            songButtons.Add(button); // add the button to the button list

            button.GetComponent<LibrarySongListButton>().SetText(i); // Set the text on the song button
            button.GetComponent<LibrarySongListButton>().setSongObject(librarySongs[indexOfSong]);
            indexOfSong++;

            button.transform.SetParent(songButtonTemplate.transform.parent, false);
            // this will set the parent of the button to the parent of what it is spawning from (in this case, the button list content object)
        }
    }

    // This method displays the user's playlists 
    // Should be activated with user selects "add song to playlist" button from the songSelectedPanel
    public void displayLibraryPlaylist()
    {
        allPlaylistScrollList.SetActive(true);
        libraryPlaylists = globalControl.getPlaylists(); // Obtain user's playlists

        // Populate the playlist scrollList with user playlists
        clearPlaylistButtons();

        // Check if the user has any playlists to display
        if (libraryPlaylists.Count != 0)
        {
            // Convert the list of Playlist objects into a displayable string array
            // by populating the string array allLibraryPlaylists with the necessary text from libraryPlaylists playlist objects
            allLibraryPlaylists = new string[libraryPlaylists.Count];

            for (int i = 0; i < libraryPlaylists.Count; i++)
            {
                allLibraryPlaylists[i] = libraryPlaylists[i].getPlaylistName();
            }

            int indexOfPlaylist = 0;

            foreach (string i in allLibraryPlaylists)
            {
                GameObject button = Instantiate(playlistButtonTemplate) as GameObject; // This creates a new song button
                button.SetActive(true);

                playlistButtons.Add(button); // add the button to the button list

                button.GetComponent<LibraryPlaylistListButton>().SetText(i); // Set the text on the song button
                button.GetComponent<LibraryPlaylistListButton>().setPlaylistObject(libraryPlaylists[indexOfPlaylist]);
                indexOfPlaylist++;

                button.transform.SetParent(playlistButtonTemplate.transform.parent, false);
            }
        }
        
    }

    public void updateEntireLibary(List<Song> userLibrary)
    {
        // This method updates the library of song objects, and call the display library again (updating what the user sees)
        librarySongs = userLibrary;
        displayLibrary();

    }

    // This method either reveals the viewAllUI or hides it 
    // Allows the "viewAllSongs" button to become a toggle
    public void viewAllButtonClicked()
    {
        // Reveal / Hiding gameobjects
        if (!isOn)
        {
            // If isOn is false, the UI for viewAll is hidden, so 
            // we need to reveal the UI for viewAll (AllSong list) and hide the other UI panels 
            isOn = true;
            allSongScrollList.SetActive(true);
            hidePlaylistPanel.SetActive(false);
            hideSongPlaylistPanel.SetActive(false);

            // Update the library of songs 
            displayLibrary();

        } else
        {
            // If isOn is true, and the user selects the button again, then hide the UI
            hideViewAllUI();
            clearSongButtons();
            isOn = false;
        }
        
    }

    // This methods deletes the currently selected song from the User's library
    public void deleteSongFromLibrary()
    {
        librarySongs.Remove(currSong);
        songSelectedPanel.SetActive(false);

        clearSongButtons();

        displayLibrary();
    }

    // This method adds teh currently selected song to the selected playlist
    public void addSongToPlaylist(Playlist playlist)
    {
        playlist.addSongToPlaylist(currSong);

    }

    // This method clears all the current song buttons
    private void clearSongButtons()
    {
        // Clear all current buttons buttons
        if (songButtons.Count > 0)
        {
            foreach (GameObject button in songButtons)
            {
                Destroy(button.gameObject);
            }
            songButtons.Clear();
        }
    }

    // This method clears all the current song buttons
    public void clearPlaylistButtons()
    {
        // Clear all current buttons buttons
        if (playlistButtons.Count > 0)
        {
            foreach (GameObject button in playlistButtons)
            {
                Destroy(button.gameObject);
            }
            playlistButtons.Clear();
        }
    }

    // Toggling the song panel when a song is selected 
    public void songFromLibraryClicked(Song song)
    {
        songSelectedPanel.SetActive(true);
        currSong = song;
        songSelectedPanelText.text = currSong.getSongName();

    }

    // This method hides all the UI concerning the ViewAllUI
    public void hideViewAllUI()
    {
        allSongScrollList.SetActive(false);
        allPlaylistScrollList.SetActive(false);
        songSelectedPanel.SetActive(false);

        // Clear the button fields to avoid dupllicatoin 
        clearPlaylistButtons();
        //clearSongButtons();
    }
}
