using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField] private Text A;
    [SerializeField] private Text D;
    [SerializeField] private Text space;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            A.color = Color.red;
        if (Input.GetKey(KeyCode.D))
            D.color = Color.red;
        if (Input.GetKey(KeyCode.Space))
            space.color = Color.red;
    }

}
