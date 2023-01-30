using System.Security.Cryptography;
using System.Numerics;
using System.IO.Enumeration;
using System.Xml.Xsl;
using System.Transactions;
using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Point : MonoBehaviour
{
public bool Runtime = true;
public Rigidbody2D rbd;
public Vector2 PointID;
public List<Bar> ConnectedBars;


    private void Start()
    {
        if(Runtime == false)
        {
            rbd.bodyType = RigidbodyType2D.Static;
            PointID = transform.position;
            if(GameManager.AllPoints.ContainsKey(PointID) == false)
            {
                GameManager.AllPoints.Add(PointID, this);
            }
        }
    }    
    private void Update()
    {
        if(Runtime == false)
        {//making the position actual
            if(transform.hasChanged == true)
            {//move by int values
                transform.hasChanged == false;
                transform.position == Vector3Int.RoundToInt(transform.position);
            }
        }
    }
}