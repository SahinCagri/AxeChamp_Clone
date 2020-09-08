﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "knife")
        {
            GameManager.gameManagerInstance.StartGameOverSequence();
        }
    }
}
