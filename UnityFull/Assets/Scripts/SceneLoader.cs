using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadWelcomeScene()
    {
        SceneManager.LoadScene(0); // Load Character Customization 
    }

    public void loadSignUpScene()
    {
        SceneManager.LoadScene(1); // Load Sign Up Screen 
    }

    public void loadLogInScene()
    {
        SceneManager.LoadScene(2); // Load Login Screen 
    }

    public void loadCharacterCustomizeScene()
    {
        SceneManager.LoadScene(3); // Load Character Customization 
    }

    public void loadHomeScene()
    {
        SceneManager.LoadScene(4); // Load home
    }

    public void loadMusicLibraryScene()
    {
        SceneManager.LoadScene(5); // Load Character Customization 
    }

    public void loadMusicDatabaseScene()
    {
        SceneManager.LoadScene(6);    
    }

    
}
