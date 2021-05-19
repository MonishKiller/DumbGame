using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockTutorial : MonoBehaviour
{
   
    [SerializeField] private Text text;
    private Vector2 defaultPos;
    private void Awake()
    {
        defaultPos = this.transform.position;
    }

    private void Update()
    {
        if (defaultPos.x != this.transform.position.x || defaultPos.y != this.transform.position.y)
            text.color = Color.red;
    }

}
