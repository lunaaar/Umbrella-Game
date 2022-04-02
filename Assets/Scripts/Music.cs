using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioClip backgroundClip;
    static Music _instance = null;
    // Start is called before the first frame update 
    void Start()
    {
        if (_instance == null)
        {
            _instance = this;

        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource source = GetComponent<AudioSource>();
        backgroundClip = source.clip;
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
}