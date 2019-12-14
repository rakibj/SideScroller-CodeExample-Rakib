using System;
using RakibUtils;
using UnityEngine;

namespace _Project.Scripts.Generic
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip deathClip;
        private AudioSource m_audioSource;

        private void Awake()
        {
            m_audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            GameEvents.gameOver += PlayDeathAudio;
        }

        private void OnDisable()
        {
            GameEvents.gameOver -= PlayDeathAudio;
        }

        private void PlayDeathAudio(int score)
        {
            m_audioSource.PlayOneShot(deathClip, 1);
        }
    }
}
