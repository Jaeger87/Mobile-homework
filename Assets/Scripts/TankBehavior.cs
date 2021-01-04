using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehavior : MonoBehaviour
{

    public GameObject bullet;
    private float speed = 160f;
    public Transform shootPosition;
    private AudioSource audioData;
    private float nextShoot;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        nextShoot = RandomGaussian(1.8f, 6.5f);
    }

    // Update is called once per frame
    void Update()
    {
        nextShoot -= Time.deltaTime;
        if (nextShoot < 0)
        {
            nextShoot = RandomGaussian(3, 8);
            shoot();
        }
    }

    private void FixedUpdate()
    {

    }

    private void shoot()
    {
        audioData.Play(0);
        GameObject instantiatedPollo = Instantiate(bullet,
                                                       shootPosition.position,
                                                       shootPosition.rotation);

        instantiatedPollo.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 1) * speed, ForceMode.Impulse);
    }


    public static float RandomGaussian(float minValue = 0.0f, float maxValue = 1.0f)
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }

}
