using UnityEngine;

public class StartEnemySpawn : MonoBehaviour
{
    // Serialize fields
    [SerializeField] private GameObject _enemySpawner;

    private void OnTriggerEnter(Collider other)
    {
        if(!ShowHideMenu.gameIsPaused)
        {
            if (other.gameObject.tag == "Player" && !_enemySpawner.activeSelf)
            {
                _enemySpawner.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
