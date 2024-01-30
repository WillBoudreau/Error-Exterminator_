using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossBehaviour : MonoBehaviour
{
    float Speed = 1.5f;
    float respawnDelay = 0.5f;
    int BossHp = 50;
    int BossLives = 1;
    public GameObject Enemies;
    public GameObject player;
    public GameObject Boss;
    public GameObject Minion;
    public Vector3 initPOS;
    private float distance;
    public Animator bossAnim;
    
    void Start()
    {
        bossAnim.SetBool("IsHurt",false);
        initPOS = transform.position;
        Debug.Log(UIManager.playerKills);
    }
    void Awake()
    {
        initPOS = transform.position;
        SpawnMinions();
        Invoke("SpawnMinions",1);
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position,player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position,Speed * Time.deltaTime);
    }
    void LateUpdate()
    {
        bossAnim.SetBool("IsHurt",false);
    }
    void Respawn()
    {
        Debug.Log("Boss" + BossLives);
        Boss.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Slider"))
        {
            BossHp--;
            bossAnim.SetBool("IsHurt",true);
            if(BossHp <= 0)
            {
                BossHp = 0;
                UIManager.AddToKills();
                //Invoke("Respawn",respawnDelay);
                SceneManager.LoadScene(2);
            }
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            UIManager.PlayerIsDead();
        } 
    }
    void SpawnMinions()
    {
        Instantiate(Minion, initPOS, Quaternion.identity);
    }
}
