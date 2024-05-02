using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkGrabManager : XRGrabInteractable
{
    private PhotonView photonView;
    private Collider myCollider;
    protected override void Awake()
    {
        base.Awake();
        photonView = GetComponent<PhotonView>();
        myCollider = GetComponent<Collider>();
        UpdateInteractability(); // Call this here to set initial state
    }

    // protected override void OnSelectEntered(SelectEnterEventArgs args)
    // {
    //     if (photonView.IsMine)
    //     {
    //         base.OnSelectEntered(args); // Proceed with the base method if the user is the owner
    //     }
    //     else
    //     {
    //         Debug.Log("You do not own this object!"); // Provide feedback if not the owner
    //     }
    // }

    void Update()
    {
         // Optionally check ownership status regularly in Update
    }

    private void UpdateInteractability()
    {
        this.enabled = photonView.IsMine; // Enable or disable this XRGrabInteractable based on ownership
        myCollider.enabled = photonView.IsMine;
    }
}
