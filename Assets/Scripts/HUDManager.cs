using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.SCORE_UPDATED, OnScoreUpdated);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.SCORE_UPDATED, OnScoreUpdated);
    }

    private void Start()
    {
        recordText.text = "Record: " + GameManager.recordScore;
        scoreText.text = "Score: 0";
    }

    private void OnScoreUpdated()
    {
        scoreText.text = "Score: " + gameManager.currentScore;
    }
}
