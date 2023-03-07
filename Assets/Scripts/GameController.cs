using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public float globalGrowthRate = 5.0f;
    public SceneStartPoint[] sceneStartPoints;
    public Transform loadingBlocker;

    [HideInInspector]
    public PlayerController player;
    [HideInInspector]
    public Transform canvas;

    void Awake() {
        ItemRegistry.Init();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        canvas = GameObject.Find("Canvas").transform;
    }

    void Start() {
        if(SceneData.currentScene != null) {
            foreach(SceneStartPoint ssp in sceneStartPoints) {
                if(ssp.fromScene == SceneData.currentScene) {
                    player.transform.position = ssp.point.position;
                    player.transform.rotation = ssp.point.rotation;
                }
            }
        }
        SceneData.currentScene = SceneManager.GetActiveScene().name;
        loadingBlocker.gameObject.SetActive(false);
    }

    void Update() {

    }

    public void LoadScene(string scene) {
        loadingBlocker.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync(scene);
    }
}

