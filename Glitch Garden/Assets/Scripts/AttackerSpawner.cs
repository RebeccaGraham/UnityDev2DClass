using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawning = true;
    [SerializeField] float minSpawnSpace = 1f;
    [SerializeField] float maxSpawnSpace = 5f;
    [SerializeField] Attacker attackerPrefab;


    // Start is called before the first frame update
    IEnumerator Start(){
        do{
            yield return StartCoroutine(SpawnAttacker());
        }
        while (spawning);
    }

    private IEnumerator SpawnAttacker(){
        yield return new WaitForSeconds(Random.Range(minSpawnSpace, maxSpawnSpace));
        Instantiate(attackerPrefab,
                transform.position,
                Quaternion.identity);
    }

    // Update is called once per frame
    void Update(){
        
    }
}
