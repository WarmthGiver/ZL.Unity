using UnityEngine;

namespace ZL.EulerianTrail.Demo
{
    using ZL.Collections;

    [DisallowMultipleComponent]

    public sealed class EulerianTrailDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponentInChildrenOnly, ReadOnly]

        private EulerianTrail eulerianTrail;

        [Space]

        [SerializeField]

        private int level = 0;

        private EulerianTrailInfo[] eulerianTrailInfos;

        private int maxLevel;

        private void Awake()
        {
            eulerianTrailInfos = new EulerianTrailInfo[]
            {
                new
                (
                    Vertices2.Dots(180f, 2, 2),

                    new int[][]
                    {
                        new int[]{ 1, 2 },

                        new int[]{ 3 },

                        new int[]{ 3 },
                    }
                ),

                new
                (
                    Vertices2.Dots(180f, 2, 2),

                    new int[][]
                    {
                        new int[]{ 1, 2, 3 },

                        new int[]{ 3 },

                        new int[]{ 3 },
                    }
                ),

                new
                (
                    Vertices2.Map(180f, new char[][]
                    {
                        new char[]{ 'O', 'O', 'O' },

                        new char[]{ 'O', ' ', 'O' },
                    }),

                    new int[][]
                    {
                        new int[]{ 1, 3 },

                        new int[]{ 2, 3, 4 },

                        new int[]{ 4 },

                        new int[]{ 4 },
                    }
                 ),

                new
                (
                    Vertices2.Map(180f, new char[][]
                    {
                        new char[]{ 'O', 'O', 'O' },

                        new char[]{ 'O', ' ', 'O' },

                        new char[]{ 'O', 'O', 'O' },
                    }),

                    new int[][]
                    {
                        new int[]{ 1, 3 },

                        new int[]{ 2, 3, 4 },

                        new int[]{ 4 },

                        new int[]{ 5, 6 },

                        new int[]{ 6, 7 },

                        new int[]{ 6 },

                        new int[]{ 7 },
                    }
                 ),

                new
                (
                    Vertices2.Dots(180f, 2, 3),

                    new int[][]
                    {
                        new int[]{ 1, 3, 4 },

                        new int[]{ 2, 4, 5 },

                        new int[]{ 5 },

                        new int[]{ 4 },

                        new int[]{ 5 },
                    }
                 ),

                new
                (
                    Vertices2.Dots(180f, 3, 3),

                    new int[][]
                    {
                        new int[]{ 1, 3, 4 },

                        new int[]{ 2, 4, 5 },

                        new int[]{ 5 },

                        new int[]{ 4, 6, 7 },

                        new int[]{ 5, 7, 8 },

                        new int[]{ 8 },

                        new int[]{ 7 },

                        new int[]{ 8 },
                    }
                 ),

                new
                (
                    Vertices2.Dots(180f, 2, 2),

                    new int[][]
                    {
                        new int[]{ 2, 3 },

                        new int[]{ 2, 3 },
                    }
                ),

                new
                (
                    Vertices2.Map(180f, new char[][]
                    {
                        new char[]{ 'O', ' ', 'O' },

                        new char[]{ 'O', 'O', 'O' },

                        new char[]{ 'O', ' ', 'O' },
                    }),

                    new int[][]
                    {
                        new int[]{ 2, 3 },

                        new int[]{ 3, 4 },

                        new int[]{ 3, 5 },

                        new int[]{ 4, 5, 6 },

                        new int[]{ 6 },
                    }
                 ),

                new
                (
                    Vertices2.Regular(270f, 5),

                    new int[][]
                    {
                        new int[]{ 1, 2, 3, 4 },

                        new int[]{ 2, 3, 4 },

                        new int[]{ 3, 4 },

                        new int[]{ 4 },
                    }
                 ),

                new
                (
                    Vertices2.Regular(270f, 6),

                    new int[][]
                    {
                        new int[]{ 1, 2, 3, 4 },

                        new int[]{ 2, 3, 5 },

                        new int[]{ 4, 5 },

                        new int[]{ 4, 5 },

                        new int[]{ 5 },
                    }
                 ),

                new
                (
                    Vertices2.Regular(270f, 6),

                    new int[][]
                    {
                        new int[]{ 1, 2, 3, 4 },

                        new int[]{ 2, 3, 5 },

                        new int[]{ 4, 5 },

                        new int[]{ 4, 5 },

                        new int[]{ 5 },
                    }
                 ),
            };

            maxLevel = eulerianTrailInfos.Length;
        }

        private void Start()
        {
            eulerianTrail.Initialize(eulerianTrailInfos[level], LevelUp);
        }

        private void LevelUp()
        {
            if (++level < maxLevel)
            {
                eulerianTrail.Initialize(eulerianTrailInfos[level], LevelUp);
            }
        }

        public void StartLevel(int level)
        {
            eulerianTrail.Initialize(eulerianTrailInfos[level]);
        }
    }
}