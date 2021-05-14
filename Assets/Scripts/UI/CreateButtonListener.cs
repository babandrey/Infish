using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CreateButtonListener : MonoBehaviour
{
    public string OnClickFunctionName;
    public string[] parameters;

    void Start()
    {
        MethodInfo buyButtonMethod = typeof(BuyButtonMethods).GetMethod(OnClickFunctionName);
        GetComponent<Button>().onClick.AddListener(delegate { buyButtonMethod.Invoke(this, parameters); });
    }
}
