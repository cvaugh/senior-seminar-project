using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;

    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        "1a7d1ebdd0d15db1929ffd2574aa733f45acd216b79cf18c471e88f00882fbc7";


    public StatsManager statScript;
    public Text currScoreText;



    private void Start()
    {
        GetLeaderBoard();
        statScript = GameObject.FindGameObjectWithTag("StatusBar").GetComponent<StatsManager>();
    }

    void Update()
    {
        currScoreText.text = statScript.getPlayerCoins().ToString();

    }


    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) => {
           // username.Substring(0, 6);
            GetLeaderBoard();
        }));
    }
}
