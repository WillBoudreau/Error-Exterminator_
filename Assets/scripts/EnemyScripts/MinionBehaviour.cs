using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBehaviour : MonoBehaviour
{
    float Speed = 1.5f;
    float respawnDelay = 0.5f;
    public GameObject Boss;
    public GameObject player;
    public GameObject Enemies;
    public GameObject Minion1;
    public GameObject Minion2;
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
        Minion1.SetActive(false);
        Minion2.SetActive(false);
        Enemies.SetActive(true);
        Minion1.transform.position = Boss.transform.position;
        Minion2.transform.position = Boss.transform.position;
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Slider"))
        {
            UIManager.AddToKills();
            Invoke("Respawn",respawnDelay);
        }
    }
}
