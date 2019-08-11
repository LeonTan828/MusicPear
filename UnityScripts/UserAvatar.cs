using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAvatar : MonoBehaviour
{
    public static UserAvatar instance;

    private void Awake()
    {
        if (instance == null || gameObject == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
            
        }
    }
}
