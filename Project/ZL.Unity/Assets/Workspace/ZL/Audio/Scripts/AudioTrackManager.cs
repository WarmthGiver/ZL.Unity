using UnityEngine;
using UnityEngine.Serialization;
using ZL.CS;

using ZL.CS.Singleton;

using ZL.Unity.Singleton;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Track Manager (Singleton)")]

    public sealed class AudioTrackManager : PrimaryMonoSingleton<AudioTrackManager>, IPrimaryMonoSingleton<AudioTrackManager>
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private AudioSource audioSource = null;

        [Space]

        [SerializeField]

        private string trackName = "";

        [Space] 

        [SerializeField]

        private bool playOnAwake = true;

        [PropertyField]

        [Button(nameof(Play))]

        [Button(nameof(Pause))]

        [Button(nameof(Resume))]

        [UsingCustomProperty]

        [SerializeField]

        private AudioTrackPlayMode playMode = AudioTrackPlayMode.RepeatOne;

        public AudioTrackPlayMode PlayMode
        {
            set => playMode = value;
        }

        [Space]

        [ToggleIf("playMode", AudioTrackPlayMode.Shuffle, true)]

        [UsingCustomProperty]

        [SerializeField]

        private int trackNumber = 0;

        [SerializeField]

        private AudioClip[] trackList = null;

        private bool isLooping = false;

        #if UNITY_EDITOR

        [HideInInspector]

        public bool isPlayModeShuffle = false;

        private void OnValidate()
        {
            isPlayModeShuffle = playMode == AudioTrackPlayMode.Shuffle;
        }

        #endif

        private void Start()
        {
            if (playOnAwake == true)
            {
                PlayLoop();
            }
        }

        private void Update()
        {
            if (isLooping == true && audioSource.isPlaying == false)
            {
                Play();
            }
        }

        bool ISingleton<AudioTrackManager>.IsDuplicated()
        {
            if (Instance != null)
            {
                if (Instance.trackName == trackName)
                {
                    return true;
                }

                DestroyImmediate(Instance.gameObject);
            }

            return false;
        }

        public void PlayLoop(int index)
        {
            trackNumber = index;

            PlayLoop();
        }

        public void PlayLoop()
        {
            isLooping = true;
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

        public void Play()
        {
            switch (playMode)
            {
                case AudioTrackPlayMode.RepeatAll:

                    ++trackNumber;

                    if (trackNumber > trackList.Length - 1)
                    {
                        trackNumber = 0;
                    }

                    break;

                case AudioTrackPlayMode.Reverse:

                    --trackNumber;

                    if (trackNumber < 0)
                    {
                        trackNumber = trackList.Length - 1;
                    }

                    break;

                case AudioTrackPlayMode.Shuffle:

                    trackNumber = Random.Range(0, trackList.Length);

                    break;
            }

            if (trackNumber.IsOutOfRange(0, trackList.Length - 1) == true)
            {
                return;
            }

            audioSource.clip = trackList[trackNumber];

            audioSource.Play();
        }
    }
}