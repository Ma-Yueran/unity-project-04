using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class AudioHandler : MonoBehaviour
    {
        public Sound[] sounds;

        private void Start()
        {
            foreach (Sound sound in sounds)
            {
                sound.source = sound.sourceObject.AddComponent<AudioSource>();
                sound.source.clip = sound.audioClip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;
            }
        }

        public void PlaySound(string soundName)
        {
            foreach (Sound sound in sounds)
            {
                if (sound.soundName.Equals(soundName))
                {
                    sound.source.Play();
                }
            }
        }
    }
}
