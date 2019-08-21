// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.Collections.Generic;

public abstract class MayaLiveLinkPluginTargetLinuxBase : TargetRules
{
    public MayaLiveLinkPluginTargetLinuxBase(TargetInfo Target) : base(Target)
    {
        Type = TargetType.Program;

        bShouldCompileAsDLL = true;
        LinkType = TargetLinkType.Monolithic;

        // We only need minimal use of the engine for this plugin
        bBuildDeveloperTools = false;
        bUseMallocProfiler = false;
        bBuildWithEditorOnlyData = true;
        bCompileAgainstEngine = false;
        bCompileAgainstCoreUObject = true;
        bCompileICU = false;
        bHasExports = true;

        bBuildInSolutionByDefault = false;

        // Add a post-build step that copies the output to a file with the .mll extension
        string OutputName = "MayaLiveLinkPlugin";
        if(Target.Configuration != UnrealTargetConfiguration.Development)
        {
            OutputName = string.Format("{0}-{1}-{2}", OutputName, Target.Platform, Target.Configuration);
        }//MayaLiveLinkPlugin2018Linux.so
        PostBuildSteps.Add(string.Format("cp \"$(EngineDir)/Binaries/Linux/libMayaLiveLinkPlugin2018Linux.so\" \"$(EngineDir)/Binaries/Linux/{0}.so\" >nul: & echo Copied output to $(EngineDir)/Binaries/Linux/{0}.so", OutputName));
    }
}

public class MayaLiveLinkPlugin2018LinuxTarget : MayaLiveLinkPluginTargetLinuxBase
{
    public MayaLiveLinkPlugin2018LinuxTarget(TargetInfo Target) : base(Target)
    {
        LaunchModuleName = "MayaLiveLinkPlugin2018Linux";
    }
}