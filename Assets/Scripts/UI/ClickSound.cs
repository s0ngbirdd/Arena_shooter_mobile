using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public void SoundOnClick()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("Click");
    }
}
