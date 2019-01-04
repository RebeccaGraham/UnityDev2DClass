using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameStatus : MonoBehaviour {

    //config parameters
    [Range(0.01f, 10f)][SerializeField] float gameSpeed;
    [SerializeField] int pointsPerBlockDestroyed = 12;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool autoplayOn;

    //state variables
    int currentScore = 0;

    private void Awake(){
        //singelton pattern
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start(){
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
    }

    internal bool isAutoPlayEnabled(){
        return autoplayOn;
    }

    public void Reset(){
        Destroy(gameObject);
    }

    public void AddToScore(){
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

}
