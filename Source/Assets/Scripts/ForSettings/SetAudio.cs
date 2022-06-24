using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SetAudio : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";

    public AudioMixer audioMixer;
    public Slider slider;

    private float volumeValue;
    public void OnSliderTrigger()
    {
        Sounds.sound.jumpSound.Play();
    }
    private void Awake()
    {
        slider.onValueChanged.AddListener(SliderValueChange);
    }

    private void Start()
    {
        volumeValue = PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) * 20f);
        slider.value = Mathf.Pow(10f, volumeValue / 20f);
        PlayerPrefs.Save();
    }

    private void SliderValueChange(float value)
    {
        volumeValue = Mathf.Log10(value) * 20f;
        audioMixer.SetFloat(volumeParameter, volumeValue);
        PlayerPrefs.Save();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, volumeValue);
    }
}
