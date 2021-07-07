using UnityEngine;

public class Antay : Fish
{
    public override void CheckCollision(Collider2D collision)
    {
        IEdible food = collision.GetComponentInParent<IEdible>();

        if (food != null)
        {
            foreach (GameObject foodObject in this.food)
            {
                if (food.Name == foodObject.name)
                {
                    Eat(food);
                    return;
                }
            }
        }
    }

    protected override void Eat(IEdible food)
    {
        MonoBehaviour monoBehaviour = food as MonoBehaviour;
        if (monoBehaviour == null) return;

        GameObject obj = monoBehaviour.gameObject;

        objectPooler.SetObjectInactive(obj);
    }
}
