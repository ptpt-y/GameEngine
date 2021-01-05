using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public static int scoreNum;
    public int TopNum = 5;
    public class ScoreData
    {
        public string SceneName;
        public int CoinScore;
        public float TimeScore;
        public string RecordTime;
    }

    public void Start()
    {
        scoreNum = 0;
    }

    public void Update()
    {
        scoreText.GetComponent<TMP_Text>().text = scoreNum.ToString();
    }

    public static void SetStaticScoreNum(int i)
    {
        scoreNum = i;
    }
    public int GetStaticScoreNum()
    {
        return scoreNum;
    }
    public void PassScore(int c, float t)
    {
        transform.GetComponent<EndGameShowScore>().SetScore(c, t);
        EndGameShowScore.SetLevelName(SceneManager.GetActiveScene().name);
    }
    public void UpdateScoreBoard()
    {
        string curGameScore = PlayerPrefs.GetString("curGame");
        ScoreData curScoreData = GetScoreData(curGameScore);
        string levelBoard = curScoreData.SceneName;

        ScoreData[] board = new ScoreData[10];
        int curBoardCount = 0;

        for (int i = 0; i < TopNum; i++)
        {
            string savedScoreKey = levelBoard + i.ToString();
            string temp = PlayerPrefs.GetString(savedScoreKey, "");
            Debug.Log("【" + savedScoreKey + "】: " + temp);
            if (temp=="")
            {
                curBoardCount = i;
                break;
            }
            else
            {
                board[i] = GetScoreData(temp);
                curBoardCount++;
            }
        }
        Debug.Log("【" + levelBoard + "Top" + TopNum + "排行榜】(" + curBoardCount + ")");
        // sort
        if (curBoardCount == 0)
        {
            string s = levelBoard + "0";
            //Debug.Log("SaveKey:" + s);
            PlayerPrefs.SetString(s, curGameScore);
        }
        else
        {
            int i;
            for (i = curBoardCount - 1; i >= 0; i--)
            {
                if(curScoreData.TimeScore > board[i].TimeScore)
                {
                    if (i + 1 <= TopNum)
                        Resave(curGameScore, i + 1, levelBoard, curBoardCount);
                    break;
                }
                else if (curScoreData.TimeScore == board[i].TimeScore)
                {
                    if (curScoreData.CoinScore == board[i].CoinScore)
                    {
                        if (string.Compare(curScoreData.RecordTime, board[i].RecordTime, true) >= 0)
                        {
                            if (i + 1 <= TopNum)
                                Resave(curGameScore, i + 1, levelBoard, curBoardCount);
                            break;
                        }
                    }
                    else if(curScoreData.CoinScore < board[i].CoinScore)
                    {
                        if (i + 1 <= TopNum)
                            Resave(curGameScore, i+1, levelBoard, curBoardCount);
                        break;
                    }
                }
            }
            if (i == -1)
            {
                Resave(curGameScore, 0, levelBoard, curBoardCount);
            }
        }
    }

    public void Resave(string cur,int k,string level,int n)
    {
        string key1;
        string key2;
        string s;
        string s2;
        if (k == n)
        {
            key1 = level + k.ToString();
            Debug.Log("SaveKey:" + key1);
            PlayerPrefs.SetString(key1, cur);
        }
        else
        {
            //for(int i = n-1; i >= k; i--)
            //{
            //    key1 = level + i.ToString();
            //    key2 = level + (i+1).ToString();
            //    s = PlayerPrefs.GetString(key1);
            //    PlayerPrefs.SetString(key2, s);
            //    if (i == k)
            //    {
            //        PlayerPrefs.SetString(key1, cur);
            //    }
            //}
            s = cur;
            if (n == TopNum) n--;
            for(int i = k; i <= n; i++)
            {
                key1 = level + i.ToString();
                s2 = PlayerPrefs.GetString(key1);
                PlayerPrefs.SetString(key1, s);
                s = s2;
            }
        }
    }

    public ScoreData GetScoreData(string s)
    {
        ScoreData cur = new ScoreData();
        string[] temp = s.Split('#');
        cur.SceneName = temp[0];
        cur.TimeScore = float.Parse(temp[1]);
        cur.CoinScore = int.Parse(temp[2]);
        cur.RecordTime = temp[3];
        //Debug.Log(cur.SceneName + " " + cur.TimeScore + " " + cur.CoinScore + " " + cur.RecordTime);
        return cur;
    }
}
