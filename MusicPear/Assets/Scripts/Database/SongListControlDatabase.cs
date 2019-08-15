using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongListControlDatabase : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    public GameObject panel;
    public Text SongName;
    public string currentPlaylistView;

    [SerializeField]
    private string[] songSearchResults;

    private Song[] songObjects;

    private List<GameObject> buttons;
    int currCount;

    private void Start()
    {
        currCount = songSearchResults.Length;
        songObjects = new Song[0]; // creates a default Song object array
        // Song objects should be overwritten in update search results 
        buttons = new List<GameObject>(); // Create a new list of buttons

        updateSearchResults(songObjects);

    }

    public void updateSearchResults(Song[] searchResults)
    {
        songObjects = searchResults;
        Debug.Log("i am in update search results");
        //Debug.Log(searchResults[0].getSongName());
        songSearchResults = new string[searchResults.Length];

        for (int k = 0; k < songSearchResults.Length; k++){
            songSearchResults[k] = searchResults[k].getSongName();
        }

        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }

            buttons.Clear();
        }


        // Update for loop once i get playlists to work
        foreach (string i in songSearchResults)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            buttons.Add(button); // add the button to the button list

            button.GetComponent<SongListButtonDatabase>().SetText(i);


            button.transform.SetParent(buttonTemplate.transform.parent, false);
            // this will set the parent of the button to the parent of what it is spawning from (in this case, the button list content object)
        }
    }

    public void buttonClicked(string myTextString)
    {
        SongName.text = myTextString;
        panel.SetActive(true);
        currentPlaylistView = myTextString;
    }

    public void ChangePanelState(bool state)
    {
        panel.SetActive(state); // Reveals playlist panel
    }
}
