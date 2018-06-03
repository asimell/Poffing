﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaController : PlayerController {

    private float waitBetweenJump = 0.1f;
    private float nextJump = 0f;

    public override void PlayerAction()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround && Time.time >= nextJump)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            nextJump = Time.time + waitBetweenJump;
        }
    }
}
