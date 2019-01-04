using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
     
    //parameters
    [SerializeField] int numBlocks; //serialized for debugging purposes only

    //cached reference
    SceneLoader sceneLoader;
    GameStatus gameStatus;

	// Use this for initialization
	void Start () {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CountBlock(){
        //all blocks count themselves upon Start
        numBlocks++;
    }

    public void DestroyBlock(){
        numBlocks--;
        gameStatus.AddToScore();
        Debug.Log("Num remaining blocks: " + numBlocks.ToString());
        if (numBlocks <= 0){
            sceneLoader.LoadNextScene();
        }
    }
}
