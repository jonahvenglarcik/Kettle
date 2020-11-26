using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Authentication : MonoBehaviour
{
    // Username field
    public TMP_InputField usernameField;
    public Image usernameFieldBackground;

    // Password field
    public TMP_InputField passwordField;
    public Image passwordFieldBackground;

    // Set the field to this color when combo is invalid
    public Color wrongColor;

    // Scene to load when logging in
    public string mainScene;

    // Hard-coded username/password combo to type in
    private string username = "cephuez";
    private string password = "password";

    public void LogIn()
    {
        bool correct = CheckLogIn();

        if (correct)
        {
            SceneManager.LoadScene(mainScene, LoadSceneMode.Single);
        }
        else
        {
            usernameFieldBackground.color = wrongColor;
            passwordFieldBackground.color = wrongColor;
        }
    }

    private bool CheckLogIn()
    {
        return usernameField.text == username && passwordField.text == password;
    }
}
