using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform scoreContainer;
    private Transform scoreTemplate;
    private List<HighScoreEntry> highScoreEntryList;

    private void Awake()
    {
        scoreContainer = transform.Find("highScoreTable");
        scoreTemplate = scoreContainer.Find("tableTemplate");

        scoreTemplate.gameObject.SetActive(false);
        /*
        float templateHeight = 30f;
        for (int i = 0; i < 10; i++)
        {
            Transform tableTransform = Instantiate(scoreTemplate, scoreContainer);
            RectTransform tableRectTransform = tableTransform.GetComponent<RectTransform>();
            tableRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            tableTransform.gameObject.SetActive(true);

            int rankPos = i + 1;
            string rankPosString;

            switch (rankPos)
            {
                case 1: rankPosString = "1ST";
                    break;
                case 2:
                    rankPosString = "2ND";
                    break;
                case 3:
                    rankPosString = "3RD";
                    break;

                default:
                    rankPosString = rankPos + "TH";
                    break;
            }
           
            tableTransform.Find("posText").GetComponent<Text>().text = rankPosString;

            int score = Random.Range(0, 1000);
            tableTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

            string name = "ABA";
            tableTransform.Find("nameText").GetComponent<Text>().text = name;

            

        }
        */
    }

    private void CreateHighscoreTableTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform tableTransform = Instantiate(scoreTemplate, container);
        RectTransform tableRectTransform = tableTransform.GetComponent<RectTransform>();
        tableRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        tableTransform.gameObject.SetActive(true);

        int rankPos = transformList.Count + 1;
        string rankPosString;

        switch (rankPos)
        {
            case 1:
                rankPosString = "1ST";
                break;
            case 2:
                rankPosString = "2ND";
                break;
            case 3:
                rankPosString = "3RD";
                break;

            default:
                rankPosString = rankPos + "TH";
                break;
        }

        tableTransform.Find("posText").GetComponent<Text>().text = rankPosString;

        int score = highScoreEntry.score;
        tableTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highScoreEntry.name;
        tableTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(tableTransform);
    }


    private class HighScoreEntry
    {
        public int score;
        public string name;
    }



}
