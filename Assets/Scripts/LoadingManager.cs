using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;

   // public GameObject mainManager;

    public GameObject LoadingPanel;
    public float minLoadTime;

    public GameObject loadingWheel;
    public float wheelSpeed;

    private string targetScene;
    private bool isLoading;

 // public Image fadeImage;
  //public float fadeTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //mainManager.SetActive(false);
        LoadingPanel.SetActive(false);
        //fadeImage.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        targetScene = sceneName;
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        isLoading = true;

        //fadeImage.gameObject.SetActive(true);
        //fadeImage.canvasRenderer.SetAlpha(0);

    /*  while (!Fade(1))
        {
            yield return null;
        }
    */
        LoadingPanel.SetActive(true);
        StartCoroutine(SpinWheelRoutine());

        /*
        while (!Fade(0))
        {
            yield return null;
        }

        */

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        float elapsedTime = 0f;

        while (!op.isDone)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        while (elapsedTime < minLoadTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        /*
        while (!Fade(1))
        {
            yield return null;
        }
        */

        LoadingPanel.SetActive(false);

        /*
        while (!Fade(0))
        {
            yield return null;
        }
        */

        isLoading = false;
    }

   /* 
    * private bool Fade(float target)
    {
        fadeImage.CrossFadeAlpha(target, fadeTime, true);
        if (Mathf.Abs(fadeImage.canvasRenderer.GetAlpha() - target) <= 0.05f)
        {
            fadeImage.canvasRenderer.SetAlpha(target);
            return true;
        }

        return false;
    }
   */

    private IEnumerator SpinWheelRoutine()
    {
        while (isLoading)
        {
            loadingWheel.transform.Rotate(0, 0, -wheelSpeed);
            yield return null;
        }
    }
}
