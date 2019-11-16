using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private AudioSource[] audioSources;

    private AudioSource activeAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        activeAudioSource = audioSources[Random.Range(0, 2)];
        activeAudioSource.Play();
    }
}
