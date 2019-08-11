using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
    public InputField passwordField;
    public InputField usernameField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();

        form.AddField("password", passwordField.text);
        form.AddField("username", usernameField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            Debug.Log("user logged in successfully");
            DBManager.username = usernameField.text;
            SceneManager.LoadScene(4);

        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }
}
