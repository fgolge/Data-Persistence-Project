using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistenceHandler : MonoBehaviour
{
    public static DataPersistenceHandler Instance;

    public string playerName;
    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void OnBestScoreUpdate()
    {
        bestPlayerName = playerName;

        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.playerName;
            bestScore = data.bestScore;
        }
    }
}
