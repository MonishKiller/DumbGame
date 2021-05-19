using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStand : MonoBehaviour
{
    [SerializeField] private GameObject Rock;
    [SerializeField] private GameObject player;
    public bool playerIn=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            playerIn = true;
            Rock.SetActive(true);
        }
    }
   

}
