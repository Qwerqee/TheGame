using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingSceen;
    public Slider progressBar;
    public void Playlevel_1()
    {
        loadingSceen.SetActive(true);
        StartCoroutine(LoadAsync(1));
    }
    public void Playlevel_2()
    {
        loadingSceen.SetActive(true);
        StartCoroutine(LoadAsync(2));
    }
    public void Playlevel_3()
    {
        loadingSceen.SetActive(true);
        StartCoroutine(LoadAsync(3));
    }

    IEnumerator LoadAsync(int sceneNumber)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNumber);

        while (!asyncLoad.isDone)
        {
            progressBar.value = asyncLoad.progress;
            yield return null;
        }
    }

    public void ExitGame()
    {
        Debug.Log("game ended");
        Application.Quit();
    }
}
