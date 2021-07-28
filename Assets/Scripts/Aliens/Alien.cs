using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] private int health;
    private new Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public int Health
    {
        get { return health; }
    }

    void OnMouseDown()
    {
        health -= 5; //chaange from hard coded to gun dammage

        MoveAlienOnClick();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void MoveAlienOnClick()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 direction = (mousePosition - transform.position).normalized;
        rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }

    void OnDestroy()
    {
        GameStateManager.RemoveActiveAlien(gameObject);
    }
}
