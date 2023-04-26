using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float introTime = 0f;
    float startingTime = 3f;
    float gameTime = 60f;

    [SerializeField] Text titleText;
    [SerializeField] Text tutorialParagraph;
    [SerializeField] Button startButton;

    [SerializeField] Text introCountdownText;
    [SerializeField] Text goText;

    [SerializeField] Text gameCountdownText;
    [SerializeField] Text timesUpText;

    [SerializeField] Text pointsText;
    [SerializeField] Text pointNumText;

    [SerializeField] public GameObject lawnmower;
    [SerializeField] public GameObject grassSpawner;
    [SerializeField] public GameObject grass;

    [SerializeField] Text gameOverText;
    [SerializeField] Text goPointsText;
    [SerializeField] Text goPointsNum;

    void Start()
    {
        introTime = startingTime;
        titleText.gameObject.SetActive(false);
        tutorialParagraph.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        gameCountdownText.gameObject.SetActive(false);
        pointsText.gameObject.SetActive(false);
        pointNumText.gameObject.SetActive(false);

        lawnmower.gameObject.SetActive(false);
        grassSpawner.gameObject.SetActive(false);
        grass.gameObject.SetActive(false);

        gameOverText.gameObject.SetActive(false);
        goPointsText.gameObject.SetActive(false);
        goPointsNum.gameObject.SetActive(false);
    }

    void Update()
    {
        introCountdownText.gameObject.SetActive(true);
        introTime -= 1 * Time.deltaTime;
        introCountdownText.text = introTime.ToString("0");
        grassSpawner.gameObject.SetActive(true);
        grass.gameObject.SetActive(true);
        if (introTime <= 1)
        {
            introCountdownText.gameObject.SetActive(false);
            goText.gameObject.SetActive(true);
           

            if (introTime <= 0)
            {
                goText.gameObject.SetActive(false);
                gameCountdownText.gameObject.SetActive(true);
                gameTime -= 1 * Time.deltaTime;
                gameCountdownText.text = gameTime.ToString("0");

                pointsText.gameObject.SetActive(true);
                pointNumText.gameObject.SetActive(true);

                lawnmower.gameObject.SetActive(true);
            }
  
        }
        if (gameTime <= 1)
        {
            gameCountdownText.gameObject.SetActive(false);
            pointsText.gameObject.SetActive(false);
            pointNumText.gameObject.SetActive(false);
            timesUpText.gameObject.SetActive(true);

            lawnmower.gameObject.SetActive(false);
            grassSpawner.gameObject.SetActive(false);
            grass.gameObject.SetActive(false);

           
            gameOverText.gameObject.SetActive(true);
            goPointsText.gameObject.SetActive(true);
            goPointsNum.gameObject.SetActive(true);

            if (gameTime <= 0)
            {
                timesUpText.gameObject.SetActive(false);      
            }
        }

    }

    public float getGameTime()
    {
        return gameTime;
    }

    public float getStartTime()
    {
        return introTime;
    }
}