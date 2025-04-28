using UnityEngine;

public class Creditmenu_manager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditMenu;

    public void OpenCredit()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        creditMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
