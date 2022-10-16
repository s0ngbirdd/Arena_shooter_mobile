using UnityEngine;

public class BlueEnemyBulletDeactivate : MonoBehaviour
{
    // Public fields
    public int drainNumber = 25;

    // Private fields
    private float _speed = 2.0f;

    // Move forward
    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
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
