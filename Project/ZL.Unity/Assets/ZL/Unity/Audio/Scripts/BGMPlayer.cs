using System.Collections;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Audio
{
    [DisallowMultipleComponent]

    [RequireComponent(typeof(AudioSource))]

    public sealed class BGMPlayer : Singleton<BGMPlayer>
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private AudioSource audioSource;

        [Space]

        [SerializeField]

        private bool playOnAwake = true;

        [SerializeField]

        private BGMPlayMode playMode = BGMPlayMode.RepeatOne;

        public BGMPlayMode PlayMode { set => PlayMode = value; }

        [Space]

        [SerializeField]

        [Button(nameof(Play))]

        [Button(nameof(Pause))]

        [Button(nameof(Resume))]

        [Button(nameof(Next))]

        [Button(nameof(Prev))]

        private int playlistIndex = 0;

        [SerializeField]

        private Wrapper<AudioClip[]> playlist;

        private bool isLooping = false;

        protected override void OnAwake()
        {
            if (playOnAwake == true)
            {
                PlayLoop();
            }
        }

        private void Update()
        {
            if (isLooping == true)
            {
                if (audioSource.isPlaying == false)
                {
                    switch (playMode)
                    {
                        case BGMPlayMode.RepeatOne:

                            Play();

                            break;

                        case BGMPlayMode.RepeatAll:

                            Next();

                            break;

                        case BGMPlayMode.Reverse:

                            Prev();

                            break;

                        case BGMPlayMode.Shuffle:

                            while (true)
                            {
                                Random.Range(0, playlist.value.Length, out int index);

                                if (playlistIndex != index)
                                {
                                    playlistIndex = index;

                                    break;
                                }
                            }

                            Play();

                            break;
                    }
                }
            }
        }

        public void PlayLoop(int index)
        {
            playlistIndex = index;

            PlayLoop();
        }

        public void PlayLoop()
        {
            isLooping = true;

            Play();
        }

        public void Play()
        {
            audioSource.clip = playlist.value[playlistIndex];

            audioSource.Play();
        }

        public void Pause()
        {
            isLooping = false;

            audioSource.Pause();
        }

        public void Resume()
        {
            isLooping = true;

            audioSource.Play();
        }

        public void Next()
        {
            ++playlistIndex;

            if (playlistIndex > playlist.value.Length - 1)
            {
                playlistIndex = 0;
            }

            Play();
        }

        public void Prev()
        {
            --playlistIndex;

            if (playlistIndex < 0)
            {
                playlistIndex = playlist.value.Length - 1;
            }

            Play();
        }

        public enum BGMPlayMode
        {
            RepeatOne,

            RepeatAll,

            Reverse,

            Shuffle,
        }
    }
}