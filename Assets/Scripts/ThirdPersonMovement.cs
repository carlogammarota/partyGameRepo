using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{

    public Text nombre;
    // public Text rightText;

    public CharacterController controller;

    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;
    // Update is called once per frame

    // public Vector3 position;
    private socketConnection socket;

    // public SimpleTouchController leftController;
    // public SimpleTouchController rightController;
	// public SimpleTouchController rightController;
    public Vector3 direction;

    // public Transform carloPosicion;

    float horizontal;
    float vertical;

    // private Animator anim;

    void Start() {
        GameObject hand = GameObject.Find("/Socket");
        // carloPosicion = GetComponent<Transform>();
        socket = hand.GetComponent("socketConnection") as socketConnection;

        // anim = GetComponent("Animator");
        // anim = GetComponent<Animator>();
        // sendData();
        // send_ID();
    }

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


        // Debug.Log("posicion");
        // Debug.Log(carloPosicion.x);

        // anim.SetFloat("VelX", horizontal);
        // anim.SetFloat("VelY", vertical);

        direction = new Vector3(horizontal, 0f, vertical).normalized;


        // Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Debug.Log(direction);
        // Vector3 directionTouch = new Vector3(leftController.GetTouchPosition.x, 0f, leftController.GetTouchPosition.y).normalized;
        // Debug.Log(directionTouch);

        // if(rightController.GetTouchPosition.x >= 0.1f || rightController.GetTouchPosition.y >= 0.1f){
            // transform.RotateAround (transform.position, -Vector3.up, -rightController.GetTouchPosition.x * 10); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        //  transform.RotateAround(Vector3.zero, transform.right, new Vector3(0f, 0f, 0f));
            // transform.RotateAround (Vector3.zero, transform.right, -rightController.GetTouchPosition.y * 10); 


        // }
        

        // if(directionTouch.magnitude >= 0.1f){
        //     Debug.Log("emit emit emit");
            // controller.Move(directionTouch * speed * Time.deltaTime);

                
        //  float rotateHorizontal = Input.GetAxis ("Mouse X");
        //  float rotateVertical = Input.GetAxis ("Mouse Y");
        //  Debug.Log(rotateVertical);
        //  Quaternion.Inverse(rotateVertical);
// again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player
        //  transform.Rotate(transform.right * rotateVertical * 10);
     

            // socket.socket.Emit("test-event", directionTouch.x, directionTouch.z, speed, transform.position.x, transform.position.z);

            // float targetAngle = Mathf.Atan2(directionTouch.x, directionTouch.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // transform.rotation = Quaternion.Euler(0f, angle, 0f);
            // Debug.Log(angle);
            // Vector3 moveDire = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            // sendData();
            // socket.socket.Emit("test-event", direction.x, direction.z, speed, transform.position.x, transform.position.z, angle);
            // controller.Move(moveDire.normalized * speed * Time.deltaTime);
        // }

        if(direction.magnitude >= 0.1f)
        {


            // sendData();

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // transform.rotation = Quaternion.Euler(0f, angle, 0f);
            // Debug.Log(angle);
            Vector3 moveDire = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // socket.socket.Emit("position", direction.x, direction.z, speed, transform.position.x, transform.position.z, angle);
            controller.Move(moveDire.normalized * speed * Time.deltaTime);
            // socket.socket.Emit("position", 0, 0, speed, transform.position.x, transform.position.z);
            socket.socket.Emit("position", direction.x, direction.z, speed, transform.position.x, transform.position.z, angle, transform.position.y);
            
            
          

        }

    }

    void sendData(){
            
            // float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // Vector3 moveDire = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            // controller.Move(moveDire.normalized * speed * Time.deltaTime);
            // transform.rotation = Quaternion.Euler(0f, angle, 0f);
            // transform.rotation = Quaternion.Euler(0f, angle, 0f);
            // Debug.Log(transform.position.x);
            
            
            // socket.socket.Emit("position", 0, 0, speed, transform.position.x, transform.position.z, 0);
            // socket.socket.Emit("position", direction.x, direction.z, speed, transform.position.x, transform.position.z, angle);
            


    }

    void send_ID(){
        sendData();
        socket.socket.Emit("set_name", "Charly G");
    }
}
