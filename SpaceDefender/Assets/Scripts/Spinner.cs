using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    [SerializeField] float speedOfRotation = 350f;
    [SerializeField] float rotationRandomFactor = 100f;
    //serialized for debugging only
    [SerializeField] float speed;

    void Start(){
        speed = Random.Range(speedOfRotation - rotationRandomFactor, speedOfRotation + rotationRandomFactor);
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0, 0, speed * Time.deltaTime);
	}
}
