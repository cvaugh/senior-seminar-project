using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawnScript : MonoBehaviour
{
    public GameObject grass;
    public float spawnRate = 2;
    public float heightOffset = 20;
    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        spawnGrass();
    }

    // Update is called once per frame
    void Update()
    {
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

    void spawnGrass()
    {
        Instantiate(grass, new Vector3(transform.position.x, Random.Range(250, 270), 0), transform.rotation);
    }

 
}
