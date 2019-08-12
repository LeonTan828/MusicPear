using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is the framework for the playlist object
public class Playlist
{
    [SerializeField]
    private string name;

    private List<Song> songList;

    public Playlist(string playlistName)
    {
        name = playlistName;
        songList = new List<Song>();
    }

    public string getPlaylistName()
    {
        return name;
    }

    public List<Song> getSongList()
    {
        return songList;
    }

    public int getNumSongs()
    {
        return songList.Count;
    }

    public void clearSongList()
    {
        songList = new List<Song>();
    }

    public void addSongToPlaylist(Song song)
    {
        songList.Add(song);
    }

    public void deleteSongFromPlaylist(string songName)
    {
        // Go through list of songs and find the index
        for (int i = 0; i < songList.Count; i++)
        {
            if (songList[i].getSongName().Equals(songName))
            {
                songList.RemoveAt(i);
                return;
            }
        }
        
    }

}
