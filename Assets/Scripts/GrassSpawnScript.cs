using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawnScript : MonoBehaviour
{
    public GameObject grass;
    public float spawnRate = 2;
    public float heightOffset = 20;
    private float timer = 0;
    public CountdownTimer countdownScript;


    // Start is called before the first frame update
    void Start()
    {
        spawnGrass();
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

 
}
