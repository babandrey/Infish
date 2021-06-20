using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class SaveManager : Singleton<SaveManager>
{
    public SaveData activeSave = new SaveData();
    private string savePath;

    private PetSelector petSelector;

    void Awake()
    {
        savePath = Application.persistentDataPath;
        Load();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Delete();
        }
    }

    public void Save()
    {
        SaveLevel();
        SavePets();

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
            print("Loaded");
            return;
        }

        print("Didn't load");
    }

    public void Delete()
    {
        string deletePath = savePath + "/" + activeSave.saveName + ".infish";

        if (File.Exists(deletePath))
        {
            File.Delete(deletePath);
            print("Deleted");
            return;
        }

        print("Didn't Delete");
    }

    private void SaveLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel > activeSave.highestLevel)
        {
            activeSave.highestLevel = currentLevel;
        }
    }

    private void SavePets()
    {
        activeSave.currentPets.Clear();

        petSelector = FindObjectOfType<PetSelector>();

        if (petSelector == null)
        {
            foreach (string petName in activeSave.unlockedPets)
            {
                activeSave.currentPets.Add(petName);
            }
        }
        else
        {
            foreach (string name in petSelector.Pets)
            {
                activeSave.currentPets.Add(name);
            }
        }
    }

    public void UnlockPet(string petName)
    {
        if (!activeSave.unlockedPets.Contains(petName))
        {
            activeSave.unlockedPets.Add(petName);
        }
    }
}
