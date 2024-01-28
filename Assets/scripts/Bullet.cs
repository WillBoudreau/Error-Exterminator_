using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ExplodePreFab;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject); // Check if you're hitting | damaging enemy 
        
        
           

        
    }

    void OnDestroy()
    {
        // instantiating and destroying explosion prefab
        
        GameObject Explosion = Instantiate(ExplodePreFab, transform.position, Quaternion.identity);
        Destroy(Explosion, 1f);
    }
    
}
