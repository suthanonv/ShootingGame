using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowScore : MonoBehaviour
{
    public Score score;
    public Text scoretext;
    public Text HighScoretext;

    private void Start()
    {
        scoretext.text = "Score : " + score.Scores.ToString();
       
       if ( PlayerPrefs.GetInt("HighScore") < score.Scores)
        {
            PlayerPrefs.SetInt("HighScore", score.Scores);
            HighScoretext.text = "Hight Score : " +PlayerPrefs.GetInt("HighScore").ToString();
        }
       else
        {
            HighScoretext.text = "Hight Score : " + PlayerPrefs.GetInt("HighScore").ToString();
        }

        score.Scores = 0;
    }
}
