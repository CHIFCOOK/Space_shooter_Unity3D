using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    public float fireRate;
    public float speed;
    public float tilt;

    private float nextFire;
    private Vector3 movement;

    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                movement = new Vector3(touchDeltaPosition.x, 0.0f, touchDeltaPosition.y);
                rb.AddForce(movement * 5);
            }
        }
        else
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);
        }

        Vector3 clamp = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));

        rb.MovePosition(clamp);
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}