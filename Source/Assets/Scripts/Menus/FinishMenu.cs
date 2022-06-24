using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public Text result;
    public GameObject finishMenu;

    float currentTime;
    void Update()
    {
        currentTime += Time.deltaTime;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_menu");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = 0f;
            finishMenu.SetActive(true);

            int sec, min;
            sec = (int)currentTime % 60;
            min = (int)currentTime / 60;
            result.text = min.ToString("D2") + ":" + sec.ToString("D2");


            if(PlayerPrefs.GetInt("score" + SceneManager.GetActiveScene().buildIndex) == 0)
                PlayerPrefs.SetInt("score" + SceneManager.GetActiveScene().buildIndex, 999999999);
            if (PlayerPrefs.GetInt("score" + SceneManager.GetActiveScene().buildIndex) > currentTime)
                PlayerPrefs.SetInt("score" + SceneManager.GetActiveScene().buildIndex, (int)currentTime);

            Debug.Log(PlayerPrefs.GetInt("score1"));
            Debug.Log(PlayerPrefs.GetInt("score2"));
            Debug.Log(PlayerPrefs.GetInt("score3"));
        }
    }
}
