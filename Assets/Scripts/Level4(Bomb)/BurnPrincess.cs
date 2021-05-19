using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnPrincess : MonoBehaviour {
    [SerializeField] private GameObject princess;
    [SerializeField] private GameObject monsterCell;
    private bool canPress=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) {
            canPress = true;
        }
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) {
            canPress = false;
        }
    }
    private void burnPrincess() {
        if (Input.GetKey(KeyCode.Space) && canPress == true)
        {
            FindObjectOfType<AudioManager>().Play("Button");
            Destroy(princess);
            FindObjectOfType<AudioManager>().Play("Death");
            monsterCell.SetActive(true);

        }
                
    }
    private void Update()
    {
        burnPrincess();
      
    }

}
