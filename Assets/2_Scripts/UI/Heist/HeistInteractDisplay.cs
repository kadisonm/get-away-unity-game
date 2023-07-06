using UnityEngine;
using UnityEngine.UI;

public class HeistInteractDisplay : MonoBehaviour
{
    [SerializeField] private Heist HeistHandler;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        _image.enabled = HeistHandler.InProgress ? true : false;
    }
}
