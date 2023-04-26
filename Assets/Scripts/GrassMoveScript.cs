using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone;

    public CountdownTimer countdownScript;
    public GrassSpawnScript grassSpawnScript;

    // Start is called before the first frame update
    void Start()
    {
        deadZone = -100;
        moveSpeed = 100;
        countdownScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<CountdownTimer>();
        grassSpawnScript = GameObject.FindGameObjectWithTag("Grass").GetComponent<GrassSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if(countdownScript.getGameTime() <= 30)
        {
            moveSpeed = 200;
            grassSpawnScript.setSpawnRate(1);
        }if(countdownScript.getGameTime() <= 10)
        {
            moveSpeed = 400;
            grassSpawnScript.setSpawnRate(0.5);
        }
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

}
