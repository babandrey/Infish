using UnityEngine;

public static class PetData
{
    private static string petsPrefabPath = "Prefabs/Fish/Pets/";
    private static string[] petNames = GetPetNames();

    private static string[] GetPetNames()
    {
        GameObject[] pets = Resources.LoadAll<GameObject>(petsPrefabPath);
        string[] petNames = new string[pets.Length];

        for(int i = 0; i < pets.Length; i++)
        {
            petNames[i] = pets[i].name;
        }

        Resources.UnloadUnusedAssets();

        return petNames;
    }

    public static GameObject GetPetData(string petName)
    {
        return Resources.Load<GameObject>(petsPrefabPath + petName);
    }

    public static string[] PetNames
    {
        get { return petNames; }
    }
}
