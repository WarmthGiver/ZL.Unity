using UnityEditor;

namespace ZL.Tools
{
    public static class BuildReportAnalyzer
    {
        [MenuItem("Tools/Analyze Build Report")]

        public static void Analyze()
        {
            var buildReport = BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, "BuildOutput", BuildTarget.StandaloneWindows, BuildOptions.None);

            Fixed.Debug.Log($"Total Build Size: {buildReport.summary.totalSize} bytes");

            foreach (var step in buildReport.steps)
            {
                Fixed.Debug.Log($"Step: {step.name}");

                foreach (var message in step.messages)
                {
                    Fixed.Debug.Log(message.content);
                }
            }
        }
    }
}