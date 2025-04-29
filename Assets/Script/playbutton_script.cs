using UnityEngine;
using UnityEngine.SceneManagement;

public class playbutton_script : MonoBehaviour
{
    public string sceneName;

    public void GameplayViewport()
    {
        SceneManager.LoadScene(sceneName);
    }
}
