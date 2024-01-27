using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float Speed = 3f;
    public float respawnDelay = 3f;
    public Vector2 moveDirection = Vector2.down;
    public GameObject StartPOS;
    public Vector3 initPOS;
    public GameObject Enemy;
    // Update is called once per frame
    void Start()
    {
        initPOS = transform.position;
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 movement = new Vector3(moveDirection.x,moveDirection.y,0f);
        movement.Normalize();
        transform.Translate(movement * Speed * Time.deltaTime);
    }
    void Respawn()
    {
        transform.position = initPOS;
        gameObject.SetActive(true);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Invoke("Respawn",respawnDelay);
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(Enemy);
        }
    }
}
