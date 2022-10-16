using UnityEngine;
using UnityEngine.UI;

public class ShowKilledEnemies : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Text>().text = "Score: " + PlayerStats.killedEnemy.ToString();
    }
}
