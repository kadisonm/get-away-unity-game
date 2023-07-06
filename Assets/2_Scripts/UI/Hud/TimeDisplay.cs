using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    private TextMeshProUGUI _displayText;

    private void Awake()
    {
        _displayText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _displayText.text = "" + Mathf.Round(GameManager.Instance.ElapsedRoundTime);
    }
}
