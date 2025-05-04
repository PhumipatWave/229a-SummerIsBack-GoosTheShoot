using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu_script : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject creditOpening;
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
        Time.timeScale = 1f;
        isPause = false;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("MenuUI");
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
