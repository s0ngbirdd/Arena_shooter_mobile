using UnityEngine;

public class ChangeMasterVolume : MonoBehaviour
{
    public void ChangeVolume(float volume)
    {
        AudioManager.masterVolume = volume;
    }
}
