using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class WeaponAudioHandler : AudioHandler
    {
        public Sound[] swishSounds;

        private void Start()
        {
            SetupSounds(swishSounds);
        }

        public void PlaySwishSound(int index)
        {
            if (index >= swishSounds.Length)
            {
                Debug.LogWarning("swish sound index is larger than the array size!");
                return;
            }
            swishSounds[index].source.Play();
        }
    }
}
