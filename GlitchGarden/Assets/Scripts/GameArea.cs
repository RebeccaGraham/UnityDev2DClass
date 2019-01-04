using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour{

    [SerializeField] Defender defender;
     

    private void OnMouseDown(){
        SpawnDefender();
    }

    public void SetSelectedDefender(Defender defender){
        this.defender = defender;
    }

    private void SpawnDefender(){
        //Debug.Log("user clicked play area");
        Defender newDefender = Instantiate(defender, GetSquareClicked(), Quaternion.identity) as Defender;
    }

    private Vector2 GetSquareClicked(){
        Vector2 clickPos = new Vector2(Mathf.RoundToInt(Input.mousePosition.x), Mathf.RoundToInt(Input.mousePosition.y));
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
        Debug.Log("Square clicked: " + gridPos.x.ToString() + ", " + gridPos.y.ToString());
        return gridPos;

    }
}
