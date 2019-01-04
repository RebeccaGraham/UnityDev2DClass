using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float sideBuffer = 0.75f;
    float minX;
    float maxX;

    //cached references
    Ball myBall;
    GameStatus myGameStatus;

    // Use this for initialization
	void Start () {
        minX = sideBuffer;
        maxX = screenWidthInUnits - sideBuffer;
        myBall = FindObjectOfType<Ball>();
        myGameStatus = FindObjectOfType<GameStatus>();
	}
	
	// Update is called once per frame
	void Update () {
        //float mousePosXInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXpos(), minX, maxX);
        transform.position = paddlePos;
	}

    private float GetXpos()
    {
        float xPos;
        if (myGameStatus.isAutoPlayEnabled()){
            //make paddle go to ball on autoplay
            xPos = myBall.transform.position.x;
        }
        else {
            xPos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
        return xPos;
    }
}
