using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class NetworkBallManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private PhotonView photonView1;
    private Rigidbody rb;
    private Collider collider1;
    [SerializeField] private Material ownerMaterial;
    [SerializeField] private Material nonOwnerMaterial;
    private Renderer myrenderer;
    void Start()
    {
        photonView1 = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        collider1 = GetComponent<Collider>();
        UpdateLayerBasedOnOwnership();
        myrenderer = GetComponent<Renderer>();
        if (photonView.IsMine)
        {
            GetComponent<Renderer>().material = ownerMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = nonOwnerMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateLayerBasedOnOwnership()
    {
        if (photonView1.IsMine)
        {
            
            // Optionally, also set the player's layer to "Owner"
        }
        else
        {
            if (rb != null) rb.isKinematic = true;  // Make Rigidbody kinematic to avoid physics calculations
            if (collider1 !=null) GetComponent<Collider>().enabled = false;
            gameObject.layer = LayerMask.NameToLayer("NonOwner");
            
        }
    }
}
