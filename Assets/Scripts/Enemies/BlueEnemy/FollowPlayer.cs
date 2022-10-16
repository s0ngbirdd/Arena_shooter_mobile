using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    // Public fields
    public NavMeshAgent agent; // For avoiding obstacles
    public float closeToTarget;

    // Private fields
    private GameObject _target;

    private void Start()
    {
        _target = FindObjectOfType<FPSInput>().gameObject;
    }

    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            float distance = Vector3.Distance(_target.gameObject.transform.position, transform.position);
            if (distance > closeToTarget)
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                agent.SetDestination(_target.transform.position);
            }
            else
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            }
        }    
    }
}
