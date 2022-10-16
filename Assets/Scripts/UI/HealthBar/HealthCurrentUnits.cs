using UnityEngine;
using UnityEngine.UI;

public class HealthCurrentUnits : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Text>().text = PlayerStats.health.ToString();
    }
}
