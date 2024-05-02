using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class SnowSpawner : MonoBehaviour
{
    public GameObject snow;
    public float spawnInterval = 0.5f;

    void Start()
    {
        InvokeRepeating("spawnSnow", 0f, spawnInterval);
    }

    void spawnSnow()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f)+transform.position.x, -2f + transform.position.y, Random.Range(-5f, 5f)+transform.position.z);
        Instantiate(snow, spawnPosition, Quaternion.identity);
    }
}
