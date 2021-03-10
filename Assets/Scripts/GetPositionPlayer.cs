using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPositionPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    // public socketConnection socket;
    //  public socketConnection socketConnection;

    //  private socketConnection socket;
    //  private gameObject hand;
    private GameObject hand;
    public CharacterController controller;
    private socketConnection socket;

    public Vector3 direction;

    public Vector3 position;

    private Animator anim;
    

    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    void socketDefinition(){
            // socket.socket.Emit("test-event");

            

            socket.socket.On("move-client", (ev) => 
            {
                //node server
                // socket.socket.Emit("test-event", direction.x, direction.z, speed);
                // socket.broadcast.emit('move-client', socket.id, directionX, directionZ, speed);

                Debug.Log("move-client");
                // Debug.Log(name);
                // Debug.Log(socket.client_id);
                // GameObject.Find(ev.Data[0].ToString()).transform.position = new Vector3 ((float)ev.Data[1], 1, (float)ev.Data[2]);
                // elPibe = GameObject.Find(ev.Data[0].ToString()).GetComponent("CharacterController");
                // new Vector3(direction.x, 0f, direction.z)

                
            


                if (name.ToString() == ev.Data[0].ToString())
                    {
                        // anim.SetFloat("VelX", (float)ev.Data[1]);
                        // anim.SetFloat("VelY", (float)ev.Data[2]);
                        GameObject elpibe = GameObject.Find(ev.Data[0].ToString());


                        // direction = new Vector3((float)ev.Data[1], 0f, (float)ev.Data[2]).normalized;
                        // Debug.Log(direction);
                        
                        // controller.Move(new Vector3((float)ev.Data[1], 0f, (float)ev.Data[2]).normalized * (float)ev.Data[3] * Time.deltaTime);
                        // transform.rotation = Quaternion.Euler(0f, (float)ev.Data[6], 0f);

                        // position.x = (float)ev.Data[4];
                        // position.z = (float)ev.Data[5];

                        // elpibe.transform.position = new Vector3((float)ev.Data[4], 0, (float)ev.Data[5]);
                        Debug.Log((float)ev.Data[4]);
                        //  Debug.Log((float)ev.Data[4]);

                        transform.position = new Vector3((float)ev.Data[4], (float)ev.Data[7], (float)ev.Data[5]);


                        // transform.rotation = Quaternion.Euler((float)ev.Data[1], 0, (float)ev.Data[2]);


                        // Rotate the cube by converting the angles into a quaternion.
                        // Quaternion target = Quaternion.Euler((float)ev.Data[1], 0, (float)ev.Data[2]);

                        // Dampen towards the target rotation
                        // transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);

                        // controller.Move(new Vector3((float)ev.Data[4], 2f, (float)ev.Data[5]));

                        // transform.position = new Vector3((float)ev.Data[4], 2f, (float)ev.Data[5]);
                        // position = new Vector3((float)ev.Data[4], 2f, (float)ev.Data[5]);
                        // transform.position = new Vector3((float)ev.Data[5], 2f, (float)ev.Data[4]);
                    }

            
            });
    }

    void Start()
    {
            // GameObject go = GameObject.Find("Socket");
            hand = GameObject.Find("/Socket");
            socket = hand.GetComponent("socketConnection") as socketConnection;
            // Debug.Log(hand);
            socketDefinition();
            anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // socketConnection.socket.Emit("test-event");
    }
}
