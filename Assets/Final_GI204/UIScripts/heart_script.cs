using UnityEngine;
using UnityEngine.UI;

public class heart_script : MonoBehaviour
{
    public Player player;
    public Image[] hearts;
    public Sprite redHearts;
    public Sprite deathHearts;
    public GameObject lose_menu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lose_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health > 0)
        {
            hearts[player.health].sprite = deathHearts;
        }
        else if (player.health <= 0)
        {
            Time.timeScale = 0f;
            lose_menu.SetActive(true);
        }
    }
}
