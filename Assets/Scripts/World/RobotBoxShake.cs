using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBoxShake : MonoBehaviour 
{
    float trauma = 0f;

    [Range(0f, 360f)]
    public float maxAngle = 60f;
    public float stress = 0.5f;
    public float traumaDecay = 0.25f;
    public float stressInterval = 8f;

    void Start()
    {
        InvokeRepeating("Stress", Random.Range(stressInterval / 2, stressInterval), stressInterval);
    }

    void Update()
    {
        trauma = Mathf.Clamp01(trauma - (traumaDecay * Time.deltaTime));
        float shake = trauma * trauma;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Quaternion.AngleAxis(maxAngle * shake * Random.Range(-1, 1), Vector3.forward) * Vector3.up);
    }

    public void Stress()
    {
        trauma += stress;
    }
}