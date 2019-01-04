using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    //cached references
    GameArea gameArea;

    // Start is called before the first frame update
    void Start(){
        gameArea = FindObjectOfType<GameArea>();
    }

    private void OnMouseDown(){
        ManageButtonColors();
        gameArea.SetSelectedDefender(defenderPrefab);
    }

    private void ManageButtonColors(){
        //reset all buttons grey
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(102, 102, 102, 255);
        }
        //then set the clicked button to white
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
