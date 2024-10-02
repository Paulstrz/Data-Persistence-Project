using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public String highscoreUsername;
    public int highscore;

    private void Awake()
    {
        if (Instance != null)
        {
           Destroy(gameObject);
           return; 
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetHihgscoreUsername(String hsUsername)
    {
        MenuManager.Instance.highscoreUsername = hsUsername;
    }

    public void SetHighscore(int hs)
    {
        MenuManager.Instance.highscore = hs;
    }

    private void Start()
    {
        if (MenuManager.Instance != null)
        {
            SetHihgscoreUsername(MenuManager.Instance.highscoreUsername);
            SetHighscore(MenuManager.Instance.highscore);
        }
    }
}
