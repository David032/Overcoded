using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHHighScore : MonoBehaviour
{
    private FeatureGeneration featureScript;

    private Transform scoreContainer;
    private Transform scoreTemplate;
    GameObject manager;
    FeatureGeneration managerGenerator;
    public float playerScore;




    private void Awake()
    {
        scoreContainer = transform.Find("highScoreTable");
        scoreTemplate = scoreContainer.Find("scoreTemplate");

        manager = GameObject.FindGameObjectWithTag("GameController");
        managerGenerator = manager.GetComponent<FeatureGeneration>();
        //featureScript = GetComponent<FeatureGeneration>();
        //playerScore = featureScript.totalScore;

        CreateHighScore(scoreContainer);

    }

    private void CreateHighScore(Transform container)
    {
        Transform scoreTransform = Instantiate(scoreTemplate, container);
        scoreTransform.gameObject.SetActive(true);

        int score = (int) managerGenerator.totalScore;
        scoreTransform.Find("finalScoreText").GetComponent<Text>().text = score.ToString();
    }


}
