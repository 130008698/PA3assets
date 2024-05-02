using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private MovementManager movementManager;
    // Start is called before the first frame update
    private void Start()
    {
        // Assumes that the MovementManager is attached to the parent object or elsewhere in the hierarchy.
        movementManager = GetComponentInParent<MovementManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            // Continuously set the grounded state to true as long as the object stays on the ground or platform
            movementManager.SetGroundedState(true);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.CompareTag("Monster Start") && (!movementManager.monsterSE.isPlaying)){
            if(movementManager.grassSE.isPlaying){
                movementManager.grassSE.Stop();
            }
            movementManager.monsterSE.Play();
        }
    }
    // private void OnCollisionStay(Collision collision)
    // {
    //     // Check if the collision is with an object tagged as "Ground" or "Platform"
    //     if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
    //     {
    //         // Continuously set the grounded state to true as long as the object stays on the ground or platform
    //         movementManager.SetGroundedState(true);
    //     }
    // }
}
