using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class constants : MonoBehaviour
{
    [SerializeField]
    private LayerMask tileLayrt;

    private Vector2 moveDirection = Vector2.right;
    private float raydistance = 0.55f;
    private Direction direction = Direction.Right;

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
            direction = Direction.Up;
        }
        else if ( Input.GetKeyDown(KeyCode.DownArrow) )
        {
            moveDirection = Vector2.down;
            direction = Direction.Down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            moveDirection = -Vector2.left;
            direction = Direction.Right;
        }


}
}
