using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnmowerScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float volume = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            transform.position += (Vector3.up * volume);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            transform.position += (Vector3.down * volume);
        }
    }
}