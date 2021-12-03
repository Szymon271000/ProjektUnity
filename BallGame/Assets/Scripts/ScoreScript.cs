using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text highScoreText;
    public static ScoreScript current;


    private void Awake()
    {
        if (current == null)
        {
            current = this;
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            score++;
        }
    }

    public void CheckHighScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
            
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
    }
}
