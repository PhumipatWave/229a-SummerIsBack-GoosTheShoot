using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hitPoints;
    public float maxHitPoints = 5;
    void Start()
    {
        hitPoints = maxHitPoints;
    }

   public void TakeHit(float damage)
    {
        hitPoints -= damage;

        if (hitPoints < 0)
        {
            Destroy(gameObject);
        }

    }
}
