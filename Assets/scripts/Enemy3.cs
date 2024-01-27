using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    float Speed = 3f;
    public GameObject player;
    public GameObject Enemy;

    private float distance;
    void Start()
    {

    }
    void Update()
    {
        distance = Vector2.Distance(transform.position,player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position,Speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(Enemy);
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(Enemy);
        }
    }
}
