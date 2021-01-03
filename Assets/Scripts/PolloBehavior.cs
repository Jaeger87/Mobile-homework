using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolloBehavior : MonoBehaviour
{
    private float mass;
    public GameObject polletto;
    public GameObject pulcino;

    // Start is called before the first frame update
    void Start()
    {
        mass = this.GetComponent<Rigidbody>().mass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        print("UN POLLOOOOOO" + mass);
        Destroy(this.gameObject);


    }
}
