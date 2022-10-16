using UnityEngine;
using UnityEngine.UI;

public class DeactivateUltimateClicking : MonoBehaviour
{
    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused && PlayerStats.power >= 100)
        {
            GetComponent<Button>().interactable = true;
        }
        else if(ShowHideMenu.gameIsPaused || PlayerStats.power < 100)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
