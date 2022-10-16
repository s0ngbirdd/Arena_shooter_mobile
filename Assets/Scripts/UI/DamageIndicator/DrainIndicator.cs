using System.Collections;
using UnityEngine;

public class DrainIndicator : MonoBehaviour
{
    // Public fields
    public static bool drained;

    // Serialize fields
    [SerializeField] private GameObject _drainIndicator;

    // Private fields
    private bool _coroutineEnd = true;

    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (drained && _coroutineEnd && !_drainIndicator.activeSelf)
            {
                _drainIndicator.SetActive(true);
                drained = false;
                _coroutineEnd = false;
                StartCoroutine(Drain());
            }
        }   
    }

    public IEnumerator Drain()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            yield return new WaitForSeconds(0.1f);

            _drainIndicator.SetActive(false);
            _coroutineEnd = true;
        }  
    }
}
