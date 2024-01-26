using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public GameObject BulletPreFab;
    public Transform firePoint;
    public float fireForce = 20f;

    // Shoot method 
    
    public void Shoot()
    {
        // Instantiating bullet prefab when shot
        
        GameObject Bullet = Instantiate(BulletPreFab, firePoint.position, firePoint.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }


}
