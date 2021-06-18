using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public void ChangeLevel(string levelName)
    {
        SaveManager.Instance.Save();
        SceneManager.LoadScene(levelName);
    }

    public void ChangeLevel(int levelBuildIndex)
    {
        SaveManager.Instance.Save();
        SceneManager.LoadScene(levelBuildIndex);
    }
}
