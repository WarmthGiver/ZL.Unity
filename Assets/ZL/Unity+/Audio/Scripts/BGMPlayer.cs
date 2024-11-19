using System.Collections;

using UnityEngine;

namespace ZL.Audio
{
    public enum PlayMode
    {
        RepeatOne,

        RepeatAll,

        Reverse,

        Shuffle,
    }

    [DisallowMultipleComponent]

    [RequireComponent(typeof(AudioSource))]

    public sealed class BGMPlayer : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private AudioSource audioSource;

        [Space]

        [SerializeField]

        private bool playOnAwake = true;

        [SerializeField]

        private PlayMode playMode = PlayMode.RepeatOne;

        public PlayMode PlayMode { set => PlayMode = value; }

        [Space]

        [SerializeField]

        private int playlistIndex = 0;

        private int playlistIndexMax;

        [SerializeField]

        private AudioClip[] playlist;

        private bool isLooping = false;

        private void OnValidate()
        {
            playlistIndex = playlistIndex.Clamp(0, playlist.Length - 1);
        }

        private void Awake()
        {
            playlistIndexMax = playlist.Length - 1;

            loopPlaylistRoutine = LoopPlaylistRoutine();

            if (playOnAwake)
            {
                LoopPlaylist();
            }
        }

        public void LoopPlaylist(int index)
        {
            playlistIndex = index;

            LoopPlaylist();
        }

        public void LoopPlaylist()
        {
            PlayCurrent();

            StartLoopPlaylistRoutine();
        }

        public void Resume()
        {
            audioSource.Play();

            StartLoopPlaylistRoutine();
        }

        public void Pause()
        {
            audioSource.Pause();

            StopLoopPlaylistRoutine();
        }

        private void StartLoopPlaylistRoutine()
        {
            if (!isLooping)
            {
                isLooping = true;

                StartCoroutine(loopPlaylistRoutine);
            }
        }

        private void StopLoopPlaylistRoutine()
        {
            if (isLooping)
            {
                isLooping = false;

                StopCoroutine(loopPlaylistRoutine);
            }
        }

        private IEnumerator loopPlaylistRoutine;

        private IEnumerator LoopPlaylistRoutine()
        {
            while (true)
            {
                if (!audioSource.isPlaying)
                {
                    switch (playMode)
                    {
                        case PlayMode.RepeatOne:

                            break;

                        case PlayMode.RepeatAll:

                            ++playlistIndex;

                            if (playlistIndex > playlistIndexMax)
                            {
                                playlistIndex = 0;
                            }

                            break;

                        case PlayMode.Reverse:

                            --playlistIndex;

                            if (playlistIndex < 0)
                            {
                                playlistIndex = playlistIndexMax;
                            }

                            break;

                        case PlayMode.Shuffle:

                            while (true)
                            {
                                Random.Range(0, playlistIndexMax, out int index);

                                if (playlistIndex != index)
                                {
                                    playlistIndex = index;

                                    break;
                                }
                            }

                            break;
                    }

                    PlayCurrent();
                }

                yield return null;
            }
        }

        private void PlayCurrent()
        {
            audioSource.clip = playlist[playlistIndex];

            audioSource.Play();
        }
    }
}