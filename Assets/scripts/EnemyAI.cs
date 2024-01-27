using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Variables
    //Enemy Types
    [Header("Enemy Variables")]
    [Header("Enemy Types")]
    public GameObject EnemyFab404_Boss;
    public GameObject EnemyFabNull;
    public GameObject EnemyFabIndexRaneg;
    public GameObject EnemyFab404_Minion;
    public GameObject player;
    public Rigidbody2D rb;
    //Enemy Speeds
    [Header("Enemy Speeds")]
    public float Boss_Speed = 0.5f;
    public float Null_Speed = 1.5f;
    public float Index_Speed = 2.0f;
    public float Minion_Speed = 1.25f;
    //Enemy Health
    [Header("Enemy Health")]
    public int Boss_Health = 5;
    public int Enemy_Health = 1;
    //Enemy Attack
    [Header("Enemy Attack")]
    public int Boss_Damage = 3;
    public int Enemy_Damage = 1;
    [Header("Enemy Positions")]
    public Transform EnemPOS;
    public Transform Enem2POS;
    public Transform Enem3POS;
    // Start is called before the first frame update
    void Start()
    {
        Enemy();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Enemy()
    {
       
        int EnemyChance = Random.Range(1,1);
        if(EnemyChance == 1)
        {
            for( int i=0; i < 100; i++)
            {
                GameObject Enemy = Instantiate(EnemyFabNull,EnemPOS.position,transform.rotation);
                Destroy(Enemy, 25f);
            }
        } 
        if(EnemyChance == 2)
        {
            for(int i = 0; i < 100;i++)
            {
                GameObject Enemy2 = Instantiate(EnemyFabIndexRaneg,Enem2POS.position,transform.rotation);
                Enemy2.GetComponent<Rigidbody2D>().AddForce(Enem2POS.up * Index_Speed,ForceMode2D.Impulse);
                Destroy(Enemy2, 25f);
            }
            
        }
        if(EnemyChance == 3)
        {
            for(int i = 0; i < 100; i++)
            {
                GameObject Enemy3 = Instantiate(EnemyFab404_Minion,Enem3POS.position,transform.rotation);
                Enemy3.GetComponent<Rigidbody2D>().AddForce(Enem3POS.up * Minion_Speed, ForceMode2D.Impulse);
                Destroy(Enemy3, 25f);
            }
        }
    }
}