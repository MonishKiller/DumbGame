using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   
    [SerializeField] private int secoundsleft;
    [SerializeField] private GameObject door;
    private bool takeAway=false;
  

    private void Update()
    {
        if (takeAway == false && secoundsleft > 0) {
            StartCoroutine(TakeTime());
        }
    }

    IEnumerator TakeTime() {
        takeAway = true;
        yield return new WaitForSeconds(1);
        secoundsleft -= 1;
        Debug.Log(secoundsleft);
        takeAway = false;
        if (secoundsleft <= 0)
            door.SetActive(true);    
        
    }


}
