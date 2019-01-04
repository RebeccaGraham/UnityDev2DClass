using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] float gameOverDelay = 3f;

    GameSession gameSession;

	// Use this for initialization
	void Start () {
        gameSession = FindObjectOfType<GameSession>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator WaitAndLoad(){
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene("Game Over");
    }

    public void LoadGameOverScene(){
        StartCoroutine(WaitAndLoad());
    }

    public void LoadGameScene(){
        SceneManager.LoadScene("Game");
        gameSession.ResetGame();
    }

    public void LoadMenuScene(){
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame(){
        Application.Quit(); 
    }
}
