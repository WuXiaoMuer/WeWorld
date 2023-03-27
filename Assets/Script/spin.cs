using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxMoveSpeed = 20f;
    private bool isSpeedingUp = false;
    public float rotationSpeed = 100f;
    private float currentMoveSpeed = 0f;
    public float speedUpMultiplier = 2f;
    private Vector3 lastMousePosition;

    public float jumpHeight = 3f;
    public float timeToJumpApex = 0.4f;
    private Rigidbody rb;
    private float gravity;
    private float jumpVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;//旋转
        float vertical = Input.GetAxis("Vertical") * currentMoveSpeed * Time.deltaTime;//行进
        transform.Translate(Vector3.forward * vertical);
        transform.Rotate(Vector3.up, horizontal, Space.World);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSpeedingUp = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isSpeedingUp = false;
        }

        if (isSpeedingUp)
        {
            currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, maxMoveSpeed, speedUpMultiplier * Time.deltaTime);
        }
        else
        {
            currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, moveSpeed, Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, gravity, 0), ForceMode.Acceleration);
    }
    void OnMouseDown()
    {
        
    }

    void OnMouseDrag()
    {
        
    }
}
