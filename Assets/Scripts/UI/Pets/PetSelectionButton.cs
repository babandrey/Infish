using UnityEngine.UI;
using UnityEngine;

public class PetSelectionButton : MonoBehaviour
{
    public PetDictonary petDictonary;
    public string Name { get; set; }
    public string Description { get; set; }
    public Image Image { get; set; }

    void Awake()
    {
        Name = transform.name;
        Image = transform.Find("PetImage").GetComponent<Image>();
    }

    void Start()
    {
        //Description = petDictonary.Pets[Name].GetComponent<Pet>().Description;
    }
}
