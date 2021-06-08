using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[System.Serializable]
public class SaveData
{
    public string saveName;
    public int highestLevel;
    public List<string> petsUnlocked;
    public List<string> currentPets;
}
