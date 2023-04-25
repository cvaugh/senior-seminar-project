using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone = 0;

    public CountdownTimer countdownScript;
    public GrassSpawnScript grassSpawnScript;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 100;
        countdownScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<CountdownTimer>();
        grassSpawnScript = GameObject.FindGameObjectWithTag("Grass").GetComponent<GrassSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if(countdownScript.getGameTime() >= 60)
        {
            moveSpeed = 400;
            //grassSpawnScript.spawnGrass();
            
        }
        if(countdownScript.getGameTime() <= 30)
        {
            moveSpeed = 200;
        }if(countdownScript.getGameTime() <= 10)
        {
            moveSpeed = 400;
        }
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

}
