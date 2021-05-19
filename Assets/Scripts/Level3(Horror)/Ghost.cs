using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] Transform player;
    private bool facingleft = true;
    private void Update()
    {
        FlipTowardsPlayer();
    }
    private void FlipTowardsPlayer() { 
    float playerDirection = player.position.x - transform.position.x;
    if (playerDirection > 0 && facingleft)
        Flip();
    else if (playerDirection < 0 && !facingleft)
        Flip();
}
private void Flip()
{
    facingleft = !facingleft;
    transform.Rotate(0, 180, 0);
}
}
