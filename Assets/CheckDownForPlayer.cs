using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDownForPlayer : MonoBehaviour
{
    [SerializeField] levelLoder level;
    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("levelLoader").GetComponent<levelLoder>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) {
            FindObjectOfType<AudioManager>().Play("Death");
            level.loadCurrentLevel();
            Destroy(gameObject);
        }
    }
}
