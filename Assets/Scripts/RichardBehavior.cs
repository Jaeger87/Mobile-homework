using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardBehavior : MonoBehaviour
{
    private const float thresholdToTalk = 0.06f;
    private AudioSource[] richardVoices;

    // Start is called before the first frame update
    public void Start()
    {
        richardVoices = GetComponents<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Random.Range(0f,1f) < thresholdToTalk)
        {
            int indexToPlay = Random.Range(0, 2);
            richardVoices[indexToPlay].Play(0);
        }
    }
}
