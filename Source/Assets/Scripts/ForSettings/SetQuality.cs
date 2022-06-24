using UnityEngine.UI;
using UnityEngine;

public class SetQuality : MonoBehaviour
{
    public string qualityParameter = "QualityLevel";

    public Dropdown dropdown; 

    private int qIndex;

    private void Awake()
    {
        dropdown.onValueChanged.AddListener(DropdownValueChange);
    }

    void Start()
    {
        dropdown.value = QualitySettings.GetQualityLevel();
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt(qualityParameter, 5));
    }

    private void DropdownValueChange(int value)
    {
        qIndex = value;
        QualitySettings.SetQualityLevel(value);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(qualityParameter, qIndex);
    }
}
