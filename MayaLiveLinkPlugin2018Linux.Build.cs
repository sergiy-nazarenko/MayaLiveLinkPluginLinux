// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public abstract class MayaLiveLinkPluginBaseLinux : ModuleRules
{
	public MayaLiveLinkPluginBaseLinux(ReadOnlyTargetRules Target) : base(Target)
	{
		// For LaunchEngineLoop.cpp include.  You shouldn't need to add anything else to this line.
		PrivateIncludePaths.AddRange( new string[] { "Runtime/Launch/Public", "Runtime/Launch/Private", "/home/snazarenko/Downloads/usr/include", "/usr/include" }  );

		// Unreal dependency modules
		PrivateDependencyModuleNames.AddRange( new string[] 
		{
			"Core",
            "CoreUObject",
			"ApplicationCore",
			"Projects",
            "UdpMessaging",
            "LiveLinkInterface",
            "LiveLinkMessageBusFramework",
		} );


		//
		// Maya SDK setup
		//

		{
			string MayaVersionString = GetMayaVersion();
			string MayaInstallFolder = @"/opt/rez_packages/maya/2018.5-1/platform-linux/arch-x86_64/os-CentOS_Linux-7";

			// Make sure this version of Maya is actually installed
			if( Directory.Exists( MayaInstallFolder ) )
			{
                //throw new BuildException( "Couldn't find Autodesk Maya " + MayaVersionString + " in folder '" + MayaInstallFolder + "'.  This version of Maya must be installed for us to find the Maya SDK files." );

                // These are required for Maya headers to compile properly as a DLL
                PublicDefinitions.Add("LINUX");
                PublicDefinitions.Add("REQUIRE_IOSTREAM");
                PublicDefinitions.Add("_GNU_SOURCE");
                PublicDefinitions.Add("LINUX_64");
                PublicDefinitions.Add("_BOOL");

                // -DBits64_ -m64 -DUNIX -D_BOOL -DLINUX -DFUNCPROTO -D_GNU_SOURCE -DLINUX_64 -fPIC -fno-strict-aliasing -DREQUIRE_IOSTREAM -O3 -Wall -Wno-multichar -Wno-comment -Wno-sign-compare -funsigned-char -pthread     -std=c++11 -Wno-deprecated -Wno-reorder -fno-gnu-keywords

                PrivateIncludePaths.Add(Path.Combine(MayaInstallFolder, "include"));

                // if (Target.Platform == UnrealTargetPlatform.Win64)  // @todo: Support other platforms?
                // {
                    PublicLibraryPaths.Add(Path.Combine(MayaInstallFolder, "lib"));

                    // Maya libraries we're depending on
                    PublicAdditionalLibraries.AddRange(new string[]
                        {
                            "Foundation",
                            "OpenMaya",
                            "OpenMayaAnim",
                            "OpenMayaUI"}
                    );
                // }
            }
		}
	}
	
	public abstract string GetMayaVersion();
}

public class MayaLiveLinkPlugin2018Linux : MayaLiveLinkPluginBaseLinux
{
	public MayaLiveLinkPlugin2018Linux(ReadOnlyTargetRules Target) : base(Target)
	{
	}
	
	public override string GetMayaVersion() { return "2018"; }
}
