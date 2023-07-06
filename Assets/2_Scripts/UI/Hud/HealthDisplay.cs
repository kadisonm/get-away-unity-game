using UnityEngine.UI;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        float fill = (float) GameManager.Instance.PlayerValues.CurrentHealth / (float) GameManager.Instance.PlayerValues.PlayerMaxHealth;

        _image.fillAmount = fill;
    }
}
