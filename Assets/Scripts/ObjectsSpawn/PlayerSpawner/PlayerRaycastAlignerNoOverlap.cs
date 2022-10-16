using System.Collections;
using UnityEngine;

public class PlayerRaycastAlignerNoOverlap : MonoBehaviour
{
    // Public fields
    public float yOffset = 0.1f;
    public float raycastDistance = 100f;
    public float overlapTestBoxSize = 1f;
    public LayerMask spawnedObjectLayer;

    // Private fields
    private PlayerItemAreaSpawner _itemAreaSpawner;
    private GameObject _player;

    private void Start()
    {
        _player = FindObjectOfType<FPSInput>().gameObject;
        _itemAreaSpawner = FindObjectOfType<PlayerItemAreaSpawner>();

        PositionRaycast();
        StartCoroutine(DestroySelf());
    }

    // Find position without overlapping
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
        FindObjectOfType<AudioManager>().PlayOneShot("PlayerTeleport");
        _player.GetComponent<CharacterController>().enabled = false;
        _player.GetComponent<CharacterController>().transform.position = positionToSpawn;
        _player.GetComponent<CharacterController>().transform.rotation = rotationToSpawn;
        _player.GetComponent<CharacterController>().enabled = true;
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
