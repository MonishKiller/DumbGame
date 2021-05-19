using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject door;
    private bool canPress = false;
    public bool rosePlucked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
            canPress = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
            canPress = false;
    }
    private void Update()
    {
        if (canPress == true && Input.GetKey(KeyCode.Space))
        {
            rock.SetActive(true);
            rosePlucked = true;
            FindObjectOfType<AudioManager>().Play("Button");
            if (rosePlucked == true)
                door.SetActive(true);

        }


    }

}
