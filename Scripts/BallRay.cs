using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class BallRay : MonoBehaviour
{
    public bool restart;



    public void HandleHoverEnter()
    {
        restart = true;
        Debug.Log("Ray is hitting the ball!");
    }

    public void HandleHoverExit()
    {
        restart = false;
        Debug.Log("Ray is no longer hitting the ball!");
    }
}
