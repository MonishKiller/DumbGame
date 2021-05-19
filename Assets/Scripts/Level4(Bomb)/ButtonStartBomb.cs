using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartBomb : MonoBehaviour {
    [SerializeField] private Material buttonpressedG;
    [SerializeField] private GameObject Bomb;
     private GameObject button;
     private SpriteRenderer buttonMat;
    private bool canPressButton = false;
    private void Start()
    {
        button = this.gameObject;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canPressButton == true)
        {
            bombSetActive();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            canPressButton = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
            canPressButton = false;
    }
    private void bombSetActive() {
        Bomb.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Button");
        buttonMat = button.GetComponent<SpriteRenderer>();
        buttonMat.material = buttonpressedG;

    }
}
