using System;
using UnityEngine;

public class BlueEnemyTarget : MonoBehaviour
{
    // Public fields
    public int damageNumber = 25;
    public event Action<int, bool> DamageDealt;

    // Serialize fields
    [SerializeField] private AudioClip _audioClipHit;

    private void Update()
    {
        GetComponent<AudioSource>().volume = AudioManager.masterVolume;
    }

    // Trace enemy collision and type of colission
    private void OnCollisionEnter(Collision collision)
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (collision.gameObject.tag == "PlayerBullet")
            {
                GetComponent<AudioSource>().PlayOneShot(_audioClipHit);
                DamageDealt?.Invoke(damageNumber, false);
            }
            else if (collision.gameObject.tag == "Ricochet")
            {
                GetComponent<AudioSource>().PlayOneShot(_audioClipHit);
                DamageDealt?.Invoke(damageNumber, true);
            }
        }
    }
}
