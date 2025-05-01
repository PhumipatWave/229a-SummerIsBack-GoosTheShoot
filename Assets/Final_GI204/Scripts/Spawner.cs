using UnityEngine;

public class Spawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spawner"))
        {
            //Instantiate();
        }
    }
}
