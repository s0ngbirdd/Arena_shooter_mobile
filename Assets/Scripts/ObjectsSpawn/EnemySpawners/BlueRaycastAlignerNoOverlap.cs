using System.Collections;
using UnityEngine;

public class BlueRaycastAlignerNoOverlap : MonoBehaviour
{
    // Public fields
    public float yOffset = 0.1f;
    public GameObject itemToSpawn;
    public float raycastDistance = 100f;
    public float overlapTestBoxSize = 1f;
    public LayerMask spawnedObjectLayer;

    // Private fields
    private BlueItemAreaSpawner _itemAreaSpawner;

    // Find position without overlapping for enemy to spawn
    private void Start()
    {
        _itemAreaSpawner = FindObjectOfType<BlueItemAreaSpawner>();

        PositionRaycast();
        StartCoroutine(DestroySelf());
    }

    private void PositionRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            Vector3 overlapTestBoxScale = new Vector3(overlapTestBoxSize, overlapTestBoxSize, overlapTestBoxSize);
            Collider[] collidersInsideOverlapBox = new Collider[1];
            int numberOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlapTestBoxScale, collidersInsideOverlapBox, spawnRotation, spawnedObjectLayer);

            if (numberOfCollidersFound == 0)
            {
                Pick(hit.point, spawnRotation);
            }
            else
            {
                _itemAreaSpawner.SpreadItem();
            }
        }
    }

    private void Pick(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        GameObject clone = Instantiate(itemToSpawn, positionToSpawn + new Vector3(0, yOffset, 0), rotationToSpawn);
    }

    public IEnumerator DestroySelf()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            yield return new WaitForSeconds(0.01f);

            Destroy(gameObject);
        } 
    }
}
