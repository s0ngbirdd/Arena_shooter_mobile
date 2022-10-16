using System.Collections;
using UnityEngine;

public class BlueEnemyBulletCreator : MonoBehaviour
{
    // Public fields
    public GameObject bulletPrefab;

    // Serialize fields
    [SerializeField] private AudioClip _audioClipShot;

    // Private fields
    private bool _coroutineEnd = true;

    private void Update()
    {
        GetComponent<AudioSource>().volume = AudioManager.masterVolume;

        if (!ShowHideMenu.gameIsPaused)
        {
            if (_coroutineEnd)
            {
                StartCoroutine(SpawnBullet());
                _coroutineEnd = false;
            }
        } 
    }

    public IEnumerator SpawnBullet()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            yield return new WaitForSeconds(3.0f);

            GetComponent<AudioSource>().PlayOneShot(_audioClipShot);
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            _coroutineEnd = true;
        }  
    }
}
