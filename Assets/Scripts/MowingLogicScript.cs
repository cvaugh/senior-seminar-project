using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowingLogicScript : MonoBehaviour
{
    public float points = 0;
    public GameObject lawnmower;
    public GameObject grass;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Add GrassScore")]
    public void addGrassScore()
    {
        points+= 5;
    }

      void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            Destroy(other.gameObject);
            addGrassScore();
        }
    }
}