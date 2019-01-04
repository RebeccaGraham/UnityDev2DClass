using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestScoreDisplay : MonoBehaviour {

    TextMeshProUGUI bestScore;

    //cached references
    GameSession gameSession;

    // Use this for initialization
	void Start () {
        gameSession = FindObjectOfType<GameSession>();
        bestScore = GetComponent<TextMeshProUGUI>();
        bestScore.text = gameSession.GetBestScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
        //if (bestScore != null){
        //    bestScore.text = gameSession.GetBestScore().ToString();
        //}

    }
}
