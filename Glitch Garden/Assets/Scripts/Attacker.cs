using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour{
    float currentSpeed = 2f;

    void Update(){
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    //this method is called by animation
    public void SetMovementSpeed(float newSpeed){
        currentSpeed = newSpeed;
    }
}
