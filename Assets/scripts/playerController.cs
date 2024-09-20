using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.right;
    private movement2D movement2D;

    private void Awake()


    {
        movement2D = GetComponent<movement2D>();
    }

    private void Update()
    {
        // 여기서 부터 다시
    }
}
