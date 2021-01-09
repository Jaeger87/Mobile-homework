using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolloBehavior : MonoBehaviour
{
    private float mass;
    public GameObject polletto;
    public GameObject pulcino;

    private AudioSource audioData;
    private float timeToLive = 4.0f;

    // Start is called before the first frame update
    public void Start()
    {
        audioData = GetComponent<AudioSource>();
        mass = this.GetComponent<Rigidbody>().mass;

        if (audioData != null && mass > 8)
            audioData.Play(0);
    }

    // Update is called once per frame
    public void Update()
    {
        timeToLive -= Time.deltaTime;
        
        if(timeToLive < 0)
            Destroy(this.gameObject);

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (mass > 9)
        {
            generateChild(polletto);
            generateChild(polletto);
            Destroy(this.gameObject);
            return;
        }


     if (mass > 4)
        {
                if (timeToLive > 3.8)
                    return;

            generateChild(pulcino);
            generateChild(pulcino);
            Destroy(this.gameObject);
            return;
        }
     
  
    }


    private void generateChild(GameObject kind)
    {
        Vector3 oldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 oldVelocity = this.GetComponent<Rigidbody>().velocity;
        oldPosition.Set(oldPosition.x, oldPosition.y, oldPosition.z);

        //oldPosition.normalized

        GameObject polletto1 = Instantiate(kind,
                               oldPosition,
                               transform.rotation);
        Vector3 polletto1Velocity = new Vector3(oldVelocity.normalized.x, oldVelocity.normalized.y, oldVelocity.normalized.z);
        polletto1Velocity.Scale(new Vector3(Random.value < .5 ? 1 : -1, Random.value < .5 ? 1 : -1, Random.value < .5 ? 1 : -1));
        polletto1.GetComponent<Rigidbody>().AddForce(polletto1Velocity * Random.Range(25, 48), ForceMode.Impulse);
    }


}
