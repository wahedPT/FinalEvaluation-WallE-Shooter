using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;


   
    public Text sooretext;
    public Text highScoreText;
    public Text infoText;

    private void Awake()
    {
        instance = this;
    }

    int score = 0;
    int highScore = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);

        sooretext.text = " SCORE: " + score.ToString();
        highScoreText.text = " HIGHSCORE:  " + highScore.ToString();
        infoText.text= "kill All the enemies and Glowing object to Win the Game";

    }

    public void AddScore()
    {
        score += 1;
        sooretext.text = " SCORE: " + score.ToString();

        if(highScore<score)
        PlayerPrefs.SetInt("highScore", score);
    }

    private void Update()
    {
        Destroy(infoText, 2f);
    }
}
