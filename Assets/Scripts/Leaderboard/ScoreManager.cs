using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    //[SerializeField]
    //private TextMeshProUGUI inputScore;

    public Text inputScore;

    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;
    public LeaderboardManager lbManScript;

    void Start() {
        lbManScript = GameObject.FindGameObjectWithTag("Leaderboard").GetComponent<LeaderboardManager>();
    }

    public void SubmitScore() {
        //submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
        lbManScript.SetLeaderboardEntry(inputName.text, int.Parse(inputScore.text));
    }
}
