using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class HitAudioHandler : AudioHandler
    {
        public Sound[] bleedSounds;
        public Sound[] painSounds;
        public Sound deathSound;

        private int nextBleedSoundIndex = 0;
        private int nextPainSoundIndex = 0;

        private void Start()
        {
            SetupSounds(bleedSounds);
            SetupSounds(painSounds);
            SetupSound(deathSound);
        }

        public void PlayBleedSound()
        {
            if (nextBleedSoundIndex >= bleedSounds.Length)
            {
                nextBleedSoundIndex = 0;
            }

            bleedSounds[nextBleedSoundIndex].source.Play();
            nextBleedSoundIndex++;
        }

        public void PlayPainSound()
        {
            if (nextPainSoundIndex >= painSounds.Length)
            {
                nextPainSoundIndex = 0;
            }

            painSounds[nextPainSoundIndex].source.Play();
            nextPainSoundIndex++;
        }

        public void PlayDeathSound()
        {
            deathSound.source.Play();
        }
    }
}
