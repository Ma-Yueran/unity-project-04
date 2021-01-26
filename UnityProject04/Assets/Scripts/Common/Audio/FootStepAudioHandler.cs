using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class FootStepAudioHandler : AudioHandler
    {
        public Sound[] stepSounds;
        public Sound[] slideSounds;

        private int nextStepSoundIndex = 0;

        private void Start()
        {
            SetupSounds(stepSounds);
            SetupSounds(slideSounds);
        }

        public void PlayFootStepSound()
        {
            if (nextStepSoundIndex >= stepSounds.Length)
            {
                nextStepSoundIndex = 0;
            }

            stepSounds[nextStepSoundIndex].source.Play();
            nextStepSoundIndex++;
        }

        public void PlaySlideSound(int index)
        {
            if (index >= slideSounds.Length)
            {
                Debug.LogWarning("slide sound index is larger than the array length");
            }
            slideSounds[index].source.Play();
        }
    }
}
