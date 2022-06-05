using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NewMainManager : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    public static NewMainManager Instance;

    public int n_Points; //private
    public string nPlayerName; //private
    public int h_Points; //private
    public string hPlayerName; //private
    //public Color TeamColor; // new variable declared

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadFile();
    }

    [System.Serializable]
    class SaveData
    {
        public int h_Points; //private
        public string hPlayerName; //private
        //public Color TeamColor;
    }

    public void SaveFile()
    {
        SaveData data = new SaveData();
        if (n_Points > h_Points)
        {
            h_Points = n_Points;
            hPlayerName = nPlayerName;
        }
        data.h_Points = h_Points;
        data.hPlayerName = hPlayerName;
        //data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            h_Points = data.h_Points;
            hPlayerName = data.hPlayerName;
            //TeamColor = data.TeamColor;
        }
    }

}
