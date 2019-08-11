using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unityengine.UI;

public class Login : MonoBehaviour {

        public InputField nameField;
        public InputField passwordField;
        public InputField usernameField;

        public Button submitButton;

        public void CallLogin()
        {
            StartCoroutine(Login());
        }

        IEnumerator LoginUser()
        {
            WWWform form = new WWWForm();
            form.AddField("name", nameField.text);
            form.AddField("password", passwordField.text);
            form.AddField("username", usernameField.text);
            WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
            yield return www;
            if (www.text[0] == '0')
            {
                DBManager.username = nameField.text;
            }
            else
            {
                Debug.log("User login failed. Error #" + www.text);
            }
            // test
        }
}
