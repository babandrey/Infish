using System.Collections.Generic;
 
[System.Serializable]
public class SaveData
{
    public string saveName = "savoovi";
    public int highestLevel = 3;
    public List<string> unlockedPets = new List<string>();
    public List<string> currentPets = new List<string>();
}
