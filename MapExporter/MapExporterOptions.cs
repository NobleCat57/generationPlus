using BepInEx.Logging;
using Menu.Remix.MixedUI;
using MoreSlugcats;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Globalization;
using Menu.Remix;
using RWCustom;

namespace MapExporter;
public class MapExporterOptions
{
    public static void OnInit()
    {

    }

    public static void OnDisable(ProcessManager manager)
    {
    }

    public static string MOD_ID = "mapexporter";
    public static Configurable<bool> cfgScreenshots;
    public static Configurable<bool> cfgCaptureSpecific;
    public static Configurable<bool> cfgCameraBlacklist;


    public class MapExporterOptionInterface : OptionInterface
    {
        public override void Initialize()
        {
            OptionInterface optionInterface = new MapExporterOptionInterface();
            MachineConnector.SetRegisteredOI(MOD_ID, optionInterface);
            optionInterface.config.configurables.Clear();
            cfgScreenshots = optionInterface.config.Bind<bool>("cfgScreenshots", true, new ConfigurableInfo("Capture rooms via screenshots", null, "", new object[]
            {
                "Screenshots"
            }));
            cfgCaptureSpecific = optionInterface.config.Bind<bool>("cfgCaptureSpecific", false, new ConfigurableInfo("Overrides the normal slugcat and region map export. For example, \"White;SU\" loads Outskirts as Survivor. Additional slugcat regions can be added after a comma and space; e.g. \"Slugcat;RA\", \"Slugcat;RA\", \"Slugcat;RA\"...", null, "", new object[]
            {
                "Capture Specific"
            }));
            cfgCameraBlacklist = optionInterface.config.Bind<bool>("cfgCameraBlacklist", false, new ConfigurableInfo("Skips problematic camermas. By default, these cameras are blacklisted: SU_B13, camera 2 - one indexed GW_S08; camera 2 - in vanilla only, SL_C01; cameras 4 & 5 - crescent order or will break. Format is as follows: {RA_XXX, {cam}}, {RA_XXX, {cam, cam, cam}}, {RA_XXX, {cam, cam}}", null, "", new object[]
            {
                "Blacklisted Cameras"
            }));

            base.Initialize();
            Tabs = new OpTab[]
            {
                new OpTab(this, Translate("Options")),
            };
            OpLabel opLabel = new OpLabel(new Vector2(150f, 520f), new Vector2(300f, 30f), mod.LocalizedName, FLabelAlignment.Center, true, null);
            Tabs[0].AddItems(new UIelement[]
            {
                opLabel
            });

            var Screenshotsbtn = new OpCheckBox(cfgScreenshots, 120f, 30f)
            {
                description = Translate("Capture rooms via screenshots")
            };
            var CaptureSpecificbtn = new OpCheckBox(cfgCaptureSpecific, 120f, 30f)
            {
                description = Translate("Overrides the normal slugcat and region map export. For example, \"White;SU\" loads Outskirts as Survivor. Additional slugcat regions can be added after a comma and space; e.g. \"Slugcat;RA\", \"Slugcat;RA\", \"Slugcat;RA\"...")
            };
            var CameraBlacklistbtn = new OpCheckBox(cfgCameraBlacklist, 120f, 30f)
            {
                description = Translate("Skips problematic cameras. By default, these cameras are blacklisted: SU_B13, camera 2 - one indexed GW_S08; camera 2 - in vanilla only, SL_C01; cameras 4 & 5 - crescent order or will break. Format is as follows: {RA_XXX, {cam}}, {RA_XXX, {cam, cam, cam}}, {RA_XXX, {cam, cam}}")
            };
            Tabs[0].AddItems(new UIelement[]
            {
                Screenshotsbtn
            });
            Tabs[0].AddItems(new UIelement[]
            {
                CaptureSpecificbtn
            });
            Tabs[0].AddItems(new UIelement[]
            {
                CameraBlacklistbtn
            });

            ConfigurableBase[][] array = new ConfigurableBase[1][];
            string[] names = new string[]
            {
            };
            array[0] = new ConfigurableBase[]
            {
                cfgScreenshots,
                cfgCaptureSpecific,
                cfgCameraBlacklist,
            };
            {
            };
        }
    }
}
