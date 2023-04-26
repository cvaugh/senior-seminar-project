using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawnScript : MonoBehaviour
{
    public GameObject grass;
    public double spawnRate;
    public float heightOffset = 20;
    private float timer = 0;
    public CountdownTimer countdownScript;


    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 2;
        Instantiate(grass, new Vector3(1000, Random.Range(0, 1000), 0), transform.rotation);
        Instantiate(grass, new Vector3(1200, Random.Range(0, 1000), 0), transform.rotation);
        Instantiate(grass, new Vector3(1400, Random.Range(0, 1000), 0), transform.rotation);  
        Instantiate(grass, new Vector3(1600, Random.Range(0, 1000), 0), transform.rotation);
        Instantiate(grass, new Vector3(1800, Random.Range(0, 1000), 0), transform.rotation);
        Instantiate(grass, new Vector3(2000, Random.Range(0, 1000), 0), transform.rotation);
        countdownScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<CountdownTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(countdownScript.getStartTime() == 3 || countdownScript.getStartTime() == 2 || countdownScript.getStartTime() == 1)
        {
            spawnGrass();
        }
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnGrass();
            timer = 0;
        }

    }

    public void spawnGrass()
    {
        Instantiate(grass, new Vector3(transform.position.x, Random.Range(0, 1000), 0), transform.rotation);
    }

 
    public void setSpawnRate(double spawn)
    {
        spawnRate = spawn;
    }
}
