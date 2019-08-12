using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    public GameObject panel;
    public Text PlaylistName;
    public Global globalControl;
    public string currentPlaylistView;

    [SerializeField]
    private string[] playlists;

    private List<GameObject> buttons;
    int currCount;

    private void Start()
    {

        playlists = globalControl.getPlaylistList(); // This will grab the LIST of playlists
        currCount = playlists.Length;

        buttons = new List<GameObject>(); // Create a new list of buttons

        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }

            buttons.Clear();
        }


        // Update for loop once i get playlists to work
        foreach (string i in playlists)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            buttons.Add(button); // add the button to the button list

            button.GetComponent<ButtonListButton>().SetText(i);


            button.transform.SetParent(buttonTemplate.transform.parent, false); 
            // this will set the parent of the button to the parent of what it is spawning from (in this case, the button list content object)
        }
    }

    public void Update()
    {
        playlists = globalControl.getPlaylistList();
        if (currCount != playlists.Length)
        {

            currCount = playlists.Length; // reassign the current number of avaliable playlists

            if (buttons.Count > 0)
            {
                foreach (GameObject button in buttons)
                {
                    Destroy(button.gameObject);
                    Debug.Log("Destroying object");
                }

                buttons.Clear();
            }


            // Update for loop once i get playlists to work
            foreach (string i in playlists)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);

                buttons.Add(button); // add the button to the button list

                //button.GetComponent<ButtonListButton>().SetText(playlists[i]);
                button.GetComponent<ButtonListButton>().SetText(i);


                button.transform.SetParent(buttonTemplate.transform.parent, false);
                // this will set the parent of the button to the parent of what it is spawning from (in this case, the button list content object)
            }
        }
    }

    public void UpdatePlaylist(string[] playlistList)
    {
        playlists = playlistList;
    }

    public void buttonClicked(string myTextString)
    {
        Debug.Log(myTextString);
        PlaylistName.text = myTextString;
        panel.SetActive(true);
        currentPlaylistView = myTextString;
    }

    public void ChangePanelState(bool state)
    {
        panel.SetActive(state); // Reveals playlist panel
    }
}
