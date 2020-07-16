using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    RaycastHit hit;

    public float speed;

    Vector3 lookPosition;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerRotate();

    }

    void FixedUpdate()
    {
        Movement();
    }

    void PlayerRotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit, 100))
        {
            lookPosition = hit.point;
        }

        Vector3 lookDir = lookPosition - transform.position;
        lookDir.y = 0;
        transform.LookAt(transform.position + lookDir, Vector3.up);
    }
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rb.AddForce(movement * speed / Time.deltaTime);
    }
}

