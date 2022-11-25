using System.Diagnostics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame//LateUpdate dziala tak samo, tyle ze po poleceniach w srodku
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        Debug.Log("Hello world!");
    }
}