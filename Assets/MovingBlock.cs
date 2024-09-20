using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float speed = 5f;
    public float fallSpeed = 2f;
    private bool isFalling = false;
    private bool isStopped = false;

    private void OnEnable()
    {
        InputController.OnTap += HandleTap;
    }

    private void OnDisable()
    {
        InputController.OnTap -= HandleTap;
    }

    private void Update()
    {
        if (!isStopped)
        {
            if (!isFalling)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;

                if (transform.position.x > 3f || transform.position.x < -3f)
                {
                    speed = -speed;
                }
            }
            else
            {
                transform.position += Vector3.down * fallSpeed * Time.deltaTime;
            }
        }
    }

    private void HandleTap()
    {
        isFalling = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bloque") || collision.gameObject.CompareTag("base"))
        {
            isFalling = false;
            isStopped = true;
        }
    }
}
