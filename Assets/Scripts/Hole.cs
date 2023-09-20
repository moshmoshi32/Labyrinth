using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Hole : MonoBehaviour
{
    [SerializeField] private PointsSO point;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Ball>();
        if (player)
        {
            if (point.isEnd)
            {
                //TODO: Tell UI that player won and give points.
                Debug.Log("You won!");
                return;
            }
            player.AddToScore(point.amountPoints);
        }
    }
}
