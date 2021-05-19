using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTouch_Bomb : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private levelLoder level;
    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("levelLoader").GetComponent<levelLoder>();   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("princess"))
            door.SetActive(true);
        else if (collision.CompareTag("monster"))
            level.loadCurrentLevel();

    }

}
