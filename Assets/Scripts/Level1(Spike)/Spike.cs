using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {
    [SerializeField] levelLoder level;
    private GameObject player;
    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("levelLoader").GetComponent<levelLoder>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) {
            player = collision.gameObject;
            Destroy(player);
            level.loadCurrentLevel();
        }
    }
}
