using UnityEngine;
using UnityEngine.UI;

public class PowerCurrentUnits : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Text>().text = PlayerStats.power.ToString();
    }
}
