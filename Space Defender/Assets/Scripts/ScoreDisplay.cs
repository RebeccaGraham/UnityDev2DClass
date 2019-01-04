using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour {
    //cached references
    TextMeshProUGUI score;
    GameSession gameSession;

    // Use this for initialization
	void Start () {
        gameSession = FindObjectOfType<GameSession>();
        score = GetComponent<TextMeshProUGUI>();
        score.text = gameSession.GetCurrentScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (score != null){
            score.text = gameSession.GetCurrentScore().ToString();
        }
    }
}
