using UnityEngine;

public class GrassMoveScript : MonoBehaviour {
    private float moveSpeed = 100.0f;
    private float deadZone = -100.0f;

    public CountdownTimer countdownScript;
    public GrassSpawnScript grassSpawnScript;

    void Start() {
        countdownScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<CountdownTimer>();
        grassSpawnScript = GameObject.FindGameObjectWithTag("Grass").GetComponent<GrassSpawnScript>();
    }

    private void FixedUpdate() {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        if(countdownScript.getGameTime() <= 30) {
            moveSpeed = 200;
            grassSpawnScript.SetSpawnRate(1);
        } else if(countdownScript.getGameTime() <= 10) {
            moveSpeed = 400;
            grassSpawnScript.SetSpawnRate(0.5);
        }
        if(transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }
}
