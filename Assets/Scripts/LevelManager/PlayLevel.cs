using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayLevel : MonoBehaviour
{
    private SaveManager saveManager;
    private LevelManager levelManager;
    [SerializeField] private TextMeshProUGUI buttonText;
    private int highestLevel;

    void Start()
    {
        levelManager = LevelManager.Instance;
        saveManager = SaveManager.Instance;

        highestLevel = saveManager.activeSave.highestLevel;
        string path = SceneUtility.GetScenePathByBuildIndex(highestLevel);
        string levelName = System.IO.Path.GetFileNameWithoutExtension(path);
        buttonText.text = levelName;
    }

    public void LoadLevel()
    {
        if(highestLevel == 3) //Level 1-1
        {
            levelManager.ChangeLevel("Level 1-1");
            return;
        }

        if (saveManager.activeSave.unlockedPets.Count >= 3) //TODO: CHANGE TO ONLY > SIGN
        {
            if(SceneManager.GetActiveScene().buildIndex != 1)
            {
                levelManager.ChangeLevel("Pet Selection Menu");
            }
            else
            {
                levelManager.ChangeLevel(saveManager.activeSave.highestLevel);
            }
        }
        else
        {
            levelManager.ChangeLevel(saveManager.activeSave.highestLevel);
        }

    }
}
