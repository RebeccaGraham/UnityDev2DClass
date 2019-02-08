using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour{
    [SerializeField] int starCost = 100;
    [SerializeField] int fooBar = 10;

    public void AddStars(int amount){
        FindObjectOfType<StarDisplay>().AddStars(amount);
        Debug.Log("Added stars: " + amount.ToString());
    }
}
