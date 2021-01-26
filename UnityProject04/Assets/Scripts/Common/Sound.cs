using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace MYR
{
    [System.Serializable]
    public class Sound
    {
        public AudioClip audioClip;
        [Range(0f, 1f)]
        public float volume;
        [Range(0.3f, 2f)]
        public float pitch;
        public bool loop;
        public GameObject sourceObject;
        [Range(0f, 1f)]
        public float spatialBlend;

        [HideInInspector]
        public AudioSource source;
    }
}
