using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text titleText;
    [SerializeField] Text storyText;
    [SerializeField] State startingState;


    State state;

	// Use this for initialization
	void Start () {
        state = startingState;
        storyText.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update () {
        ManageState();
        storyText.text = state.GetStateStory();
    }

    private void ManageState(){
        var nextStates = state.GetNextStates();
        for (int i = 0; i < nextStates.Length; i++){
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)){
                state = nextStates[i];
            }
        }
    }
}
