using Meta.WitAi;
using Oculus.Voice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class speechdetector : MonoBehaviour
{
    // Start is called before the first frame update
    public AppVoiceExperience wit;
    private InputData inputData;
    public string word;
    void Start()
    {
        GameObject myXrOrigin = GameObject.Find("XR Origin (XR Rig)");
        inputData = myXrOrigin.GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("v")) {
            wit.Activate();
            Debug.Log("space pressed111");
        }

        if (inputData.rightController.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool tele)&& tele)
        {
            wit.Activate();
        }
    }

    public void transcription(string[] value)
    {
        Debug.Log(value[0]);
        word = value[0];
    }
}
