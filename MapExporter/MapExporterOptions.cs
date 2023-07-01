using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MapExporter;
using Menu;
using Menu.Remix;
using Menu.Remix.MixedUI;
using Menu.Remix.MixedUI.ValueTypes;
using UnityEngine;
using BepInEx.Logging;
using MoreSlugcats;
using System.Globalization;
using RWCustom;
using On;
using IL;

namespace MapExporter;

public class MapExporterOptions : OptionInterface
{
    public MapExporterOptions()
    {
        cfgScreenshots = this.config.Bind<bool>("Screenshots", true);
        cfgCaptureSpecific = this.config.Bind<bool>("Capture Specific", false);
        cfgCameraBlacklist = this.config.Bind<bool>("Blacklisted Cameras", true);
        //base.OnConfigChanged += this.ConfigOnChange;
        //base.OnDeactivate += this.DeactivateCheck;
    }
    public static void OnInit()
    {
    }

    public static void OnDisable(ProcessManager manager)
    {
    }

    Configurable<bool> cfgScreenshots;
    Configurable<bool> cfgCaptureSpecific;
    Configurable<bool> cfgCameraBlacklist;
    private OpLabel lblScreenshots;
    private OpLabel lblCaptureSpecific;
    private OpLabel lblCameraBlacklist;

    private bool pendingCheck = false;
    public override void Update()
    {
        base.Update();
        pendingCheck = false;
    }

    public override void Initialize()
    {

        base.Initialize();
        var opTab = new OpTab(this, "TABNAME"); //Create a tab.
        Tabs = new OpTab[] {
        opTab //Add the tab into your list of tabs.
        };
                UIelement[] UIarrayOptions = new UIelement[] //create an array of ui elements
        {
            new OpLabel(10f, 550f, "Options", true), //Creates a label at 10,550 with big text saying "Options"
        };
        opTab.AddItems(UIarrayOptions); //adds the elements to the tab
        Tabs = new OpTab[]
        {
                    new OpTab(this, Translate("Options")),
        };
        Vector2 anchor = new Vector2(1f, 0.5f);
        lblScreenshots = new OpLabel(new Vector2(260f, 575f), new Vector2(300f, 20f), "Capture Screenshots", FLabelAlignment.Right, false, null);
        lblCaptureSpecific = new OpLabel(new Vector2(260f, 575f), new Vector2(300f, 20f), "Capture Specific", FLabelAlignment.Right, false, null);
        lblCameraBlacklist = new OpLabel(new Vector2(260f, 575f), new Vector2(300f, 20f), "Blacklisted Cameras", FLabelAlignment.Right, false, null);

        Tabs[0].AddItems(new UIelement[]
        {
                    new OpRect(new Vector2(30f, 0f), new Vector2(540f, 470f), 0.3f),
                    lblScreenshots,
                    new OpRect(new Vector2(320f, 495f), new Vector2(240f, 80f), 0.2f),
                    new OpCheckBox(cfgScreenshots, 120f, 30f),
                    lblScreenshots,
                    new OpCheckBox(cfgCaptureSpecific, 120f, 30f),
                    lblCaptureSpecific,
                    new OpCheckBox(cfgCameraBlacklist, 120f, 30f),
                    lblCameraBlacklist,
        });
    }
}