using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Public fields
    public float bulletVelocity = 0.1f;
    public float speed = 1.0f;

    // Move forward
    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        } 
    }

    // Collision with walls and Blue enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "PlayerBullet")
            {
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                int actionProbability = Random.Range(0, 101);

                if (actionProbability <= PlayerStats.ricochetChance)
                {
                    int chooseBetweenTwo = Random.Range(0, 2);
                    if (chooseBetweenTwo == 1)
                    {
                        StartCoroutine(CalculateAndDestroy());
                    }
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }   
    }

    // Collision with Red enemy
    private void OnTriggerEnter(Collider other)
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (other.gameObject.tag == "Enemy")
            {
                int actionProbability = Random.Range(0, 101);

                if (actionProbability <= PlayerStats.ricochetChance)
                {
                    int chooseBetweenTwo = Random.Range(0, 2);
                    if (chooseBetweenTwo == 1)
                    {
                        StartCoroutine(CalculateAndDestroy());
                    }
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    // Ricochet
    public IEnumerator CalculateAndDestroy()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            yield return new WaitForSeconds(0.1f);

            if (FindObjectOfType<BlueEnemyTarget>() || FindObjectOfType<RedEnemyTarget>())
            {
                GameObject newBullet = Instantiate(gameObject, transform.position, transform.rotation);
                newBullet.tag = "Ricochet";
                newBullet.transform.LookAt(DetectNearestObject.nearestObject.transform);
            }
            Destroy(gameObject);
        }  
    }
}
