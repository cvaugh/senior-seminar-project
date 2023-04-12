using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float timer = 0f;
    public float deadZone = 265;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        timer += 1 * Time.deltaTime;
        if(timer >= 30)
        {
            moveSpeed = 5;
        }if(timer >= 50)
        {
            moveSpeed = 7;
        }
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

}
