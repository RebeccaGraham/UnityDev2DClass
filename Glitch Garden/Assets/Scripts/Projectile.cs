using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] int damage = 5;

    void Update(){
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider){
        Debug.Log("I hit: " + otherCollider.name);

        var health = otherCollider.gameObject.GetComponent<Health>();
        var attacker = otherCollider.gameObject.GetComponent<Attacker>();

        //check that collision has Health component
        if (attacker && health){
            health.Damage(damage);
            Destroy(gameObject);
        }
    }
}
