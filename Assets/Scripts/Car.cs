using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float accelerationGain = 2f;
    [SerializeField] private float accelerationGainSecondsInterval = 0.5f;
    [SerializeField] private float accelerationGainStartSecondsDelay = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("IncreaseAcceleration", accelerationGainStartSecondsDelay, accelerationGainSecondsInterval);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * acceleration);
    }

    private void IncreaseAcceleration()
    {
        acceleration += accelerationGain;
    }
}
