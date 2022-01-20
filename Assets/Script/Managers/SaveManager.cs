using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveManager : Singleton<SaveManager>
{
    string sceneName = "Level";

    public string SceneName
    {
        get
        {
            return PlayerPrefs.GetString(sceneName);
        }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SavePlayerData();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayerData();
        }
    }


    public void SavePlayerData()
    {
        Save(GameManager.Instance.playerStats.characterData, GameManager.Instance.playerStats.characterData.name);
        //Save(GameManager.Instance.playerStats.attackData, "AttackData");
    }

    public void LoadPlayerData()
    {
        Load(GameManager.Instance.playerStats.characterData, GameManager.Instance.playerStats.characterData.name);
        //Load(GameManager.Instance.playerStats.attackData, "AttackData");
    }

    public void Save(Object data, string key)
    {
        var jsonData = JsonUtility.ToJson(data,true);
        PlayerPrefs.SetString(key, jsonData);
        PlayerPrefs.SetString(sceneName, SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }

    public void Load(Object data, string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), data);
        }
    }
}
