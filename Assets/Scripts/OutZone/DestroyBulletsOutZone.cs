using UnityEngine;

public class DestroyBulletsOutZone : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            if (other.gameObject.tag == "PlayerBullet" || other.gameObject.tag == "EnemyBullet")
            {
                Destroy(other.gameObject);
            }
        }  
    }
}
