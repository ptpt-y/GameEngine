using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameShowScore : MonoBehaviour
{
    public static int coinsScore;
    public static float timeScore;
    public static string levelName;

    public GameObject coinsScoreText;
    public GameObject timeScoreText;
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "WinScene")
        {
            coinsScoreText.GetComponent<TMP_Text>().text = coinsScore.ToString();
            timeScoreText.GetComponent<TMP_Text>().text = timeScore.ToString();
        }
        if(SceneManager.GetActiveScene().name == "LoseScene")
        {
            coinsScoreText.GetComponent<TMP_Text>().text = coinsScore.ToString();
        }
    }
    public void SetScore(int c, float t)
    {
        coinsScore = c;
        timeScore = t;
    }
    public static string GetLevelName()
    {
        return levelName;
    }
    public static void SetLevelName(string s)
    {
        levelName = s;
    }
}
