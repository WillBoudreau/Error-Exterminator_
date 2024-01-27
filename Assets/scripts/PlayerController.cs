using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Variables
    
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public int currentHP;
    public int killCount;

    // For fire rate
    
    public float fireRate = 0.25f;
    public float canFire = 1f;


    Vector2 moveDirection;
    Vector2 mousePosition;
    void Start()
    {
        currentHP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

        
        // Gets left click input to shoot
        
        if (Input.GetButton("Fire1") && Time.time > canFire)
        {
            weapon.Shoot();
            
            canFire = Time.time + fireRate;

        }

        moveDirection = new Vector2(movementX, movementY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // UI functions
        UIManager.UpdateUI(currentHP, killCount);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        
        // This horrible looking math is how the character stays looking at the mouse point
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
        
        
    }

}
