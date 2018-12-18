﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGrounded : MonoBehaviour {

    public PlayerController control;
    Quaternion rotation;
    [HideInInspector]
    public bool IsGround;
    [HideInInspector]
    public bool IsGroundBounce;
    void Awake()
    {
        IsGround = false;
        IsGroundBounce = false;
        rotation = transform.rotation;
    }
    void Update()
    {
        transform.rotation = rotation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" && other.tag!="CheckPoint" && other.tag!="Room" && other.tag!="FindRoom")
        {
            control.NumBounce++;
            if (control.NumBounce >= 2)
                control.SavePowerJump = 0;
        }
        if (other.tag == "Ground" || other.tag == "Item" || other.tag == "Ring")
        {
            IsGround = true;
        }
        if (other.tag == "BounceGround")
        {
            IsGroundBounce = true;
            IsGround = true;
        }
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Item" || other.tag == "Ring")
        {
            IsGround = true;
        }
        if (other.tag == "BounceGround")
        {
            IsGroundBounce = true;
            IsGround = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Item" || other.tag == "Ring")
            IsGround = false;
        if (other.tag == "BounceGround")
        {
            IsGroundBounce = false;
            IsGround = false;
        }
    }

}
