using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];
    public float torque = 100;
    public float steeringMax = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        FindWheels();
    }

    private void FindWheels()
    {
        GameObject[] foundWheels = GameObject.FindGameObjectsWithTag("Wheels");
        for (int i = 0; i < wheels.Length && i < foundWheels.Length; i++)
        {
            wheels[i] = foundWheels[i].GetComponent<WheelCollider>();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            for (int i = 0; i < wheels.Length; i++)
                wheels[i].motorTorque = torque;
        }
        else
        {
            for (int i = 0; i < wheels.Length; i++)
                wheels[i].motorTorque = 0;

        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            for (int i = 0; i < wheels.Length - 2; i++)
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steeringMax;
        }
    }
}