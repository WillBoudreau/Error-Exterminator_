using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    float Speed = 3f;
    float respawnDelay = 3f;
    public GameObject player;
    public GameObject Minion;
    public GameObject Enemy;
    public Vector3 initPOS;
    private float distance;
    void Start()
    {
        initPOS = transform.position;
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position,player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position,Speed * Time.deltaTime);
    }
    void Respawn()
    {
        transform.position = initPOS;
        gameObject.SetActive(true);
        Minion.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            //UIManager.AddToKills();
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
