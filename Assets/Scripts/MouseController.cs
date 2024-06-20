using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 touchStart;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public Vector2 swipeData;

    void Update()
    {
        HandleTouchInput();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + swipeData * Time.fixedDeltaTime * speed );
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
 
            if (touch.phase == TouchPhase.Began)
            {
                 touchStart = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Vector2 touchEnd = touch.position;
                Vector2 swipeDirection = touchEnd - touchStart;

                swipeDirection.Normalize();
                Debug.Log(swipeDirection);

                if (swipeDirection.y >= 0.9)
                {
                    swipeData = Vector2.up;
                }
                else if (swipeDirection.y <= -0.9)
                {
                    swipeData = Vector2.down;
                }
                else if (swipeDirection.x <= 0.9)
                {
                    swipeData = Vector2.left;
                }
                else if (swipeDirection.x >= -0.9)
                {
                    swipeData = Vector2.right;
                }
                else
                {
                    swipeData = Vector2.zero;
                }
            }
        }
    }
}
