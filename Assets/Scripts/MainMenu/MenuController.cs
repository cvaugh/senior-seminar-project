using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public Transform trellis;
    public Transform loadingBlocker;
    public float beeRange;
    public float beeForgetRange;
    public float beeSpeed;
    public float beeMaxSpeed;
    public float beeTurnSpeed;
    public Vector2 screenMin;
    public Vector2 screenMax;

    void Start() {
        loadingBlocker.gameObject.SetActive(false);
        RectTransform canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        Vector3 size = new Vector3(canvas.sizeDelta.x / 2, canvas.sizeDelta.y / 2);
        canvas.position = Vector3.zero;
        Debug.Log(canvas.position + " +++ " + canvas.sizeDelta + " +++ " + (canvas.position - size));
        screenMin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        screenMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update() {
        
    }

    public void InitGame() {
        loadingBlocker.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync("Main");
    }
}
