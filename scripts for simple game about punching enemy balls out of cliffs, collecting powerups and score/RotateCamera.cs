using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float speed = 50.0f;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
            

        float horizontal = Input.GetAxis("Horizontal");
      transform.Rotate(Vector3.up, Time.deltaTime * speed * horizontal);
    }
}
