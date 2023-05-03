using UnityEngine;

public class ChangeScene : MonoBehaviour {
    public void MoveToScene(string scene) {
        GameController.instance.LoadScene(scene);
    }
}
