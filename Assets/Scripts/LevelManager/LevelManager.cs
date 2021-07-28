using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private int levelOneBuildIndex = 2;
    public void ChangeLevel(string levelName)
    {
        SaveManager.Instance.Save();
        SceneManager.LoadScene(levelName);

        if(SceneManager.GetSceneByName(levelName).buildIndex > levelOneBuildIndex)
        {
            GoldManager.Reset();
        }

        GameStateManager.IsFighting = false;
    }

    public void ChangeLevel(int levelBuildIndex)
    {
        SaveManager.Instance.Save();
        SceneManager.LoadScene(levelBuildIndex);

        if (levelBuildIndex > levelOneBuildIndex)
        {
            GoldManager.Reset();
        }

        GameStateManager.IsFighting = false;
    }
}
