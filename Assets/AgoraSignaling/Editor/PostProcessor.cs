using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace UnitySwift
{
    public static class PostProcessor
    {
        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget buildTarget, string buildPath)
        {
            if (buildTarget == BuildTarget.iOS)
            {
                // So PBXProject.GetPBXProjectPath returns wrong path, we need to construct path by ourselves instead
                // var projPath = PBXProject.GetPBXProjectPath(buildPath);
                var projPath = buildPath + "/Unity-iPhone.xcodeproj/project.pbxproj";
                var proj = new PBXProject();
                proj.ReadFromFile(projPath);

                var targetGuid = proj.TargetGuidByName(PBXProject.GetUnityTargetName());

                //List of frameworks that will be added to project
                List<string> frameworks = new List<string>()
                {
                    "libresolv.tbd",
                    "libc++.tbd",
                    "CoreTelephony.framework",
                    "CoreMedia.framework",
                    "CoreMotion.framework",
                    "VideoToolbox.framework",
                    "AudioToolbox.framework",
                    "AVFoundation.framework",
                };
                // Add each by name
                frameworks.ForEach
                (
                    (framework) => { proj.AddFrameworkToProject(targetGuid, framework, false); }
                );
                //// Configure build settings
                proj.SetBuildProperty(targetGuid, "ENABLE_BITCODE", "NO");
                proj.SetBuildProperty(targetGuid, "SWIFT_OBJC_BRIDGING_HEADER",
                    "Libraries/AgoraSignaling/Plugins/iOS/UnitySwift-Bridging-Header.h");
                proj.SetBuildProperty(targetGuid, "SWIFT_OBJC_INTERFACE_HEADER_NAME", "AgoraSignaling-Swift.h");
                proj.SetBuildProperty(targetGuid, "SWIFT_VERSION", "Swift 3.2");
                proj.AddBuildProperty(targetGuid, "LD_RUNPATH_SEARCH_PATHS", "@executable_path/Frameworks");

                proj.WriteToFile(projPath);
            }
        }
    }
}