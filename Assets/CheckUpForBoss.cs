using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUpForBoss : MonoBehaviour
{
    [SerializeField] GameObject door;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("boss")) {
            door.SetActive(true);
            Destroy(gameObject);
            
        }
    }
}
