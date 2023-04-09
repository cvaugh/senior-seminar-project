using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float introTime = 0f;
    float startingTime = 3f;
    float gameTime = 10f;

    [SerializeField] Text titleText;
    [SerializeField] Text tutorialParagraph;
    [SerializeField] Button startButton;

    [SerializeField] Text introCountdownText;
    [SerializeField] Text goText;

    [SerializeField] Text gameCountdownText;
    [SerializeField] Text timesUpText;

    void Start()
    {
        introTime = startingTime;
        titleText.gameObject.SetActive(false);
        tutorialParagraph.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        gameCountdownText.gameObject.SetActive(false);
    }

    void Update()
    {
        introCountdownText.gameObject.SetActive(true);
        introTime -= 1 * Time.deltaTime;
        introCountdownText.text = introTime.ToString("0");
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
            }

            if (gameTime <= 1)
            {
                gameCountdownText.gameObject.SetActive(false);
                timesUpText.gameObject.SetActive(true);

                if(gameTime <= 0)
                {
                    timesUpText.gameObject.SetActive(false);
                }
            }
        }
        
    }
}
