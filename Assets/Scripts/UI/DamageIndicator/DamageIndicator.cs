using System.Collections;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    // Public fields
    public static bool attacked;

    // Serialize fields
    [SerializeField] private GameObject _damageIndicator;

    // Private fields
    private bool _coroutineEnd = true;

    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (attacked && _coroutineEnd && !_damageIndicator.activeSelf)
            {
                _damageIndicator.SetActive(true);
                attacked = false;
                _coroutineEnd = false;
                StartCoroutine(Damage());
            }
        }
    }

    public IEnumerator Damage()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            yield return new WaitForSeconds(0.1f);

            _damageIndicator.SetActive(false);
            _coroutineEnd = true;
        } 
    }
}
