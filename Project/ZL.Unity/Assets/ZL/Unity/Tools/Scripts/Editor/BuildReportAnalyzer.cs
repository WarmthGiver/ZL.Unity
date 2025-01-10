using UnityEditor;

namespace ZL.Unity.Tools
{
    public static class BuildReportAnalyzer
    {
        [MenuItem("Tools/Analyze Build Report")]

        public static void Analyze()
        {
            var buildReport = BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, "BuildOutput", BuildTarget.StandaloneWindows, BuildOptions.None);

            FixedDebug.Log($"Total Build Size: {buildReport.summary.totalSize} bytes");

            foreach (var step in buildReport.steps)
            {
                FixedDebug.Log($"Step: {step.name}");

                foreach (var message in step.messages)
                {
                    FixedDebug.Log(message.content);
                }
            }
        }
    }
}