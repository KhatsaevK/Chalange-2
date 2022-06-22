using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;
using System.IO;


public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public string playerName;
    public string bestPlayerName;
    public int score;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            Manager.Instance.LoadPlayerData();
        }

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuiteGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int score;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            score = data.score;
        }
    }
}
