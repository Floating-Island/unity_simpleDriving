using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float accelerationGain = 2f;
    [SerializeField] private float accelerationGainSecondsInterval = 0.5f;
    [SerializeField] private float accelerationGainStartSecondsDelay = 1f;
    [SerializeField] private float steerSpeed = 200f;

    private int steerValue = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("IncreaseAcceleration", accelerationGainStartSecondsDelay, accelerationGainSecondsInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Steer();
        Accelerate();
    }

    public void CaptureSteering(int value)
    {
        steerValue = value;
    }

    private void Steer()
    {
        transform.Rotate(0, steerValue * steerSpeed * Time.deltaTime, 0);
    }

    private void Accelerate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * acceleration);
    }

    private void IncreaseAcceleration()
    {
        acceleration += accelerationGain;
    }
}
