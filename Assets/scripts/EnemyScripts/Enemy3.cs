using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    
    [SerializeField] AudioSource explodeSFX;
    [SerializeField] AudioSource hurtSFX;

    public float Speed = 3f;
    float respawnDelay = 3f;
    public GameObject player;
    public GameObject Enemies;
    public GameObject HealthDrop;
    public GameObject SpeedDrop;
    public GameObject Boss;
    int KillCount = 40;
    public Vector3 initPOS;
    private float distance;
    public Vector3 dropPosition;

    void Start()
    {
        Debug.Log("KillCount" + KillCount);
        initPOS = transform.position;
        Boss.SetActive(false);
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
        Speed = Speed + 0.1f;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            hurtSFX.Play();
            gameObject.SetActive(false);
            //UIManager.AddToKills();
            Invoke("Respawn",respawnDelay);
        }
        if(collision.gameObject.CompareTag("Slider"))
        {
            if(UIManager.playerKills >= KillCount)
            {
                Boss.SetActive(true);
            }
            explodeSFX.Play();
            dropPosition = transform.position;
            RollDrop();
            gameObject.SetActive(false);
            UIManager.AddToKills();
            Invoke("Respawn",respawnDelay);
        }
    }
    void RollDrop()
    {
        int DropRoll = Random.Range(0,100);
        if(DropRoll < 50)
        {
            // is ment to be empty. 
            Debug.Log("No Drop");
        }
        if(DropRoll > 50 && DropRoll < 75)
        {
            //Debug.Log("Speed Drop");
            Instantiate(SpeedDrop, dropPosition, Quaternion.identity);
        }
        if(DropRoll > 75)
        {
            //Debug.Log("Health Drop");
            Instantiate(HealthDrop, dropPosition, Quaternion.identity);
        }
    }
}

