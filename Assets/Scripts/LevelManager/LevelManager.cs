using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public void ChangeLevel(string levelName)
    {
        SaveManager.Instance.Save();
        SceneManager.LoadScene(levelName);

        if(SceneManager.GetSceneByName(levelName).buildIndex > 2) //Level 1-1 or higher
        {
            GoldManager.Reset();
        }
    }

    public void ChangeLevel(int levelBuildIndex)
    {
        SaveManager.Instance.Save();
        SceneManager.LoadScene(levelBuildIndex);

        if (levelBuildIndex > 2) //Level 1-1 or higher
        {
            GoldManager.Reset();
        }
    }
}
