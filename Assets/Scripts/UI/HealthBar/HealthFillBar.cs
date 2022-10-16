using UnityEngine;
using UnityEngine.UI;

public class HealthFillBar : MonoBehaviour
{
    // Private fields
    private Image _fillBar;

    private void Start()
    {
        _fillBar = GetComponent<Image>();
    }

    private void Update()
    {
        _fillBar.fillAmount = PlayerStats.health / 100.0f;
    }
}
