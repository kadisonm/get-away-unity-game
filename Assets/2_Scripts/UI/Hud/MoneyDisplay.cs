using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    private TextMeshProUGUI _displayText;

    private void Awake()
    {
        _displayText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _displayText.text = "$" + GameManager.Instance.CollectedRoundMoney;
    }
}
