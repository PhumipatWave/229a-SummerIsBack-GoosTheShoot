using UnityEngine;
using UnityEngine.UI;

public class heart_script : MonoBehaviour
{
    public Image[] hearts;
    public Sprite redHearts;
    public Sprite deathHearts;
    public GameObject lose_menu;

    private int currentHeartIndex = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lose_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if(currentHeartIndex >= 0) 
            {
                hearts[currentHeartIndex].sprite = deathHearts;
                currentHeartIndex--;
            }

            if(currentHeartIndex < 0) 
            {
                lose_menu.SetActive(true);
            }
        }
    }
}
