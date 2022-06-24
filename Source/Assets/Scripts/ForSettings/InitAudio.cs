using UnityEngine.Audio;
using UnityEngine;

public class InitAudio : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer audioMixer;
    void Start()
    {
        audioMixer.SetFloat(volumeParameter, PlayerPrefs.GetFloat(volumeParameter, -60f));
        PlayerPrefs.Save();
    }
}
