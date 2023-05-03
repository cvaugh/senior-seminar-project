using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {
    [SerializeField]
    private List<TextMeshProUGUI> names;

    [SerializeField]
    private List<TextMeshProUGUI> scores;

    public StatsManager statScript;
    public Text currScoreText;

    void Start() {
        statScript = GameObject.FindGameObjectWithTag("StatusBar").GetComponent<StatsManager>();
    }

    void Update() {
        currScoreText.text = statScript.getPlayerCoins().ToString();
    }

    public void GetLeaderboard() {
        LeaderboardCreator.GetLeaderboard(LeaderboardManager.publicLeaderboardKey, (msg) => {
            for(int i = 0; i < names.Count; i++) {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        });
    }

    public void SetLeaderboardEntry(string username, int score) {
        score = statScript.getPlayerCoins();
        currScoreText.text = score.ToString();
        LeaderboardCreator.UploadNewEntry(LeaderboardManager.publicLeaderboardKey, username, score, (msg) => {
            GetLeaderboard();
        });
    }
}
