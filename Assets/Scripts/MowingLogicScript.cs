using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowingLogicScript : MonoBehaviour
{
    public float points;
    public GameObject lawnmower;
    public GameObject grass;


    // Start is called before the first frame update
    void Start()
    {
        points = 0;
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

    
}