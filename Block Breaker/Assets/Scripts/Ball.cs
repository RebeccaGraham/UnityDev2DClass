﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomPathFactor = 0.5f;


    // state
    bool hasStarted = false;
    Vector2 paddleToBallVector;

    // cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

	// Use this for initialization
	void Start () {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update (){
        if(!hasStarted){
            LockToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick(){
        if(Input.GetMouseButtonDown(0)){
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockToPaddle() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, 
                                        paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (hasStarted){
            //Vector2 velocityTweak = new Vector2(myRigidBody2D.velocity.x + UnityEngine.Random.Range(0, randomPathFactor), myRigidBody2D.velocity.y + UnityEngine.Random.Range(0, randomPathFactor));

            Vector2 velocityTweak = new Vector2(
                UnityEngine.Random.Range(0, randomPathFactor), 
                UnityEngine.Random.Range(0, randomPathFactor)
                );
            myRigidBody2D.velocity += velocityTweak;
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
