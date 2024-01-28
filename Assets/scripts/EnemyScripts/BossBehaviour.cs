using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    float Speed = 1.5f;
    float respawnDelay = 0.5f;
    int BossHp = 3;
    int BossLives = 1;
    int BossSpawn = 8;
    public int KillCount = 8;
    public GameObject player;
    public GameObject Boss;
    public GameObject Minion1;
    public GameObject Minion2;
    public Vector3 initPOS;
    private float distance;
    
    void Start()
    {
        KillCount = 8;
        initPOS = transform.position;
        Minion1.SetActive(false);
        Minion2.SetActive(false);
        Debug.Log(UIManager.playerKills);
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position,player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position,Speed * Time.deltaTime);
    }
    void Respawn()
    {
        Debug.Log(BossLives);
        Boss.SetActive(false);
        Minion1.SetActive(true);
        Minion2.SetActive(true);
        Minion1.transform.position = Boss.transform.position;
        Minion2.transform.position = Boss.transform.position;
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Slider"))
        {
            
            BossLives = BossLives - 1;
            UIManager.AddToKills();
            Invoke("Respawn",respawnDelay);
            
        }
    }
}
