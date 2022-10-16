using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Public fields
    public static int health;
    public static int power;
    public static float ricochetChance;
    public static int killedEnemy;

    private void Start()
    {
        health = 100;
        power = 50;
        ricochetChance = Mathf.Clamp(110 - health, 0, 100);
        killedEnemy = 0;
    }

    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            health = Mathf.Clamp(health, 0, 100);
            power = Mathf.Clamp(power, 0, 100);
            ricochetChance = Mathf.Clamp(110 - health, 0, 100);
        }
    }
}
