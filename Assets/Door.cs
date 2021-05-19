using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour

{
    [SerializeField] levelLoder level;
    private void start()
    {
        level = GameObject.FindGameObjectWithTag("levelLoader").GetComponent<levelLoder>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
            level.LoadNextLevel();
        
    }

}
