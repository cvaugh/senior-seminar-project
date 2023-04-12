using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMoveScript : MonoBehaviour
{
    public float moveSpeed = 3;
    //public float timer = 0f;
    public float deadZone = 265;

    public CountdownTimer countdownScript;

    // Start is called before the first frame update
    void Start()
    {
        //moveSpeed;
        countdownScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<CountdownTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        //timer += 1 * Time.deltaTime;
        print(countdownScript.getGameTime());
        if(countdownScript.getGameTime() <= 30)
        {
            moveSpeed = 5;
        }if(countdownScript.getGameTime() <= 10)
        {
            moveSpeed = 7;
        }
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

}
