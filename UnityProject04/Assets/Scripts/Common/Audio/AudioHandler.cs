using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public abstract class AudioHandler : MonoBehaviour
    {
        protected void SetupSound(Sound sound)
        {
            sound.source = sound.sourceObject.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.spatialBlend = sound.spatialBlend;
        }

        protected void SetupSounds(Sound[] sounds)
        {
            foreach (Sound sound in sounds)
            {
                SetupSound(sound);
            }
        }
    }
}
