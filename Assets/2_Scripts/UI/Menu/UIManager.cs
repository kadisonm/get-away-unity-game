using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject _deathUI;
    private CanvasGroup _deathCanvasGroup;

    [SerializeField] private GameObject _menuUI;

    private bool _menuOpen;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        _deathCanvasGroup = _deathUI.GetComponent<CanvasGroup>();
        _deathCanvasGroup.alpha = 0;
        _deathUI.SetActive(false);

        _menuUI.SetActive(false);

        _menuOpen = false;
    }

    public void OpenDeathScreen()
    {
        _deathUI.SetActive(true);
        StartCoroutine(FadeCanvasGroup(_deathCanvasGroup, _deathCanvasGroup.alpha, 1, 1, 2));
    }

    public void OpenMenu()
    {
        _menuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        _menuUI.SetActive(false);
        Time.timeScale = 1;

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_menuOpen)
                CloseMenu();
            else
                OpenMenu();

            _menuOpen = !_menuOpen;
        }
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float lerpTime = 1, float delay = 0)
	{
        yield return new WaitForSecondsRealtime(delay);

		float _timeStartedLerping = Time.unscaledTime;
		float timeSinceStarted = Time.unscaledTime - _timeStartedLerping;
		float percentageComplete = timeSinceStarted / lerpTime;

		while (true)
		{
			timeSinceStarted = Time.unscaledTime - _timeStartedLerping;
			percentageComplete = timeSinceStarted / lerpTime;

			float currentValue = Mathf.Lerp(start, end, percentageComplete);

            canvasGroup.alpha = currentValue;

            if (percentageComplete >= 1) 
                break;

			yield return new WaitForFixedUpdate();
		}
	}
}
