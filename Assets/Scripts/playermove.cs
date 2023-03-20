using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [SerializeField]
    private GameObject joystick;
    private Rigidbody2D rb;
    private float moveSpeed;
    private Touch oneTouch;
    private Vector2 touchPosition;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick.SetActive(false);
        moveSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            oneTouch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(oneTouch.position);
            switch (oneTouch.phase)
            {
                case TouchPhase.Began:
                    joystick.SetActive(true);
                  

                    joystick.transform.position = touchPosition;
                  
                    break;
                case TouchPhase.Stationary:
                    MovePlayer();
                    break;
                case TouchPhase.Moved:
                    MovePlayer();
                    break;
                case TouchPhase.Ended:
                    joystick.SetActive(false);
                    

                    rb.velocity = Vector2.zero;
                    break;
            }
        }
    }
    private void MovePlayer()
    {
        joystick.transform.position = touchPosition;

        joystick.transform.position = new Vector2(
            Mathf.Clamp(joystick.transform.position.x,
            joystick.transform.position.x - 0.8f,
            joystick.transform.position.x + 0.8f),
            Mathf.Clamp(joystick.transform.position.x,
            joystick.transform.position.y - 0.8f,
            joystick.transform.position.y + 0.8f));

        moveDirection = (joystick.transform.position - joystick.transform.position).normalized;
        rb.velocity = moveDirection * moveSpeed;
    }
}