using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float timeRemaining = 60f;
    public int winScore = 25;

    // ui text display win or not
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI resultText;

    private bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            return;
        }

        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndGame(false);
        }

        UpdateUI();

        if(score >= winScore)
        {
            EndGame(true);
        }
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            Instance = this;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining);
    }

    void EndGame(bool won)
    {
        gameOver = true;
        if (won)
        {
            resultText.text = "YOU WIN!";
        }
        else 
        {
            resultText.text = "Time's up. YOU LOSE!";
        }
    }
}
