using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] private int health;

    public int Health
    {
        get { return health; }
    }

    void OnMouseDown()
    {
        //health -= //insert alien gun dammage here

        if(health <= 0)
        {
            GameStateManager.RemoveActiveAlien(gameObject);
            Destroy(gameObject);
        }
    }
}
