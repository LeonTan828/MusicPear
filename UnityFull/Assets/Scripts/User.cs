using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public List<Playlist> userPlaylists;
    public List<Song> userLibrary;

    public string userName;
    public string userPassword;
    public string userUserName;

    public void saveUser()
    {
        UserGlobal.Instance.userPlaylists = userPlaylists;

    }
}
