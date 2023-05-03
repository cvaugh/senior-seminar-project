using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour {
    public static LoadingManager instance;

    public GameObject loadingPanel;
    public float minLoadTime;

    public GameObject loadingWheel;
    public float wheelSpeed;

    private string targetScene;
    private bool isLoading;

    public Image fadeImage;
    public float fadeTime;

    public Text currentFact;

    string[] facts = {
        "The world's tallest tree is the coast redwood", 
        "Bamboo is the fastest growing woody plant in the world", 
        "Small pockets of air inside cranberries cause them to float in water", 
        "Iris means 'rainbow' in Greek", 
        "Trees are the longest-living organisms on Earth",
        "Banana is an Arabic word for fingers",
        "Oak trees do not produce acorns until they are 50 years old",
        "More than 85% of plant life is found in the ocean"};

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        loadingPanel.SetActive(false);
        fadeImage.gameObject.SetActive(false);
        
    }

    public void LoadScene(string sceneName) {
        targetScene = sceneName;
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine() {
        isLoading = true;

        fadeImage.gameObject.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0);
        currentFact.gameObject.SetActive(true);

        while(!Fade(1)) {
            yield return null;
        }

        loadingPanel.SetActive(true);
        StartCoroutine(SpinWheelRoutine());

        currentFact.text = facts[Random.Range(0, facts.Length)];

        while (!Fade(0)) {
            yield return null;
        }

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        float elapsedTime = 0f;

        while(!op.isDone) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        while(elapsedTime < minLoadTime) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        while(!Fade(1)) {
            yield return null;
        }

        currentFact.gameObject.SetActive(false);
        loadingPanel.SetActive(false);

        while(!Fade(0)) {
            yield return null;
        }

        isLoading = false;
    }

    private bool Fade(float target) {
        fadeImage.CrossFadeAlpha(target, fadeTime, true);
        if(Mathf.Abs(fadeImage.canvasRenderer.GetAlpha() - target) <= 0.05f) {
            fadeImage.canvasRenderer.SetAlpha(target);
            return true;
        }

        return false;
    }

    private IEnumerator SpinWheelRoutine() {
        while(isLoading) {
            loadingWheel.transform.Rotate(0, 0, -wheelSpeed);
            yield return null;
        }
    }
}
