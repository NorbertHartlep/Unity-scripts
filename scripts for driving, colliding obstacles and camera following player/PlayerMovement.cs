using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//working movement script 3D, add to player
public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;

    private float turnSpeed = 45.0f;
   
    private float horizontalInput;
    private float forwardlInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        forwardlInput = Input.GetAxis("Vertical");
        //We'll move the vechicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardlInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
