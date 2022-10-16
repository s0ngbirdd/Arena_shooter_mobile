using UnityEngine;

public class ShowSummaryMenu : MonoBehaviour
{
    // Serialize fields
    [SerializeField] private GameObject _popupMenu;
    [SerializeField] private GameObject _popupMenuButton;

    public void Update()
    {
        if (!_popupMenu.activeSelf && PlayerStats.health <= 0)
        {
            _popupMenu.SetActive(true);
            _popupMenuButton.SetActive(false);

            ShowHideMenu.gameIsPaused = true;
            Time.timeScale = 0.0f;
        }
    }
}
