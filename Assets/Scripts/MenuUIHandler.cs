using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        SetHighscoreText(MenuManager.Instance.highscoreUsername, MenuManager.Instance.highscore);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MenuManager.Instance.SaveHighscoreUsername();
        MenuManager.Instance.SaveHighscore();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void SetHighscoreText(String hsUsername, int hs)
    {
        highscoreText.text = "Best Score: " + hsUsername + ": " + hs;
    }
}
