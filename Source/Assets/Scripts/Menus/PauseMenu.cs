using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseGameMenu;

    bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (isPaused) Resume();
            else Pause();
    }

    public void Resume()
    {
        Sounds.sound.pauseMenuMusic.Stop();
        Sounds.sound.backgroundMusic.UnPause();
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        Sounds.sound.backgroundMusic.Pause();
        Sounds.sound.pauseMenuMusic.Play();
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_menu");
    }
}
