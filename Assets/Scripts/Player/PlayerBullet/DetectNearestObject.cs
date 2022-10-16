using UnityEngine;

public class DetectNearestObject : MonoBehaviour
{
    // Public fields
    public static GameObject nearestObject;
    public string objectTag = "Enemy";
    public GameObject[] allObjects;

    private void Start()
    {
        allObjects = GameObject.FindGameObjectsWithTag(objectTag);
    }

    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            allObjects = GameObject.FindGameObjectsWithTag(objectTag);
            nearestObject = NearestObject();
        }
    }

    // Find nearest object
    private GameObject NearestObject()
    {
        GameObject nearestObj = gameObject;
        float leastDistance = Mathf.Infinity;

        foreach (var obj in allObjects)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if(distance < leastDistance)
            {
                leastDistance = distance;
                nearestObj = obj;
            }
        }

        return nearestObj;
    }
}
