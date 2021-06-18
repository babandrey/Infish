using UnityEngine.UI;
using UnityEngine;

public class OnToggleActivator : MonoBehaviour
{
    private PetSelector petSelector;
    private Toggle toggle;
    void Start()
    {
        toggle = GetComponent<Toggle>();
        petSelector = FindObjectOfType<PetSelector>();
    }
    public void OnToggle()
    {
        petSelector.OnToggle(toggle);
    }
}
