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

    [SerializeField]
    private SongListControlDatabase songController;

    public Song testSong;
    public Song[] resultList;
    void Awake() {
    }

    void Start()
    {
        // string[] testing = new string[]{"helloworld"};
        // songController.updateSearchResults(testing);
        //songController = new SongListControlDatabase();
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
        songController.updateSearchResults(resultList);
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