using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class ScoreCount : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;
    public static int grassSC = 0;
    public static int iceSC = 0;
    public static int dirtSC = 0;
    public TextMeshProUGUI statusText;
    private float scoreCooldown = 1.0f;
    private float lastScoreTime = -1.0f;
    public bool grass = true;
    public bool ice = false;
    public bool dirt = false;

    void Start()
    {
        statusText = GameObject.Find("Tele").GetComponent<TextMeshProUGUI>();
        PhotonView[] playerViews = FindObjectsOfType<PhotonView>();
        foreach (var view in playerViews) {
        if (view.CompareTag("PlayerOG") && view.IsMine) {
            statusText.text = $"Score: {score}\nGrassSC: {grassSC}\nIceSC: {iceSC}\nDirtSC: {dirtSC}";
        }
        }
    }



    // Update is called once per frame
    void Update()
    {
        PhotonView[] playerViews = FindObjectsOfType<PhotonView>();
        foreach (var view in playerViews) {
        if (view.CompareTag("PlayerOG") && view.IsMine) {
            statusText.text = $"Score: {score}\nGrassSC: {grassSC}\nIceSC: {iceSC}\nDirtSC: {dirtSC}";
        }
        }
        if(Input.GetKeyDown("e")){
            score = 50;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    // Assuming "PlayerOG" is the tag of one specific object and this script is attached to the other specific object
        if (collision.gameObject.CompareTag("Ball"))
        {
            // This code block will only execute if the GameObject this script is attached to
            // collides with the GameObject tagged as "PlayerOG"
            if (Time.time - lastScoreTime >= scoreCooldown)
            {
                lastScoreTime = Time.time;
                score++;
                if(grass == true){
                    grassSC++;
                }
                if(dirt == true){
                    dirtSC++;
                }
                if(ice == true){
                    iceSC++;
                }
            }
        }
    }
}
