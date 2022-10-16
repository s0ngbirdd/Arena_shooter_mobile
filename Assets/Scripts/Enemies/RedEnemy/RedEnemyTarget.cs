using System;
using UnityEngine;

public class RedEnemyTarget : MonoBehaviour
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

    // Trace enemy collision and type of collision
    private void OnTriggerEnter(Collider other)
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (other.gameObject.tag == "PlayerBullet")
            {
                GetComponent<AudioSource>().PlayOneShot(_audioClipHit);
                DamageDealt?.Invoke(damageNumber, false);
            }
            else if (other.gameObject.tag == "Ricochet")
            {
                GetComponent<AudioSource>().PlayOneShot(_audioClipHit);
                DamageDealt?.Invoke(damageNumber, true);
            }
        }   
    }
}
