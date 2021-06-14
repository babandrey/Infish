using UnityEngine.UI;
using UnityEngine;

public class PetSelectionButton : MonoBehaviour
{
    public Image PetImage { get; set; }
    void Awake()
    {
        PetImage = transform.Find("PetImage").GetComponent<Image>();
    }
}
