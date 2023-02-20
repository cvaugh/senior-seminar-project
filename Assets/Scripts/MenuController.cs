using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public Transform trellis;
    public Transform loadingBlocker;

    void Start() {
        loadingBlocker.gameObject.SetActive(false);
    }

    public void InitGame() {
        loadingBlocker.gameObject.SetActive(true);
        // todo: load last save
        SceneManager.LoadSceneAsync("BasementTutorial");
    }
}
