using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OpenGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.UISelect);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}
