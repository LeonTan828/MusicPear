using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playlist
{
    [SerializeField]
    private string name;

    public List<Song> songList;

    public Playlist(string playlistName)
    {
        name = playlistName;
    }

    public string getPlaylistName()
    {
        return name;
    }

    public void addSongToPlaylist(Song song)
    {
        songList.Add(song);
    }

    public void deleteSongFromPlaylist(Song song)
    {
        songList.Remove(song);
    }

}
