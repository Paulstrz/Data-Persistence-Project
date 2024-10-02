using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

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

        LoadHighscoreUsername();
        LoadHighscore();
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
        MenuUIHandler menuUIHandler = FindObjectOfType<MenuUIHandler>();
        if (menuUIHandler != null)
        {
            menuUIHandler.SetHighscoreText(highscoreUsername, highscore);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public String highscoreUsername;
        public int highscore;
    }

    public void SaveHighscoreUsername()
    {
        SaveData data = new SaveData();
        data.highscoreUsername = highscoreUsername;

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.highscore = highscore;

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscoreUsername()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscoreUsername = data.highscoreUsername;
        }
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.highscore;
        }
    }
}
