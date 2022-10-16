using UnityEngine;

public class LastPlayerZoneTarget : MonoBehaviour
{
    // Private fields
    private GameObject[] _activeEnemyBullets;

    // Find active enemy bullets and deactivates them
    private void Start()
    {
        _activeEnemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

        for (int i = 0; i < _activeEnemyBullets.Length; i++)
        {
            _activeEnemyBullets[i].GetComponent<BlueEnemyBullet>().enabled = false;
            _activeEnemyBullets[i].GetComponent<BlueEnemyBulletDeactivate>().enabled = true;
        }

        Destroy(gameObject);
    }
}
