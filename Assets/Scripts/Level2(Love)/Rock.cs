using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private GameObject princess;
    [SerializeField] private levelLoder level;
    [SerializeField] private GameObject player;

    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("levelLoader").GetComponent<levelLoder>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("princess"))
            if (collision.gameObject.CompareTag("player"))
            {
                FindObjectOfType<AudioManager>().Play("Death");
                Destroy(player);
                level.loadCurrentLevel();


            }
            else if (collision.gameObject.CompareTag("princess"))
            {
                FindObjectOfType<AudioManager>().Play("Death");
                Destroy(princess);

            }
    }

}
