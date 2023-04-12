using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour {
    public string transferTo;

    // Start is called before the first frame update
    void Start() {
        bool found = false;
        for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
            if(Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)) == transferTo) {
                found = true;
                break;
            }
        }
        Assert.IsTrue(found);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            GameController.instance.LoadScene(transferTo);
        }
    }
}

