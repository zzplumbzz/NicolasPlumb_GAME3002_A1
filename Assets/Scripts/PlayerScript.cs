
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Movement Properties
    [Header("Movement")]
    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    //public float jumpHeight = 3.0f;
    public Vector3 velocity;

    // Ground Check Properties
    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Character Controller")]
    public CharacterController controller;

    public Rigidbody rb;

   // public BallScript = ball();

    public Rigidbody rbb;

    //for ball
    public float forwardForce = 2000f;
    public float sideForce = 200f;

    //private KeyCode Kick;

    // Start is called before the first frame update
    void Start()
    {
       // ball = GetComponent<BallScript>();
        controller = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
       // Reset();
        //Kick = KeyCode.Space;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        // movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * maxSpeed * Time.deltaTime);

        // jumping
        //if (Input.GetButton("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        //}

        // gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    //void OnMouseDown()
    //{
    //    rb.AddForce(-transform.forward * 500);
    //    rb.useGravity = true;
    //}

    //void OnColliderEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {

    //        if (Input.GetKeyDown(KeyCode.Space))
    //{

    //                  rbb.AddForce(0, 0, 500);




    //                }
    //    }
    //}

    //void OnColliderEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Ball")
    //    {
    //        rbb.transform.parent = rb.transform;
    //        //if (Input.GetKeyDown(KeyCode.Space))
    //        //{
    //        //    rb.AddForce(0, 0, forwardForce * Time.deltaTime);
    //        //    rb.AddForce(forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    //        //}
            
    //    }
    //}
  public  void KickBall(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            rbb.transform.parent = rb.transform;

            if (Input.GetKeyDown(KeyCode.E))
            {
                //rbb.AddForce(0, 0, forwardForce * Time.deltaTime);
                //rbb.AddForce(forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                rbb.AddRelativeForce(0f, 0f, forwardForce);
            }
        }


        
    }

    public void Reset()
    {
        if (Input.GetKeyDown("R"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
