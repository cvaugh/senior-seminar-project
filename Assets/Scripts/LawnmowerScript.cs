using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnmowerScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            transform.position += Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            transform.position += Vector3.down;
        }
    }
}