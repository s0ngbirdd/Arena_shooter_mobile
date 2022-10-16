using UnityEngine;
using UnityEngine.UI;

public class AimChangeColor : MonoBehaviour
{
    // Check that enemies are on the aim
    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            GetComponent<Image>().color = Color.white;

            Ray ray = FindObjectOfType<MainCamera>().GetComponent<Camera>().ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.black);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.tag == "Enemy" || hit.collider.gameObject.tag == "EnemyBullet")
                {
                    GetComponent<Image>().color = Color.red;
                }
            }
        }
    }
}
