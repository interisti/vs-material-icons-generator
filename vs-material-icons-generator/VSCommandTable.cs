namespace VSMaterialIcons
{
    using System;
    
    /// <summary>
    /// Helper class that exposes all GUIDs used across VS Package.
    /// </summary>
    internal sealed partial class PackageGuids
    {
        public const string guidAddIconCommandPackageString = "bffb634b-07ee-4c44-9e81-7565ef240ecf";
        public const string guidAddIconCommandPackageCmdSetString = "4bc78819-cb1b-4120-8dd9-69aea2953600";
        public const string guidImagesString = "224ef736-02db-415f-8634-de37323078ed";
        public static Guid guidAddIconCommandPackage = new Guid(guidAddIconCommandPackageString);
        public static Guid guidAddIconCommandPackageCmdSet = new Guid(guidAddIconCommandPackageCmdSetString);
        public static Guid guidImages = new Guid(guidImagesString);
    }
    /// <summary>
    /// Helper class that encapsulates all CommandIDs uses across VS Package.
    /// </summary>
    internal sealed partial class PackageIds
    {
        public const int MyMenuGroup = 0x0450;
        public const int AddIconCommandId = 0x0100;
        public const int bmpPic1 = 0x0001;
    }
}
