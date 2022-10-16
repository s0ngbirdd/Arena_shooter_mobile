using UnityEngine;
using UnityEngine.UI;

public class PowerFillBar : MonoBehaviour
{
    // Private fields
    private Image _fillBar;

    private void Start()
    {
        _fillBar = GetComponent<Image>();
    }

    private void Update()
    {
        _fillBar.fillAmount = PlayerStats.power / 100.0f;
    }
}
