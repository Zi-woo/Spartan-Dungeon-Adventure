using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection = Vector3.forward;
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private float moveSpeed = 2f;

    private Vector3 startPos;
    private Vector3 lastPos;
    private Rigidbody rb;

    private void Start()
    {
        startPos = transform.position;
        rb = transform.GetComponent<Rigidbody>();
        rb.isKinematic = true; 
        lastPos = startPos;
    }

    private void FixedUpdate()
    { 
        lastPos =  transform.position;
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        Vector3 newPos = startPos + moveDirection.normalized * offset;
        rb.MovePosition(newPos);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 velocity = (transform.position - lastPos) / Time.fixedDeltaTime;
                playerRb.MovePosition(playerRb.position + velocity * Time.fixedDeltaTime);
            }
        }
    }
}
