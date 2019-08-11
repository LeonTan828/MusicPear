// search by artist
//search by title
//search by album

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unityengine.UI;
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
            Debug.Log("Successfully found songs");
            SceneManager.LoadScene(); // NOTE: need to check what scene
        }
        else
        {
            Debug.Log("Error: Couldn't search " + www.text);
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
            Debug.Log("Successfully found songs");
            SceneManager.LoadScene(); // NOTE: need to check what scene
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
            Debug.Log("Successfully found songs");
            SceneManager.LoadScene(); // NOTE: need to check what scene
        }
        else
        {
            Debug.Log("Error: Couldn't search " + www.text);
        }
    }
}