using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float width;
    private float moveSpeed = 1f;
    private Vector2 velocity;
    void MoveLeft()
    {
        Vector2 dir = new Vector2(-1, 0);
        velocity = dir * moveSpeed;
    }

    void MoveRight()
    {
        Vector2 dir = new Vector2(1, 0);
        velocity = dir * moveSpeed;
        Debug.LogError("Right");
    }

    void MovePlayer(Vector2 pos)
    {
        if (pos.x > width)
        {
            MoveLeft();
        } 
        else
        {
            MoveRight();
        }
        Vector2 currPos = this.gameObject.transform.position;
        this.gameObject.transform.position = currPos + velocity * Time.deltaTime;
    }

    void Start()
    {
        width = (float)Screen.width / 2.0f;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            MovePlayer(touch.position);
        }
        else
        {
            velocity = Vector2.zero;
        }

        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButton(0))
            {
                MovePlayer(Input.mousePosition);
            }
            else
            {
                velocity = Vector2.zero;
            }
        }
    }
}
