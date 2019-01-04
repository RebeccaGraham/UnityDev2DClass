using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    //configuration parameters
    WaveConfig waveConfig;
    List<Transform> waypoints;

    // state
    int wayPointIndex = 0; //waypoint enemy is working towards

    // Use this for initialization
    void Start () {
        //start enemy at the first waypoint
        if (waveConfig != null){
            waypoints = waveConfig.GetWayPoints();
            transform.position = waypoints[wayPointIndex].transform.position;
        }
    }
    
    // Update is called once per frame
    void Update (){
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig){
        this.waveConfig = waveConfig;
    }

    private void Move(){
        if (waypoints == null) { return; }
        if (wayPointIndex <= waypoints.Count - 1){
            //Debug.Log("At waypoint: " + wayPointIndex.ToString());
            var targetposition = waypoints[wayPointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetposition,
                movementThisFrame);
            if (transform.position == targetposition){
                wayPointIndex++;
                //Debug.Log("Incremented waypoint index to: " + wayPointIndex.ToString());
            }
        }else{
            //at the final waypoint
            Destroy(gameObject);
            //Debug.Log("Reached final waypoint. Destroyed object.");
        }
    }
}
