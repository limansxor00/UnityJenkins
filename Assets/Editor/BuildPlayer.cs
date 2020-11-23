using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditor.Build.Reporting;

public class BuildPlayer 
{

    [MenuItem("Build/Build AOS(Debug)")]
    public static void Build_AOS_Debug()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = FindEnabledEditorScenes();
        buildPlayerOptions.locationPathName = string.Format("Build(AOS)/Test_{0}.apk", PlayerSettings.bundleVersion);
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.Development;
        BuildReport report= BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if( summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " byte");
        }

        if( summary.result == BuildResult.Failed)
        {
            Debug.Log("build failed");
        }
    }

    [MenuItem("Build/Build IOS")]
    public static void Build_IOS()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = FindEnabledEditorScenes();
        buildPlayerOptions.locationPathName = "Build(IOS)";
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " byte");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("build failed");
        }
    }

    private static string[] FindEnabledEditorScenes()
    {
        List<string> EditerScenes = new List<string>();

        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (!scene.enabled) continue;
            EditerScenes.Add(scene.path);
        }

        return EditerScenes.ToArray();
    }


}
