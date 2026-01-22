namespace ZL.Unity
{
    public enum ScriptExecutionOrder
    {
        Min = -100,

        Loading,

        Singleton,

        Tweener,

        Default = 0,

        NavMeshAgent,

        //Lazy,

        SceneDirector
    }
}