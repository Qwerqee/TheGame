using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RecordLoad : MonoBehaviour
{
    public Text bestTime;
    public int sceneNumber;

    void Start()
    {
        int time = PlayerPrefs.GetInt("score" + sceneNumber);
        int sec, min;
        sec = time % 60;
        min = time / 60;
        if (time != 999999999) bestTime.text = min.ToString("D2") + ":" + sec.ToString("D2");
    }
}
