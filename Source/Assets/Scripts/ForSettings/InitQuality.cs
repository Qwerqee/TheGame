using UnityEngine;
using UnityEngine.UI;

public class InitQuality : MonoBehaviour
{
    public string qualityParameter = "QualityLevel";
    public Dropdown dropdown;
    void Start()
    {
        dropdown.value = PlayerPrefs.GetInt(qualityParameter, 5);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt(qualityParameter, 5));
    }
}
