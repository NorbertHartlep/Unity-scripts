//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 10.0f;
    public static float moveSpeed = 60.0f;
    //
    public static bool canMove = true;
    public static float leftRight;
    public static float upDown;
    private Rigidbody playerRb;
    public float gravity;
    //bool for not moving while collecting
    
    private float range = 280.0f;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
    playerRb = GetComponent<Rigidbody>();
    Physics.gravity *= gravity;
    }

    // Update is called once per frame
    void Update()
    {
        leftRight = Input.GetAxis("Horizontal");
        upDown = Input.GetAxis("Vertical");
        if(canMove){
        transform.Rotate(Vector3.up * Time.deltaTime * moveSpeed * leftRight);
    //moves while pressing up/down
        transform.Translate(Vector3.forward * Time.deltaTime * speed * upDown);
        }

    //dont allow to move more than -280x
        if(transform.position.x < -range)   
        {
            transform.position = new Vector3(-range, transform.position.y, transform.position.z);
        }

    //dont allow to move more than 280x
        if(transform.position.x > range)    
        {
            transform.position = new Vector3(range, transform.position.y, transform.position.z);
        }

    //dont allow to move more than -280z
        if(transform.position.z < -range)   
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -range);
        }

    //dont allow to move more than 280z
        if(transform.position.z > range)    
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, range);
        }
      if(Input.GetKeyDown(KeyCode.Space)){
        Shoot();
            //spawnuje objectilePrefab w miejscu w ktorym jest objekt do ktorego przypisany jest ten skrypt, i w tym samym kierunku w, ktorym pierwotnie jest ustawiony
            
        }
    }

    void Shoot(){
            Instantiate(bullet, transform.position, 
            Quaternion.Euler(0 ,transform.rotation.y, 0)
            );
    }
    void OnCollisionEnter(Collision collision)
    {
    
    }
}
