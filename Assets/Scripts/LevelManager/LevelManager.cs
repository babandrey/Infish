using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private SaveManager saveManager;

    private void Start()
    {
        saveManager = SaveManager.Instance;
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
