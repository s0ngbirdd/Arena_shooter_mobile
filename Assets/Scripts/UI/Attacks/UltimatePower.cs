using UnityEngine;

public class UltimatePower : MonoBehaviour
{
    // Public fields
    public string objectTag = "Enemy";

    // Private fields
    private GameObject[] _allObjects;

    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            _allObjects = GameObject.FindGameObjectsWithTag(objectTag);
        }
    }

    public void DestroyObjects()
    {
        if (PlayerStats.power >= 100)
        {
            for (int i = 0; i < _allObjects.Length; i++)
            {
                PlayerStats.killedEnemy += 1;
                Destroy(_allObjects[i]);
            }
            PlayerStats.power -= 100;
        }
    }
}
