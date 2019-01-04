using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {
    //serialized for debugging purposes only
    [SerializeField] int currentScore = 0;
    [SerializeField] int bestScore = 0;
    //Text currentScoreText;
    //Text bestScoreText;

    private void Awake(){
        EnsureSingleton();
    }

    private void EnsureSingleton(){
        if (FindObjectsOfType(GetType()).Length > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame(){
        currentScore = 0;
    }

    public void IncreaseScore(int points){
        currentScore += points;
    }

    public int GetCurrentScore(){
        return currentScore;
    }
    public int GetBestScore(){
        return bestScore;
    }
    // Use this for initialization
    void Start () {
        int width = 500; // or something else
        int height = 900; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        Screen.SetResolution(width, height, isFullScreen);
    }
	
	// Update is called once per frame
	void Update () {
        if (currentScore > bestScore){
            bestScore = currentScore;
        }
    }
}
