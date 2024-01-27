using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public float Speed = 3f;
    public float respawnDelay = 1f;
    public Vector2 moveDirection = Vector2.left;
    public Vector3 initPOS;
    public GameObject Enemy;
    void Start()
    {
        initPOS = transform.position;
    }
    // Update is called once per frame
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
            UIManager.AddToKills();
            Invoke("Respawn",respawnDelay);
        }
        if(collision.gameObject.CompareTag("Slider"))
        {
            gameObject.SetActive(false);
            UIManager.AddToKills();
            Invoke("Respawn",respawnDelay);
        }
    }
}
