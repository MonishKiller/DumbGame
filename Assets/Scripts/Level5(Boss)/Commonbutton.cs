using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commonbutton : MonoBehaviour
{
    [SerializeField] private GameObject Toproof;
    [SerializeField] private GameObject Downroof;
    [SerializeField] private GameObject ToproofCheck;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject Boss;
    [SerializeField] private Material Green;
    [SerializeField] private Material Red;
    private Material defaultMat;
    private SpriteRenderer buttonColor;
    CorrectButton CB;
    public int number;
    private int check;
    private bool canPress = false;
    private bool crt = false;
    private void Start()
    {
        buttonColor = this.gameObject.GetComponent<SpriteRenderer>();
        defaultMat = buttonColor.material;
    
    }
    //check = CB.EscapeButton();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("boss")){
            CB = GameObject.FindGameObjectWithTag("CB").GetComponent<CorrectButton>();
            check = CB.EscapeButton();
            if (number == check) {
                buttonColor.material = Red;
                crt = true;
                
            }
            else
            {
                buttonColor.material = Green;
            }
           
        }
        if (collision.CompareTag("player")) {
            canPress = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("boss"))
        {
            buttonColor.material = defaultMat;
            
        }

        if (collision.CompareTag("player"))
        {
            canPress = false;

        }

    }
    private void Update()
    {
        if (canPress == true && Input.GetKey(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("Button");
            if (crt == true)
            {
                Destroy(Boss);
                FindObjectOfType<AudioManager>().Play("Death");
                door.SetActive(true);

            }
            else if (crt == false)
                Downroof.SetActive(false);
        }
    
            


    }

}
