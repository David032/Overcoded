using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform scoreContainer;
    private Transform scoreTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        scoreContainer = transform.Find("highScoreTable");
        scoreTemplate = scoreContainer.Find("tableTemplate");

        scoreTemplate.gameObject.SetActive(false);


        highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{ score = 239647, name = "ABC" },
            new HighScoreEntry{ score = 87436, name = "EKT" },
            new HighScoreEntry{ score = 6870, name = "HEJ" },
            new HighScoreEntry{ score = 396477, name = "YET" },
            new HighScoreEntry{ score = 9286, name = "DON" },

        };

        for (int i = 0; i < highScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highScoreEntryList.Count; j++)
            {
                if (highScoreEntryList[j].score > highScoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highScoreEntryList[i];
                    highScoreEntryList[i] = highScoreEntryList[j];
                    highScoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
        {
            CreateHighscoreTableTransform(highScoreEntry, scoreContainer, highscoreEntryTransformList);
        }
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
