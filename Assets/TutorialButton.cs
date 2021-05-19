using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    private bool canPress=false;
    [SerializeField] private Text text;

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
            FindObjectOfType<AudioManager>().Play("Button");
            text.color = Color.red;
        }

    }
}
