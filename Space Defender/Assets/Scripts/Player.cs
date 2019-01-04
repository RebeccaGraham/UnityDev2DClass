using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //configuration parameters
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int health = 50;
    [SerializeField] float movementPadding = 1f;
    [SerializeField] AudioClip myDamageSFX;
    [SerializeField] [Range(0,1)] float damageVolume = .5f;
    [SerializeField] AudioClip myDeathSFX;
    [SerializeField] [Range(0, 1)] float deathVolume = 1f;


    [Header("Projectile")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float laserSpeed = 0.1f;
    [SerializeField] GameObject myLaser;
    float minX;
    float maxX;
    float minY;
    float maxY;

    //cached references
    Level level;
    GameSession gameSession;
    Coroutine firingCoroutine;

    // Use this for initialization
    void Start () {
        SetUpMoveBoundaries();
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();

    }

    // Update is called once per frame
    void Update () {
        Move();
        Fire();
    }

    private void Fire(){
        if (Input.GetButtonDown("Fire1")){
            firingCoroutine = StartCoroutine(FireContinuously());
         }
        if (Input.GetButtonUp("Fire1")){
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously(){
        while (true){
            GameObject laser = Instantiate(
                myLaser,
                transform.position,
                Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(laserSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer){
        health -= damageDealer.GetDamage();
        AudioSource.PlayClipAtPoint(myDamageSFX, Camera.main.transform.position, damageVolume);
        if (health < 1){
            Die();
        }
        damageDealer.Hit();
    }

    private void Die(){
        AudioSource.PlayClipAtPoint(myDeathSFX, Camera.main.transform.position, deathVolume);
        Destroy(gameObject);
        level.LoadGameOverScene();
    }

    private void Move(){
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + movementPadding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - movementPadding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + movementPadding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - movementPadding;
    }
    public int GetCurrentHealth(){
        return health;
    }
}
