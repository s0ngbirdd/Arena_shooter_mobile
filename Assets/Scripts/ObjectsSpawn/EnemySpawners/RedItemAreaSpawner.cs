using System.Collections;
using UnityEngine;

public class RedItemAreaSpawner : MonoBehaviour
{
    // Public fields
    public GameObject itemToSpread;
    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;

    // Private fields
    private float _spawnTime = 5.0f;
    private bool _coroutineEnd = true;
    private int _numItemsToSpawn = 4;

    // Find random position for enemy to spawn
    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (_coroutineEnd)
            {
                StartCoroutine(Spawn());
                _coroutineEnd = false;
            }
        }
    }

    public void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(-itemZSpread, itemZSpread)) + transform.position;
        GameObject clone = Instantiate(itemToSpread, randPosition, itemToSpread.transform.rotation);
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_spawnTime);

        if (FindObjectsOfType<Enemy>().Length < 30)
        {
            for (int i = 0; i < _numItemsToSpawn; i++)
            {
                SpreadItem();
            }

            if (_spawnTime >= 3.0f)
            {
                _spawnTime -= 1.0f;
            }
            else if (_spawnTime == 2.0f && _numItemsToSpawn < 12)
            {
                _numItemsToSpawn += 4;
            }
        }
        _coroutineEnd = true;
    }
}