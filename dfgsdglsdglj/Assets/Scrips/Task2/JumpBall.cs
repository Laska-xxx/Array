using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBall : MonoBehaviour
{
    [SerializeField] Color[] colors;
    [SerializeField] int speedThreshold;    
    [SerializeField] private MeshRenderer render;
    [SerializeField] private Rigidbody rb;
    private bool changeColor = false;
    private float curTime;

    private void Update()
    {
        curTime += Time.deltaTime;
        if (Mathf.Abs(rb.velocity.y) < speedThreshold && changeColor == true) 
        {
            Debug.Log(curTime);
            curTime = 0;
            changeColor = false;
            ChangeColor();
        }
        if(Mathf.Abs(rb.velocity.y) > speedThreshold)
        {
            changeColor = true;
        }
    }

    private void ChangeColor()
    {
        render.material.color = colors[UnityEngine.Random.Range(0, colors.Length)];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            ChangeColor();
        }
    }
}
