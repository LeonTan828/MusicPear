using System.Collections;
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

    public Song(string inputName)
    {
        name = inputName;
    }

    public void setSongID(string currID)
    {
        songID = currID;
    }

    public string getSongName()
    {
        return name;
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
            Debug.Log(www.text);

            string temp = www.text;
            string[] words = temp.Split('@');

            string[] songData = words[1].Split('$');

            Debug.Log("Successfully found songs");

            Debug.Log(songData[0]);
            Debug.Log(songData[1]);
            Debug.Log(songData[2]);

            name = songData[0];
            artist = songData[1];
            album = songData[2];

            Debug.Log(name);
        }
        else
        {
            Debug.Log("Error: Couldn't search: " + www.text);
        }
    }

}
