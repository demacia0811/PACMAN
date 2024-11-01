using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveTime = 0.2f; 
    private bool isMoved = false;   

    public bool MoveTo(Vector3 moveDirection)
    {
        if ( isMoved ) return false;

        StartCoroutine(SmoothGridMovement(transform.position + moveDirection));

        return true;
    }

    private IEnumerator SmoothGridMovement(Vector2 endposition)
    {
        Vector2 startposition = transform.position;
        float percent = 0;

        isMoved = true;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / moveTime;
            transform.position = Vector2.Lerp(startposition, endposition, percent);

            yield return null;
        }

        isMoved = false;
    }
}
