// search by artist
//search by title
//search by album

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SearchSong : MonoBehaviour {

    public InputField searchField;

    public Button artistButton;
    public Button titleButton;
    public Button albumButton;
    public Button refresh;
    public string tempString;
    public string tempID;

    public Song testSong;
    public Song[] resultList;

    // FROM SONGLISTCONTROLDATABASE
    //[SerializeField]
    public GameObject songButtonTemplate;

    public GameObject panel;
    public Text SongName;
    public string currentPlaylistView;

    private string[] songSearchResults;

    private Song[] songObjects;

    private List<GameObject> buttons;
    int currCount;

    void Start()
    {
        // string[] testing = new string[]{"helloworld"};
        // songController.updateSearchResults(testing);
        //songController = new SongListControlDatabase();

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
            GameObject button = Instantiate(songButtonTemplate) as GameObject;
            button.SetActive(true);

            buttons.Add(button); // add the button to the button list

            button.GetComponent<SongListButtonDatabase>().SetText(i);


            button.transform.SetParent(songButtonTemplate.transform.parent, false);
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
    public void Callartistsearch()
    {
        StartCoroutine(ArtistSearch());
    }

    public void Calltitlesearch()
    {
        StartCoroutine(TitleSearch());
    }

    public void Callalbumsearch()
    {
        StartCoroutine(AlbumSearch());
    }

    public void Callrefresh()
    {
        // testSong = new Song("Testing 123");
        // Debug.Log(testSong.getSongName());
        Debug.Log(tempString + "starts here to make new object");

        string[] songData = tempString.Split('$');
        Debug.Log("Successfully found songs for new method");
        Debug.Log(songData[0]);
        Debug.Log(songData[1]);
        Debug.Log(songData[2]);

        Song newSong = new Song(songData[0], songData[1], songData[2], tempID);

        Debug.Log(newSong.getSongName() + " song object made");

        resultList = new Song[] {newSong};

        Debug.Log(resultList[0].getSongName() + " in da list");
        // // NOTE
        updateSearchResults(resultList);
    }

    IEnumerator ArtistSearch() 
    {
        WWWForm form = new WWWForm();

        form.AddField("searchterm", searchField.text);
        // NOTE: Remember to change the PHP
        WWW www = new WWW("http://localhost/sqlconnect/artistsearch.php", form);
        yield return www;
        
        if (www.text[0] == '0')
        {
            string temp = www.text;
            string[] words = temp.Split(' ');

            Debug.Log("Successfully found songs" + words[1]);

            tempID = words[1];
            makeSongObject(words[1]);
            //SceneManager.LoadScene(); // NOTE: need to check what scene
        }
        else
        {
            Debug.Log("Error: Couldn't search: " + www.text);
        }
    }

    IEnumerator TitleSearch() 
    {
        WWWForm form = new WWWForm();

        form.AddField("searchterm", searchField.text);
        // NOTE: Remember to change the PHP
        WWW www = new WWW("http://localhost/sqlconnect/titlesearch.php", form);
        yield return www;
        
        if (www.text[0] == '0')
        {
            string temp = www.text;
            string[] words = temp.Split(' ');

            Debug.Log("Successfully found songs" + words[1]);
            
            tempID = words[1];
            makeSongObject(words[1]);
            //testSong.getName();

            //SceneManager.LoadScene(); // NOTE: need to check what scene
        }
        else
        {
            Debug.Log("Error: Couldn't search " + www.text);
        }
    }

    IEnumerator AlbumSearch() 
    {
        WWWForm form = new WWWForm();

        form.AddField("searchterm", searchField.text);
        // NOTE: Remember to change the PHP
        WWW www = new WWW("http://localhost/sqlconnect/albumsearch.php", form);
        yield return www;
        
        if (www.text[0] == '0')
        {
            string temp = www.text;
            string[] words = temp.Split(' ');

            Debug.Log("Successfully found songs" + words[1]);

            tempID = words[1];
            makeSongObject(words[1]);
            //SceneManager.LoadScene(); // NOTE: need to check what scene
        }
        else
        {
            Debug.Log("Error: Couldn't search " + www.text);
        }
    }

    public void makeSongObject(string result)
    {
        StartCoroutine(getData(result));

        // while (tempString == null) {
        //     Debug.Log("Keep running");
        // }

        // string[] songData = tempString.Split('$');
        // Debug.Log("Successfully found songs for new method");
        // Debug.Log(songData[0]);
        // Debug.Log(songData[1]);
        // Debug.Log(songData[2]);

        // Song newSong = new Song(songData[0], songData[1], songData[2], result);

        // Debug.Log(newSong.getSongName() + " song object made");

        //return newSong;


        // Song newSong = gameObject.AddComponent<Song>();
        // newSong.setSongID(result);
        // newSong.findData();

        // Debug.Log(newSong.getSongName() + " song object made");

        // return newSong;
    }

    IEnumerator getData(string input)
    {
        WWWForm form = new WWWForm();
        form.AddField("searchID", input);
        // NOTE: Remember to change the PHP
        WWW www = new WWW("http://localhost/sqlconnect/songinfoshow.php", form);
        yield return www;
        
        if (www.text[0] == '0')
        {
            Debug.Log(www.text);

            string temp = www.text;
            string[] words = temp.Split('@');
            tempString = words[1];

            Debug.Log(tempString);
            
        }
        else
        {
            Debug.Log("Error: Couldn't search: " + www.text);
        }
    }
}