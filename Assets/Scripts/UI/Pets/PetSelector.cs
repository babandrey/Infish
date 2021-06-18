using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetSelector : MonoBehaviour
{
    private List<Toggle> activeToggles;
    private List<string> pets;
    private Toggle lastToggled;

    private void Start()
    {
        activeToggles = new List<Toggle>();
        pets = new List<string>();
    }

    public List<string> Pets
    {
        get 
        {
            foreach(Toggle toggle in activeToggles)
            {
                string petName = toggle.GetComponent<PetSelectionButton>().Pet.name;
                pets.Add(petName); 
            }
            return pets;
        }
    }

    public List<Toggle> ActiveToggles
    {
        get
        {
            return activeToggles;
        }
    }

    public void OnToggle(Toggle toggle)
    {
        if (toggle.isOn)
        {
            if(activeToggles.Count + 1 > 3)
            {
                lastToggled.isOn = false;
            }

            activeToggles.Add(toggle);
            lastToggled = toggle;
        }
        else
        {
            activeToggles.Remove(toggle);
        }
    }
}
