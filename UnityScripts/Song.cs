using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    private string name;
    private string artist;
    private string album;
    private string songID;

    public Song (string currID)
    {
        songID = currID;

        findData();
    }

    public void findData()
    {
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        WWWForm form = new WWWForm();
        form.AddField("searchID", songID);
        // NOTE: Remember to change the PHP
        WWW www = new WWW("http://localhost/sqlconnect/songinfoshow.php", form);
        yield return www;
        
        if (www.text[0] == '0')
        {
            string temp = www.text;
            string[] words = temp.Split(' ');

            Debug.Log("Successfully found songs");

            name = words[1];
            artist = words[2];
            album = words[3];
        }
        else
        {
            Debug.Log("Error: Couldn't search: " + www.text);
        }
    }

}
