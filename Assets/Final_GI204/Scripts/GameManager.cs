using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        if (player.isDeath)
        {

        }
    }
}
