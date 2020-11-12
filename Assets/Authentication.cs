using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Authentication : MonoBehaviour
{
    public InputField username;
    public Image usernameBackground;
    public InputField password;
    public Image passwordBackground;

    public Color wrongColor;

    public String mainScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogIn()
    {
        bool correct = CheckLogIn();
        if (correct)
        {
            SceneManager.LoadScene(mainScene, LoadSceneMode.Single);
        }
        else
        {
            usernameBackground.color = Color.red;
            passwordBackground.color = Color.red;
        }
    }
    private bool CheckLogIn()
    {
        return username.text.ToLower() == "cephuez" && password.text == "password";
    }
}
