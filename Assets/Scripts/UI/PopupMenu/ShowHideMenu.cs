using UnityEngine;

public class ShowHideMenu : MonoBehaviour
{
    // Public fields
    public static bool gameIsPaused;

    // Serialize fields
    [SerializeField] private GameObject _popupMenu;
    [SerializeField] private GameObject _popupMenuButton;

    public void OnClick()
    {
        if (!_popupMenu.activeSelf && _popupMenuButton.activeSelf)
        {
            _popupMenu.SetActive(true);
            _popupMenuButton.SetActive(false);

            gameIsPaused = true;
            Time.timeScale = 0.0f;
        }

        else if (_popupMenu.activeSelf && !_popupMenuButton.activeSelf)
        {
            _popupMenu.SetActive(false);
            _popupMenuButton.SetActive(true);

            gameIsPaused = false;
            Time.timeScale = 1.0f;
        }
    }
}
