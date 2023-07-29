using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody playerBody;
    private CharacterController charController;

    public float jumpForce = 3.0f;
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public bool relativeToWorld = true;
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //gravity
        movement.y = gravity;

        // limit speed for diagonal move
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        //tranform movement from Local to Global coordinates
        movement = transform.TransformDirection(movement);
        
        
        print("hello from move script");
        print(movement);


        if(Input.GetKeyDown(KeyCode.Space)){
                                            
            Vector3 jumpMovement = new Vector3(deltaX,jumpForce, deltaZ);
            charController.Move(jumpMovement);
        }else{
              charController.Move(movement);
        }   
    }

    void Update2()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //gravity
        movement.y = gravity;

        // limit speed for diagonal move
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *=Time.deltaTime;
        //tranform movement from Local to Global coordinates
        movement = transform.TransformDirection(movement);
        
        

        if(Input.GetKeyDown(KeyCode.Space)){
              playerBody.AddForce(Vector3.up * 5.0f, ForceMode.VelocityChange);
              print("Player is jumping");                
        }

        charController.Move(movement);
    }
}
