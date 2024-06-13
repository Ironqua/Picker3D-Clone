using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;


    void Start()
    {
        UISignals.Instance.onScoreText+=OnScoreText;
    }

    private void OnScoreText()
    {
       scoreText.text="SCORE:"+PlayerCollectedCount.Instance.PlayerCollectedBall.ToString();
    }
}
