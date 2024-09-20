using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveTime = 0.2f; //한칸 움직이는데 걸리는 시간
    private bool isMoved = false;   

    public bool MoveTo(Vector3 moveDirection)
    {
        if ( isMoved ) return false;

        StartCoroutine(SmoothgridMovement(transform.position = moveDirection));

        return true;
    }

    private IEnumerator SmoothgridMovement(Vector2 endposition)
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
