using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {
    PlayerControllerHorror playerH;
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject flashLight;
    [SerializeField] private Transform player;
    [SerializeField] private levelLoder level;
    [SerializeField] private float monsterPeekTime;
    [SerializeField] private float checkformonsterTime;
     PlayerControllerHorror playerControllerH;
    private bool facingRightformonster=false;
    private int fearcount = 3;

    private void Start()
    {
        playerH = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerControllerHorror>();
        level = GameObject.FindGameObjectWithTag("levelLoader").GetComponent<levelLoder>();
    }
    IEnumerator checkForMonster()
    {
        yield return new WaitForSeconds(checkformonsterTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(player.position, player.TransformDirection(Vector2.right),20);
        if (hitInfo)
        {
            if (hitInfo.collider.name == "Ghost")
            {
                FindObjectOfType<AudioManager>().Play("Death");
                fearcount--;
                ghost.SetActive(false);
                flashLight.SetActive(false);
                if (fearcount <= 0)
                {
                    level.loadCurrentLevel();
                    Destroy(gameObject);
                }
            }
           
           

        }
    }
        // Update is called once per frame
        void Update()
        {
        facingRightformonster = playerH.facingRight;
      
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("flashLIghtON");
                FindObjectOfType<AudioManager>().Play("FlashLight");
                flashLight.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(monsterPeek());
                }
            }
        }
    IEnumerator monsterPeek()
    {
        yield return new WaitForSeconds(monsterPeekTime);

        if (facingRightformonster == true)
        {
            ghost.transform.position = new Vector2(player.position.x + 2, player.position.y);
            Debug.Log(facingRightformonster);
        }
        else if (facingRightformonster == false) { 
            ghost.transform.position = new Vector2(player.position.x - 2, player.position.y);
            Debug.Log(facingRightformonster);
        }
           ghost.SetActive(true);
            StartCoroutine(checkForMonster());

        }
    
 
}
