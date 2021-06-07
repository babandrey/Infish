using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetSelector : MonoBehaviour
{
    private List<Toggle> activeToggles;
    private Toggle lastToggled;

    private void Start()
    {
        activeToggles = new List<Toggle>();
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
