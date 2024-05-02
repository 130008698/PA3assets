using UnityEngine;
using TMPro;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public static int course = 0;
    private PhotonView photonView;
    private GameObject player;
    private MovementManager mm;
    private Rigidbody rb;
    private void Start(){
        statusText = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();

        // Find the player's body in the scene. Assuming it has a tag "PlayerBody"
        GameObject[] playerBodies = GameObject.FindGameObjectsWithTag("PlayerOG");
        foreach (var body in playerBodies)
        {
            Debug.Log("1");
            PhotonView pv = body.GetComponent<PhotonView>();
            if (pv != null && pv.Owner == PhotonNetwork.LocalPlayer)
            {
                player = body;
                Debug.Log("2");
                mm = player.GetComponentInChildren<MovementManager>();
                break;
            }
        }
        
        
    }
    private void Update()
    {

        // PhotonView[] playerViews = FindObjectsOfType<PhotonView>();
        // foreach (var view in playerViews) {
        // if (view.CompareTag("PlayerOG") && view.IsMine && course<3) {
        //     statusText.text = $"Course Completed: {course}/3";
        // }
        // }

        // if(gameObject.transform.position.y < -1){
        //     if(mm != null){
        //         mm.RestartCourse();
        //     }
        // }
        // if(Input.GetKeyDown("e")){
        //     course = 3;
        // }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    // // Assuming "PlayerOG" is the tag of one specific object and this script is attached to the other specific object
    //     if (collision.gameObject.CompareTag("hole"))
    //     {
    //         // This code block will only execute if the GameObject this script is attached to
    //         // collides with the GameObject tagged as "PlayerOG"
    //         course++;
    //         mm.scoreSE.Play();
    //         int result;
    //         result = mm.closestCourse();
    //         if(result == 1){
    //             mm.grass = true;
    //         }
    //         if(result == 2){
    //             mm.ice = true;
    //         }
    //         if(result == 3){
    //             mm.dirt = true;
    //         }
    //         PhotonNetwork.Destroy(gameObject);
    //     }
    //     if(collision.gameObject.CompareTag("Platform"))
    //     {
    //         if(mm != null){
    //             mm.RestartCourse();
    //         }
    //     }
    // }




}
