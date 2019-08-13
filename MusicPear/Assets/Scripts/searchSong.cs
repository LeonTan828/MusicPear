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

    [SerializeField]
    public SongListControlDatabase songController;

    public Song testSong; 
    void Awake() {
        testSong = gameObject.AddComponent<Song>();
    }

    void Start()
    {
        string[] testing = new string[]{"helloworld"};
        songController.updateSearchResults(testing);
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

            testSong = makeSongObject(words[1]);
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
            
            testSong = makeSongObject(words[1]);
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

            testSong = makeSongObject(words[1]);
            //SceneManager.LoadScene(); // NOTE: need to check what scene
        }
        else
        {
            Debug.Log("Error: Couldn't search " + www.text);
        }
    }

    public Song makeSongObject(string result)
    {
        
        Song newSong = gameObject.AddComponent<Song>();
        newSong.setSongID(result);
        newSong.findData();

        Debug.Log(newSong.getSongName() + " song object made");

        return newSong;
    }
}