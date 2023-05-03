using UnityEngine;

public class GrassSpawnScript : MonoBehaviour {
    public GameObject grass;
    public float heightOffset = 20;
    public CountdownTimer countdownScript;
    private double spawnRate = 2.0;
    private float timer = 0.0f;

    void Start() {
        for(int i = 1000; i <= 2000; i += 200) {
            // this won't work as expected for some screen sizes
            Instantiate(grass, new Vector3(i, Random.Range(0, 1000), 0), transform.rotation);
        }
        countdownScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<CountdownTimer>();
    }

    private void FixedUpdate() {
        if(countdownScript.getStartTime() == 3 || countdownScript.getStartTime() == 2 || countdownScript.getStartTime() == 1) {
            SpawnGrass();
        }
        if(timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            SpawnGrass();
            timer = 0;
        }
    }

    public void SpawnGrass() {
        Instantiate(grass, new Vector3(transform.position.x, Random.Range(0, 1000), 0), transform.rotation);
    }

    public void SetSpawnRate(double spawn) {
        spawnRate = spawn;
    }
}
