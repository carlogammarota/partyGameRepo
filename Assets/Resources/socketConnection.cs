using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dpoch.SocketIO;
using UnityEngine.UI;
// using System.Collections.Generic;
// using UnityEngine.Object;

public class socketConnection : MonoBehaviour
{
    	// /*
    // class MyCustomJsonClass{
    //     public string myMember;
    // }
	// */
    // Start is called before the first frame update
    // public CharacterController player;
    
    public SocketIO socket;
    // public SocketIO socket { get { return ws; } }
    // public Singleton Instance;
    // public float horizontalMove;
    // public float verticalMove;
    // public Transform playerStart;
    // public Vector3 player;

    public Text usersOnline;

    public Transform target;

    private Transform playerPos;

    public string client_id;
    // public Transform playerScript;

    private GameObject playerObject;

    private Transform myTransform;

    // public Transform prefab;
    void Awake()
    {
        // Instantiate (Resources.Load ("player") as GameObject);


        


        
        if (socket == null)
        {
            GetSocketConnection();    
        }
        // Instantiate(playerStart, transform.position, transform.rotation);
        // playerStart.name = "carlo";

        // GameObject thePlayer = GameObject.Find("Plane");
        // playerScript = thePlayer.GetComponent<Transform>();
        // Debug.Log(playerScript);
        // player =  GameObject.Find("carlo").transform.position;

        // horizontalMove
        // GetSocketConnection();

        

    }

    public void getInt(){
        // return socket;
        Debug.Log("Este es el script SOCKETCONNECTION");
        // return socket;
    }

    public void GetSocketConnection(){
        
        //CONFIG LOCAL
        // socket = new SocketIO("ws://localhost:3000/socket.io/?EIO=4&transport=websocket");

        //CONFIG HEROKU SERVER

        socket = new SocketIO("ws://electronic-server.herokuapp.com/socket.io/?EIO=4&transport=websocket");


        // Debug.Log("GetSocketConnection!");

        

        

        socket.OnOpen += () => {
                Debug.Log("Connected! BY SOCKETCONNECTION");
                // socket.Emit("getUsers");

        };

        socket.On("clientsOnline", (ev) => {
                Debug.Log("Socket ID");
                Debug.Log(ev.Data[2].ToString());
                
                // socket.Emit('getUsers');
                // for (int i = 0; i < (float)ev.Data[1] - 1; i++)
                for (int i = 0; i < (float)ev.Data[1] - 1; i++)
                {
                    Debug.Log("creando nuevo player");
                    Instantiate(Resources.Load ("player22") as GameObject).name = ev.Data[0][i]["_id"].ToString();
                    // console.log('some=event', socket.id ,directionX, directionZ, speed, positionX, positionZ);
                }
                // usersOnline.text = "Users: " + ((float)ev.Data[1]);

        });


        socket.On("getIdCliente", (ev) => {
            // Debug.Log(ev.Data[0].ToString());
            var id = ev.Data[0].ToString();
            playerObject = GameObject.Find("/player");
            playerObject.name = id;
            client_id = ev.Data[0].ToString();

        });

        socket.On("disconnectClient", (ev) => {
            Debug.Log("Un Usuario se a Desconectado");
            
            Destroy(GameObject.Find(ev.Data[0].ToString()));
            // usersOnline.text = "Users: " + ((float)ev.Data[1]);
        });
        socket.On("Users", (ev) => {
            // usersOnline.text = "Users: " + (float)ev.Data[0];
            // Debug.Log("Un Usuario se a Desconectado");
            // Destroy(GameObject.Find(ev.Data[0].ToString()));
            // usersOnline.text = "Users: " + (float)ev.Data[0];
        });

        socket.On("agregarJugador", (ev) => {
            Instantiate(Resources.Load ("player22") as GameObject).name = ev.Data[0].ToString();
        });
        socket.OnConnectFailed += () => {
            Debug.Log("Connection failed.");
            StartCoroutine(ExampleCoroutine());
        };
        socket.OnClose += () => {
            Debug.Log("Connection closed.");
            Debug.Log("Reconect");
            //  Reconnect(ExampleCoroutine());
            StartCoroutine(ExampleCoroutine());
            // interval

        };
        socket.OnError += (err) => {
            Debug.Log("Error: " + err);
        };

        socket.Connect();
    }

    
    
//    IEnumerator Reconnect()
//     {
//         //Print the time of when the function is first called.
//         Debug.Log("Started Coroutine at timestamp : " + Time.time);

//         //yield on a new YieldInstruction that waits for 5 seconds.
//         yield return new WaitForSeconds(5);
//         GetSocketConnection();
//         //After we have waited 5 seconds print the time again.
//         Debug.Log("Finished Coroutine at timestamp : " + Time.time);
//     }
     IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        GetSocketConnection();

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }


}
