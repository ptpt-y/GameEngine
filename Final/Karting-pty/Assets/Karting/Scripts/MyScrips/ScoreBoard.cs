using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public GameObject LevelName;
    TimeManager timeManager;
    public int TopNum = 5;
    public GameObject conText;
    public GameObject sorryText;
    public GameObject[] Records = new GameObject[5];
    public class ScoreData
    {
        public string SceneName;
        public int CoinScore;
        public float TimeScore;
        public string RecordTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        ShowScoreBoard();
    }

    public void ShowScoreBoard()
    {
        string curGameScore = PlayerPrefs.GetString("curGame");
        ScoreData curScoreData = GetScoreData(curGameScore);
        string levelBoard = curScoreData.SceneName;
        bool flag = false;

        if(levelBoard == "MainScene")
            LevelName.GetComponent<TMP_Text>().text = "LEVEL 1";
        else if (levelBoard == "Level2Scene")
            LevelName.GetComponent<TMP_Text>().text = "LEVEL 2";
        else if (levelBoard == "Level3Scene")
            LevelName.GetComponent<TMP_Text>().text = "LEVEL 3";
        ScoreData reordData;
        Debug.Log("====【" + levelBoard + "】====");
        for (int i = 0; i < TopNum; i++)
        {
            string savedScoreKey = levelBoard + i.ToString();
            string temp = PlayerPrefs.GetString(savedScoreKey, "");
            if (temp == "") break;
            else
            {
                reordData = GetScoreData(temp);
                if (temp == curGameScore)
                {
                    Records[i].transform.GetChild(1).GetComponent<TMP_Text>().text = "<color=#E7AF22>" + "NO." + (i + 1).ToString() + "</color>";
                    Records[i].transform.GetChild(2).GetComponent<TMP_Text>().text = "<color=#E7AF22>" + reordData.TimeScore.ToString() + "</color>";
                    Records[i].transform.GetChild(3).GetComponent<TMP_Text>().text = "<color=#E7AF22>" + reordData.CoinScore.ToString() + "</color>";
                    Records[i].transform.GetChild(4).GetComponent<TMP_Text>().text = "<color=#E7AF22>" + reordData.RecordTime + "</color>";
                    flag = true;
                }
                else
                {
                    Records[i].transform.GetChild(2).GetComponent<TMP_Text>().text = reordData.TimeScore.ToString();
                    Records[i].transform.GetChild(3).GetComponent<TMP_Text>().text = reordData.CoinScore.ToString();
                    Records[i].transform.GetChild(4).GetComponent<TMP_Text>().text = reordData.RecordTime;
                }
                Records[i].SetActive(true);
                Debug.Log("【NO." + (i + 1) + "】" + temp);
            }
        }
        if (flag)
        {
            conText.SetActive(true);
        }
        else
        {
            sorryText.SetActive(true);
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
