using UnityEngine;
using UnityEngine.UI;

public class ShowSummary : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Text>().text = "Game over\nYour score: " + PlayerStats.killedEnemy.ToString();
    }
}
