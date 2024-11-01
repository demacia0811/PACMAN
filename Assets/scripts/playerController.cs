using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask tileLayer;

    private Vector2    moveDirection = Vector2.right;
    private float      rayDistance = 0.55f;
    private movement2D movement2D;

    private void Awake()
        

    {
        movement2D = GetComponent<movement2D>();
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.UpArrow) )
        {
            moveDirection = Vector2.up;
        }
        else if ( Input.GetKeyDown(KeyCode.DownArrow) )
        {
            moveDirection = Vector2.down;
        }
        else if ( Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            moveDirection = Vector2.left;
        }
        else if ( Input.GetKeyDown(KeyCode.RightArrow) )

        {
            moveDirection = Vector2.right;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, rayDistance, tileLayer);
        if ( hit.transform == null ) 
        { 
            movement2D.MoveTo(moveDirection);
        }
    }
}