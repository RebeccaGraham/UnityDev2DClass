using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Ball hit loose collider.");
        SceneManager.LoadScene("Game Over");
    }
}
