using UnityEngine;

public class BlueEnemyStats : MonoBehaviour
{
    // Public fields
    public int powerReward = 50;
    public int healthReward = 50;

    // Private fields
    private int _health;
    private bool _ricochet;

    private void Start()
    {
        _health = 100;
        var enemyTarget = GetComponent<BlueEnemyTarget>();
        enemyTarget.DamageDealt += Hurt;
    }

    private void OnDestroy()
    {
        var enemyTarget = GetComponent<BlueEnemyTarget>();
        if (enemyTarget)
        {
            enemyTarget.DamageDealt -= Hurt;
        }
    }

    // Trace enemy health and type of death
    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (_health <= 0 && !_ricochet)
            {
                if (PlayerStats.power < 100)
                {
                    PlayerStats.power += powerReward;
                }

                PlayerStats.killedEnemy += 1;
                Destroy(gameObject);
            }
            else if (_health <= 0 && _ricochet)
            {
                int chooseBetweenTwo = Random.Range(0, 2);
                if (chooseBetweenTwo == 1)
                {
                    if (PlayerStats.power < 100)
                    {
                        PlayerStats.power += (powerReward / 2);
                    }
                }
                else
                {
                    if (PlayerStats.health < 100)
                    {
                        PlayerStats.health += healthReward;
                    }
                }

                PlayerStats.killedEnemy += 1;
                Destroy(gameObject);
            }
        }   
    }

    public void Hurt(int damage, bool ricochet)
    {
        _health -= damage;
        _ricochet = ricochet;
    }
}
