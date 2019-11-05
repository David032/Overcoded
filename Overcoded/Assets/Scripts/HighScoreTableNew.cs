using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTableNew : MonoBehaviour
{
    private Transform scoreContainer;
    private Transform scoreTemplate;
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        scoreContainer = transform.Find("highScoreTable");
        scoreTemplate = scoreContainer.Find("tableTemplate");

        scoreTemplate.gameObject.SetActive(false);

        //highScoreEntryList = new List<HighScoreEntry>()
        //{
        //    new HighScoreEntry{ score = 267432, name = "AGN"},
        //    new HighScoreEntry{ score = 7634, name = "GEH"},
        //    new HighScoreEntry{ score = 75254, name = "SDB"},
        //    new HighScoreEntry{ score = 89286, name = "ERJ"},
        //    new HighScoreEntry{ score = 29612, name = "JSD"},
        //    new HighScoreEntry{ score = 90386, name = "FGW"},
        //};

        //AddHighScoreEntry(929526, "TUT");

        string jsonstring = PlayerPrefs.GetString("highscore");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonstring);

        //List Sorter

        for (int i = 0; i < highscores.highScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highScoreEntryList.Count; j++)
            {
                if (highscores.highScoreEntryList[j].score > highscores.highScoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscores.highScoreEntryList[i];
                    highscores.highScoreEntryList[i] = highscores.highScoreEntryList[j];
                    highscores.highScoreEntryList[j] = tmp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highscores.highScoreEntryList)
        {
            CreateHighscoreTableTransform(highScoreEntry, scoreContainer, highScoreEntryTransformList);
        }

        //Debug.Log(PlayerPrefs.GetString("highscore"));


    }

    private void CreateHighscoreTableTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30.0f;
        Transform tableTransform = Instantiate(scoreTemplate, container);
        RectTransform tableRectTransform = tableTransform.GetComponent<RectTransform>();
        tableRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        tableTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            case 1:
                rankString = "1ST";
                break;

            case 2:
                rankString = "2ND";
                break;

            case 3:
                rankString = "3RD";
                break;

            default:
                rankString = rank + "TH";
                break;
        }

        tableTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highScoreEntry.score;

        tableTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highScoreEntry.name;

        tableTransform.Find("nameText").GetComponent<Text>().text = name;

        if (rank == 1)
        {
            tableTransform.Find("posText").GetComponent<Text>().color = new Color32(245, 214, 121, 255);
            tableTransform.Find("scoreText").GetComponent<Text>().color = new Color32(245, 214, 121, 255);
            tableTransform.Find("nameText").GetComponent<Text>().color = new Color32(245, 214, 121, 255);
        }

        if (rank == 2)
        {
            tableTransform.Find("posText").GetComponent<Text>().color = Color.gray;
            tableTransform.Find("scoreText").GetComponent<Text>().color = Color.gray;
            tableTransform.Find("nameText").GetComponent<Text>().color = Color.gray;
        }

        if (rank == 3)
        {
            tableTransform.Find("posText").GetComponent<Text>().color = new Color32(85, 61, 49, 255);
            tableTransform.Find("scoreText").GetComponent<Text>().color = new Color32(85, 61, 49, 255);
            tableTransform.Find("nameText").GetComponent<Text>().color = new Color32(85, 61, 49, 255);
        }

        transformList.Add(tableTransform);
    }

    private void AddHighScoreEntry(int score , string name)
    {
        //create highscore entries
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        //load saved scores
        string jsonstring = PlayerPrefs.GetString("highscore");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonstring);

        //add new scores
        highscores.highScoreEntryList.Add(highScoreEntry);

        //save scores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscore", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighScoreEntry> highScoreEntryList;

    }


    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
