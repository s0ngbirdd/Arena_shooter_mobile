using UnityEngine;
using UnityEngine.UI;

public class DeactivateAttackClicking : MonoBehaviour
{
    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            GetComponent<Button>().interactable = true;
        }
        else if (ShowHideMenu.gameIsPaused)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
