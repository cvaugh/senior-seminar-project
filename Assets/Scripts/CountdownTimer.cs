using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;

    [SerializeField] Text titleText;
    [SerializeField] Text tutorialParagraph;
    [SerializeField] Button startButton;
    [SerializeField] Text countdownText;
    [SerializeField] Text goText;

    void Start()
    {
        currentTime = startingTime;
        titleText.gameObject.SetActive(false);
        tutorialParagraph.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    void Update()
    {
        countdownText.gameObject.SetActive(true);
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if (currentTime <= 1)
        {
            countdownText.gameObject.SetActive(false);
            goText.gameObject.SetActive(true);
            if (currentTime <= 0)
            {
                goText.gameObject.SetActive(false);
            }

        }
    }
}
