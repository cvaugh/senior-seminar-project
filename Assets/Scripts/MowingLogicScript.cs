using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MowingLogicScript : MonoBehaviour
{
    public float points = 0;
    [SerializeField] Text pointsText;
    public GameObject lawnmower;
    public GameObject grass;
    [SerializeField] Text goPointsText;

    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = points.ToString();
        goPointsText.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Add GrassScore")]
    public void addGrassScore()
    {
        points+= 5;
        pointsText.text = points.ToString();
        goPointsText.text = points.ToString();
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