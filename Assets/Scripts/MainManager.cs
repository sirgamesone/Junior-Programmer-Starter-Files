using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour {


    public static MainManager Instance;

    public Color TeamColor;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }


    [System.Serializable]
    class SaveData {
        public Color TeamColor;
    }

    public void SaveColor() {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;
        string jsonString = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonString);
    }

    public void LoadColor() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string jsonString = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonString);

            TeamColor = data.TeamColor;
        }
    }


}
