using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    TextMeshProUGUI scoreTextUI;

    int score;

    public bool isDead;

    public int Score
    {
        get { return this.score; }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    void Start()
    {
        scoreTextUI = GetComponent<TextMeshProUGUI>();
    }

    void UpdateScoreTextUI()
    {
        if (isDead)
        {
            return;
        }
        string scoreStr = string.Format("{0:00000}", score);
        scoreTextUI.text = scoreStr;
    }
}
