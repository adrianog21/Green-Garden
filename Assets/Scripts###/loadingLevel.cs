using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingLevel : MonoBehaviour
{
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // per saperel'index  della scena
        if (currentSceneIndex == 0)
        {
            StartCoroutine(Loading());
        }
    }
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(2f);
        LoadNextScene();
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadOptionScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("4.Options");
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
