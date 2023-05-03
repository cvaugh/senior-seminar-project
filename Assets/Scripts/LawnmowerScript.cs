using UnityEngine;

public class LawnmowerScript : MonoBehaviour {
    public float speed;

    private void FixedUpdate() {
        if(Input.GetKey(KeyCode.UpArrow)) {
            transform.position += Vector3.up * speed;
        }
        if(Input.GetKey(KeyCode.DownArrow)) {
            transform.position += Vector3.down * speed;
        }
    }
}
