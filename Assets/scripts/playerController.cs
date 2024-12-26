using System.Collections;
using UnityEditor.U2D;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask tileLayer;

    private Vector2 moveDirection = Vector2.right;
    private Direction direction;
    private float rayDistance = 0.55f;
    private movement2D movement2D;
    private aroundWrap aroundWrap;
    private SpriteRenderer spriteRenderer;

    private void Awake()


    {
        movement2D = GetComponent<movement2D>();
        aroundWrap = GetComponent<aroundWrap>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = Vector2.up;
            direction = Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = Vector2.down;
            direction = Direction.Down;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection = Vector2.left;
            direction = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))

        {
            moveDirection = Vector2.right;
            direction = Direction.Right;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, rayDistance, tileLayer);
        if (hit.transform == null)
        {
            bool movePossible = movement2D.MoveTo(moveDirection);
            if (movePossible)
            {
                transform.localEulerAngles = Vector3.forward * 90 * (int)direction;
            }
            aroundWrap.UpdateAroundWrap();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Àû") )
        {
            StopCoroutine(nameof(OnHit));
            StartCoroutine(nameof(OnHit));

            Destroy(collision.gameObject);
        }   
    }

    private IEnumerator OnHit()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;
    }

}