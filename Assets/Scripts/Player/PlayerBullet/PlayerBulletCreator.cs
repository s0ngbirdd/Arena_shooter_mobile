using UnityEngine;

public class PlayerBulletCreator : MonoBehaviour
{
    // Serialize fields
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _transformToSpawn;

    public void Shot()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            GameObject newBullet = Instantiate(_bulletPrefab, _transformToSpawn.position, _transformToSpawn.rotation);
            FindObjectOfType<AudioManager>().PlayOneShot("PlayerShot");
        }
    }
}
