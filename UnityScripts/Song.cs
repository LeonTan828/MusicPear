﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    private string name;
    private string artist;
    private string album;
    private string songID;

    public Song ()
    {
        songID = null;
    }

    public void setSongID(string currID)
    {
        songID = currID;
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

            string[] songStuff = words[1].Split('$');

            Debug.Log("Successfully found songs");

            name = songStuff[0];
            artist = songStuff[1];
            album = songStuff[2];
        }
        else
        {
            Debug.Log("Error: Couldn't search: " + www.text);
        }
    }

}
