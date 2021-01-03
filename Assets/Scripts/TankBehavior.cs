using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehavior : MonoBehaviour
{

    public GameObject bullet;
    private float speed = 160f;
    public Transform shootPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject instantiatedPollo = Instantiate(bullet,
                                                           shootPosition.position,
                                                           shootPosition.rotation);

            instantiatedPollo.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);

        }
    }

    
    
}
