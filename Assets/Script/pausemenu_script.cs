using UnityEngine;

public class pausemenu_script : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject creditOpening;
    public GameObject mainMenu;
    private bool isPause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);   
        Time.timeScale = 0f;              
        isPause = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f;              
        isPause = false;
    }

    public void Home() 
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void CreditOpening() 
    {
        creditOpening.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void CloseButton()
    {
        creditOpening.SetActive(false);
    }
}
