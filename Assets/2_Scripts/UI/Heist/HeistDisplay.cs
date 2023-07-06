using UnityEngine;
using TMPro;

public class HeistDisplay : MonoBehaviour
{
    [SerializeField] private Heist HeistHandler;
    
    private TextMeshProUGUI _displayText;

    private void Awake()
    {
        _displayText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _displayText.text = HeistHandler.Announcement;
    }
}
