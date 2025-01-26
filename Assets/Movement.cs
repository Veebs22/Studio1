using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody sphereRigidBody;
    public Collider sphereCollider;
    public float ballSpeed = 2f;
    public float distToGround, jumpSpeed,jumpGain,doubleInputCD;
    void Start()
    {
        distToGround = sphereCollider.bounds.extents.y;
        jumpGain = 5;
    }

    // Update is called once per frame
    void Update()
    {
        ballSpeed = isGrounded()? 5f :  0.75f;
        doubleInputCD = Mathf.Max(0f, doubleInputCD - Time.deltaTime);
        Vector2 inputVector = Vector2.zero; // intialize our input vector
        jumpSpeed = 0;
        if (Input.GetKey(KeyCode.W))
            {
            inputVector += Vector2.up; // "a += b" <=> "a = a + b"
            }
        
        if (Input.GetKey(KeyCode.S))
             {
           inputVector += Vector2.down;
            }
        
        if (Input.GetKey(KeyCode.D))
             {
             inputVector += Vector2.right;
             }
        
        if (Input.GetKey(KeyCode.A))
             {
             inputVector += Vector2.left;
             }
        if (Input.GetKey(KeyCode.Space)&& isGrounded() && doubleInputCD <=0)
        {
            jumpSpeed = 1;
            doubleInputCD = 0.05f;
        }

        Debug.Log("Resultant Vector: " + inputVector);
        Vector3 inputXYZPlane = new Vector3(inputVector.x, 0, inputVector.y);
        sphereRigidBody.AddForce(inputXYZPlane*ballSpeed);
        sphereRigidBody.AddForce(0, jumpSpeed*jumpGain, 0,ForceMode.VelocityChange);
    }

    bool isGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.05f);
    }
 
        
    
}
