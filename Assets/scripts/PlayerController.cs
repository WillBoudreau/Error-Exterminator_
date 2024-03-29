using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    // Variables

    public GameObject Player;
    public GameObject dashPreFab;
    public Animator anim;

    public float moveSpeed = 5f;
    public float maxMoveSpeed = 10f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public int currentHP;
    public int maxHP = 5;
    public int startHP = 3;
    public bool isShooting;

    [SerializeField] AudioSource dashSFX;
 
    // for dash ability

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCooldownCounter;


    // For fire rate
    
    public float fireRate = 0.25f;
    public float canFire = 1f;

    Vector2 moveDirection;
    Vector2 mousePosition;

    void Start()
    {
        // Starting HP
        currentHP = startHP;

        activeMoveSpeed = moveSpeed;
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isShooting == true)
        {
            anim.SetBool("IsShooting", true);
        }
        if(isShooting == false)
        {
            anim.SetBool("IsShooting", false);
        }
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

        
        // Gets left click input to shoot
        if (Input.GetButton("Fire1"))
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }

        if (Input.GetButton("Fire1") && Time.time > canFire)
        {
            weapon.Shoot();
            

            canFire = Time.time + fireRate;
            
        }


        // Dash Input
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (dashCooldownCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                
                dashSFX.Play();
                GameObject dashTrail = Instantiate(dashPreFab, transform.position, Quaternion.identity);
                Destroy(dashTrail, 1f);
                
                Player.GetComponent<CircleCollider2D>().enabled = false;
                

            }
            
                

        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0) 
            {
                activeMoveSpeed = moveSpeed;
                dashCooldownCounter = dashCooldown;
                Player.GetComponent<CircleCollider2D>().enabled = true;
            }
        }

        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }



        moveDirection = new Vector2(movementX, movementY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        
        // UI functions
        UIManager.UpdateUI(currentHP, dashCooldownCounter);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * activeMoveSpeed, moveDirection.y * activeMoveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        
        // This horrible looking math is how the character stays looking at the mouse point
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
        
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            currentHP--;
            if(currentHP <= 0)
            {
                currentHP = 0;
                Time.timeScale = 0.0f;
                UIManager.PlayerIsDead();
            }
        }
        if(collision.gameObject.CompareTag("Minion"))
        {
            Debug.Log("Hello world");
        }
        if(collision.gameObject.CompareTag("HealthPickup"))
        {
            currentHP++;
            if(currentHP > maxHP)
            {
                currentHP = maxHP;
            }
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("SpeedPickup"))
        {
            moveSpeed = moveSpeed + 0.1f;
            if(moveSpeed > maxMoveSpeed)
            {
                moveSpeed = maxMoveSpeed;
            }
            Destroy(collision.gameObject);
        }
        //Debug.Log(collision);
    }

}
