using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour {
    //cached references
    TextMeshProUGUI health;
    Player player;

    // Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        health = GetComponent<TextMeshProUGUI>();
        health.text = player.GetCurrentHealth().ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (health != null){
            health.text = player.GetCurrentHealth().ToString();
        }
    }
}
