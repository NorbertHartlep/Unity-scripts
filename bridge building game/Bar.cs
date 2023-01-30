using System.Threading;
using System.Reflection.Metadata.Ecma335;
using System.Net.NetworkInformation;
using System.Transactions;
using System.Xml.Xsl;
using System.Threading.Tasks.Dataflow;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float Cost = 1;
    public float maxLength = 1;
    public Vector2 StartPosition;
    public SpriteRenderer barSpriteRenderer;
    public BoxCollider2D boxCollider;
    public HingeJoint2D StartJoint;
    public HingeJoint2D EndJoint;

    float StartJointCurrentLoad = 0;
    float EndJointCurrentLoad = 0;
    MaterialPropertyBlock propBlock;
    public float actualCost;
    public void UpdateCreatingBar(Vector2 ToPosition)
    {
        transform.position = (ToPosition + StartPosition) / 2;

        Vector2 dir = ToPosition - StartPosition;
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));

        float Length = dir.magnitude;
        barSpriteRenderer.size = new Vector2(Length, barSpriteRenderer.size.y);

        boxCollider.size = barSpriteRenderer.size;

        actualCost = Length * Cost;
    }

    public void UpdateMaterial()
    {
        if(StartJoint != null) StartJointCurrentLoad = StartJoint.reactionForce.magnitude / StartJoint.breakForce;
        if(EndJoint != null) EndJointCurrentLoad = EndJoint.reactionForce.magnitude / EndJoint.breakForce;
        float maxLoad = MathF(StartJointCurrentLoad,EndJointCurrentLoad);
    
        propBlock = new MaterialPropertyBlock();
        barSpriteRenderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_Load",maxLoad);
        barSpriteRenderer.SetPropertyBlock(propBlock);
    }

    private void Update()
    {
        if(Time.timeScale == 1) UpdateMaterial();
    }
}