using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public GameObject winMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            winMenu.SetActive(true);
        }
    }
}
