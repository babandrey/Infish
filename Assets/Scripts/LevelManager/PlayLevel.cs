using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayLevel : MonoBehaviour
{
    private SaveManager saveManager;
    private LevelManager levelManager;
    [SerializeField] private TextMeshProUGUI buttonText;
    private int highestLevel;

    void Awake()
    {
        saveManager = SaveManager.instance;
        levelManager = LevelManager.instance;
    }

    void Start()
    {
        highestLevel = saveManager.activeSave.highestLevel;
        string path = SceneUtility.GetScenePathByBuildIndex(highestLevel);
        string levelName = System.IO.Path.GetFileNameWithoutExtension(path);
        buttonText.text = levelName;
    }

    public void LoadLevel()
    {
        if(highestLevel > SceneManager.GetActiveScene().buildIndex)
        {
            if (saveManager.activeSave.petsUnlocked.Count > 0)
            {
                levelManager.ChangeLevel(1); //Pet Selection Scene
            }
            else
            {
                levelManager.ChangeLevel(highestLevel);
            }
        }
    }
}
