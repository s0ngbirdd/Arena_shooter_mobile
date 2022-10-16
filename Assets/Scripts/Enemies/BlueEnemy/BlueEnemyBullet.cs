using UnityEngine;

public class BlueEnemyBullet : MonoBehaviour
{
    // Public fields
    public int drainNumber = 25;

    // Private fields
    private GameObject _targetPlayer;
    private float _speed = 2.0f;

    private void Start()
    {
        _targetPlayer = FindObjectOfType<FPSInput>().gameObject;
    }

    // Move towards player
    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPlayer.transform.position, _speed * Time.deltaTime);
            transform.LookAt(_targetPlayer.transform);
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (PlayerStats.power > 0)
                {
                    PlayerStats.power -= drainNumber;
                }

                DrainIndicator.drained = true;
                FindObjectOfType<AudioManager>().PlayOneShot("PlayerDrain");
                Destroy(gameObject);
            }

            else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "PlayerBullet")
            {
                Destroy(gameObject);
            }
        }  
    }
}
