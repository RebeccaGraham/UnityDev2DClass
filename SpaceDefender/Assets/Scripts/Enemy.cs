using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Enemy Stats")]
    [SerializeField] float health = 4;
    [SerializeField] int pointsAwarded = 100;

    [Header("Laser")]
    [SerializeField] GameObject myLaser;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float laserSpeed = 6f;
    [SerializeField] AudioClip laserSFX;
    [SerializeField] [Range(0,1)] float laserVolume = 0.5f;

    [Header("XF")]
    [SerializeField] GameObject myExplosionVFX;
    [SerializeField] float explosionTimeWindow = 0.7f;
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] [Range(0,1)] float explosionVolume = 0.75f;

    //cached references
    GameSession gameSession;

    //state
    float shotCounter;

    // Use this for initialization
    void Start () {
        gameSession = FindObjectOfType<GameSession>();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update () {
        CountDownAndShoot();
    }

    private void CountDownAndShoot(){
        shotCounter -= Time.deltaTime;//Time.deltaTime is the time per frame
        if (shotCounter <= 0f){
            Fire();
            //reset the shotCounter to random interval
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire(){
        GameObject laser = Instantiate(myLaser, transform.position, 
            Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
        AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position, laserVolume);
    }

    private void OnTriggerEnter2D(Collider2D other){
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer){
        damageDealer.Hit();
        health -= damageDealer.GetDamage();
        if (health < 1){
            Die();
        }
    }

    private void Die(){
        gameSession.IncreaseScore(pointsAwarded);
        GameObject explosionVFX = Instantiate(myExplosionVFX,
            transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, explosionVolume);
        Destroy(explosionVFX, explosionTimeWindow);
        Destroy(gameObject);
    }
}
