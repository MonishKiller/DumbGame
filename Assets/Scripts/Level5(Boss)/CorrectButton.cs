using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectButton : MonoBehaviour
{
    
    [SerializeField] private GameObject[] buttonList = new GameObject[4];
    [SerializeField] private GameObject monster;
    private int escapeButton;
    private bool canPress = false;

    private void Awake()
    {
        int randomButton = Random.Range(0, 4);
        for (int i = 0; i < buttonList.Length; i++) {
            if (randomButton == i) {
                escapeButton = i;
            }
        }

    }
    public  int  EscapeButton() {
        return escapeButton;
    }
   

}
