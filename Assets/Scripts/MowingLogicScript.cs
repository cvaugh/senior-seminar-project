using UnityEngine;
using UnityEngine.UI;

public class MowingLogicScript : MonoBehaviour {
    public float points = 0;
    [SerializeField] Text pointsText;
    public GameObject lawnmower;
    public GameObject grass;
    [SerializeField] Text goPointsText;

    void Start() {
        pointsText.text = points.ToString();
        goPointsText.text = points.ToString();
    }

    [ContextMenu("Add GrassScore")]
    public void addGrassScore() {
        points+= 5;
        pointsText.text = points.ToString();
        goPointsText.text = points.ToString();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Grass")) {
            Destroy(other.gameObject);
            addGrassScore();
        }
    }
}
