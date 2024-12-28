using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController3d : MonoBehaviour
{
    //Jump input
    float horizontal;
    float vertical;
    bool jumpPressed;

    //Jump info
    bool isGrounded;
    Rigidbody rb;

    [SerializeField]
    Transform groundCheckPosition;
    [SerializeField]
    float groundCheckRadius;
    [SerializeField]
    LayerMask groundMask;

    //Movement prperties
    public float speed=10f;
    public float turnSpeed = 5f;
    public float jumpForce = 10f;
    public float MaxHealth = 100;
    public float CurrentHealth = 100;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jumpPressed = Input.GetButtonDown("Fire1");
        isGrounded = Physics.CheckSphere(groundCheckPosition.position, groundCheckRadius, groundMask);

        //update Player position        
        transform.position += transform.forward *vertical* speed * Time.deltaTime;

        if (jumpPressed&&isGrounded)
        {
            Jump();
        }

        //Implement player rotation
        Vector3 turnDir = new Vector3(0, horizontal, 0);
        transform.Rotate(turnDir * turnSpeed*10 * Time.deltaTime);     
    }

    void Jump()
    {
        Vector3 jumpDir = new Vector3(0, jumpForce, 0);
        rb.AddForce(jumpDir, ForceMode.Impulse);
    }
}
