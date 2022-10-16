using System.Collections;
using UnityEngine;

public class RedEnemyBehaviour : MonoBehaviour
{
    // Public fields
    public int damageNumber = 15;

    // Private fields
    private GameObject _target;
    private RedEnemyStates.EnemyStates _enemyStates;
    private bool _coroutineEnd = true;
    private float _speed;
    private float _height;

    private void Start()
    {
        _target = FindObjectOfType<FPSInput>().gameObject;
        _enemyStates = RedEnemyStates.EnemyStates.Flying;

        _speed = Random.Range(1.0f, 2.1f);
        _height = Random.Range(1.0f, 2.1f);
    }

    // Checking and changing enemy states
    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (_enemyStates == RedEnemyStates.EnemyStates.Flying)
            {
                if (transform.position.y < _height)
                {
                    transform.Translate(Vector3.up * _speed * Time.deltaTime);
                }
                else if (transform.position.y >= _height)
                {
                    _enemyStates = RedEnemyStates.EnemyStates.Waiting;
                }
            }
            else if (_enemyStates == RedEnemyStates.EnemyStates.Waiting && _coroutineEnd)
            {
                StartCoroutine(Wait());
                _coroutineEnd = false;
            }
            else if (_enemyStates == RedEnemyStates.EnemyStates.Attacking)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
            }
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (other.gameObject.tag == "Player")
            {
                if (PlayerStats.health > 0)
                {
                    PlayerStats.health -= damageNumber;
                }

                DamageIndicator.attacked = true;
                FindObjectOfType<AudioManager>().PlayOneShot("PlayerHit");
                Destroy(gameObject);
            }
            else if (other.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }   
    }

    public IEnumerator Wait()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 2.1f));

            _enemyStates = RedEnemyStates.EnemyStates.Attacking;
        }  
    }
}
