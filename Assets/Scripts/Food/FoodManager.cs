using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private Food[] foodList;
    private Food currentFood;

    // Start is called before the first frame update
    void Start()
    {
        currentFood = foodList[0];
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool isPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();
            IsGameObjectUI();

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            Instantiate(currentFood.gameObject, position, currentFood.transform.rotation, transform.Find("Food"));
        }
    }

    private void IsGameObjectUI()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Ray hit" + hit.transform.name);
        }

    }
}
