using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveData activeSave;

    private string savePath;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        savePath = Application.persistentDataPath;

        Load();
    }

    public void Save()
    {
        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(savePath + "/" + activeSave.saveName + ".infish", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        print("Saved");
    }

    public void Load()
    {
        string loadPath = savePath + "/" + activeSave.saveName + ".infish";

        if (File.Exists(loadPath))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(loadPath, FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();
        }

        print("Loaded");
    }

    public void Delete()
    {
        string deletePath = savePath + "/" + activeSave.saveName + ".infish";

        if (File.Exists(deletePath))
        {
            File.Delete(deletePath);
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
