using UnityEngine;

public class PlayerItemAreaSpawner : MonoBehaviour
{
    // Public fields
    public GameObject itemToSpread;
    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;

    // Serialize fields
    [SerializeField] private GameObject _player;

    // Private fields
    private GameObject _lastPlayerZone = null;

    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (!FindObjectOfType<BlueEnemyBullet>() && _lastPlayerZone != null)
            {
                Destroy(_lastPlayerZone);
            }
        }
    }

    // Find random position for player teleportation and spawn last player point before teleportation
    private void OnTriggerExit(Collider other)
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (other.gameObject.tag == "Player")
            {
                SpreadItem();

                if (FindObjectOfType<BlueEnemyBullet>() && _lastPlayerZone == null)
                {
                    _lastPlayerZone = new GameObject("LastPlayerZone");
                    _lastPlayerZone.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
                    _lastPlayerZone.AddComponent<LastPlayerZoneTarget>();
                }
            }
        }
    }

    public void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(-itemZSpread, itemZSpread)) + transform.position;
        GameObject clone = Instantiate(itemToSpread, randPosition, itemToSpread.transform.rotation);
    }
}