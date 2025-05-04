using UnityEngine;
using UnityEngine.SceneManagement;

public class playbutton_script : MonoBehaviour
{
    public string sceneName;

    public void GameplayViewport()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
