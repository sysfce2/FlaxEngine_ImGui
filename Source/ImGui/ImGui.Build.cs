using System;
using Flax.Build;
using Flax.Build.NativeCpp;

public class ImGui : ThirdPartyModule
{
    public ImGui()
    {
        BuildCSharp = true;
        BuildNativeCode = true;
        LicenseType = LicenseTypes.MIT;
        LicenseFilePath = "LICENSE.txt";
    }

    /// <inheritdoc />
    public override void Setup(BuildOptions options)
    {
        base.Setup(options);

        options.PrivateIncludePaths.Add(FolderPath);
        options.PublicDependencies.Add("Core");
        options.PublicDependencies.Add("Engine");

        switch (options.Platform.Target)
        {
        case TargetPlatform.XboxOne:
        case TargetPlatform.XboxScarlett:
            options.PublicDefinitions.Add("IMGUI_DISABLE_WIN32_DEFAULT_CLIPBOARD_FUNCTIONS");
            options.PublicDefinitions.Add("IMGUI_DISABLE_WIN32_DEFAULT_IME_FUNCTIONS");
            break;
        }
    }
}
