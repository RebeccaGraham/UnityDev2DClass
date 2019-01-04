using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 8;
    [SerializeField] GameObject deathVFX;

    public void Damage(int damage){
        health = health - damage;
        if (health < 1){
            Die();
        }
    }

    private void TriggerDeathVFX(){
        if (!deathVFX) { return; }
        GameObject sparkles = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(sparkles, 1f);
    }

    private void Die(){
        TriggerDeathVFX();
        Destroy(gameObject);
    }

}
