using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    public GameObject PopUpPrefab;
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        // instantiating and destroying explosion prefab
        
        GameObject Popup = Instantiate(PopUpPrefab, transform.position, Quaternion.identity);
    }

    
}
