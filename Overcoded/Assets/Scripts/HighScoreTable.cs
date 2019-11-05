using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform scoreContainer;
    private Transform scoreTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        scoreContainer = transform.Find("highScoreTable");
        scoreTemplate = scoreContainer.Find("tableTemplate");

        scoreTemplate.gameObject.SetActive(false);

        //AddHighScoreEntry(275833, "JEG");
        //AddHighScoreEntry(2374, "JRE");
        //AddHighScoreEntry(903093, "RTJ");
        //AddHighScoreEntry(48379, "JRW");
        //AddHighScoreEntry(26448, "ADG");

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        
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
        

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highscores.highScoreEntryList)
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

        if (rankPos == 1)
        {
            tableTransform.Find("posText").GetComponent<Text>().color = new Color32(245,214,121,255);
            tableTransform.Find("scoreText").GetComponent<Text>().color = new Color32(245, 214, 121, 255);
            tableTransform.Find("nameText").GetComponent<Text>().color = new Color32(245, 214, 121, 255);
        }

        if (rankPos == 2)
        {
            tableTransform.Find("posText").GetComponent<Text>().color = Color.gray;
            tableTransform.Find("scoreText").GetComponent<Text>().color = Color.gray;
            tableTransform.Find("nameText").GetComponent<Text>().color = Color.gray;
        }

        if (rankPos == 3)
        {
            tableTransform.Find("posText").GetComponent<Text>().color = new Color32(85, 61, 49, 255);
            tableTransform.Find("scoreText").GetComponent<Text>().color = new Color32(85, 61, 49, 255);
            tableTransform.Find("nameText").GetComponent<Text>().color = new Color32(85, 61, 49, 255);
        }

        transformList.Add(tableTransform);
    }

    private void AddHighScoreEntry(int score, string name)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highScoreEntryList.Add(highScoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highScoreTable", json);
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
