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

            makeSongObject(words[1]);
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
        
        Song newSong = gameObject.AddComponent<Song>();
        newSong.setSongID(result);
        newSong.findData();
        Debug.Log("see if true" + newSong.name);
    }
}