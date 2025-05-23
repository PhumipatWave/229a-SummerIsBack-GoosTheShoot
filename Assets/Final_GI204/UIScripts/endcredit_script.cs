using UnityEngine;
using UnityEngine.SceneManagement;

public class endcredit_script : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject creditMenu;

    public void WinNext() 
    {
        winMenu.SetActive(false);
        creditMenu.SetActive(true);
    }

    public void LoseNext()
    {
        loseMenu.SetActive(false);
        Destroy(loseMenu.gameObject);
        creditMenu.SetActive(true);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MenuUI");
    }
}
