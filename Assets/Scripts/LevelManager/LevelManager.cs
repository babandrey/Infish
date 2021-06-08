using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private SaveManager saveManager;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        saveManager = SaveManager.instance;
    }

    public void ChangeLevel(string levelName)
    {
        saveManager.Save();
        SceneManager.LoadScene(levelName);
    }

    public void ChangeLevel(int levelBuildIndex)
    {
        saveManager.Save();
        SceneManager.LoadScene(levelBuildIndex);
    }
}
