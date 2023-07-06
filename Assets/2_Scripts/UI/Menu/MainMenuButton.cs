using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OpenGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}
