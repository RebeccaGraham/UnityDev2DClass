using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    public void Fire()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        return;
    }
}
