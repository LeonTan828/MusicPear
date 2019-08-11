using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGlobal : MonoBehaviour
{
    // Global Saves
    public List<Playlist> userPlaylists = new List<Playlist>();
    public string userName;
    public string userPassword;
    public string userUserName;

    public static UserGlobal Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
