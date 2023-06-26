using BepInEx.Logging;
using Menu.Remix.MixedUI;
using Menu.Remix.MixedUI.ValueTypes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MapExporter;
/*
public class MapExporterOptions : OptionInterface
{
    private readonly ManualLogSource Logger;

    public MapExporterOptions(MapExporterMain modInstance, ManualLogSource loggerSource)
    {
        Logger = loggerSource;
        Screenshots = this.config.Bind<bool>("PlayerSpeed", true, new ConfigAcceptableRange<bool>(true, false));
    }

    public readonly Configurable<bool> Screenshots;
    public readonly Configurable<bool> CaptureSpecific;
    public readonly Configurable<bool> Blacklist;
    private UIelement[] UIArrPlayerOptions;
    
    public override void Initialize()
    {
        var opTab = new OpTab(this, "Options");
        this.Tabs = new[]
        {
            opTab
        };

        UIArrPlayerOptions = new UIelement[]
        {
            new OpLabel(10f, 550f, "Options", true),
            new OpLabel(10f, 520f, "Screenshots"),
            new OpLabelLong(new Vector2(1f, 1f), new Vector2(1f, 1f), "Capture rooms via screenshots"),
            new OpCheckBox(Screenshots, new Vector2(1f, 1f)),

            new OpLabel(10f, 520f, "Capture Specific"),
            new OpLabelLong(new Vector2(1f, 1f), new Vector2(1f, 1f), "Overrides the normal slugcat and region map export. For example, \"White;SU\" loads Outskirts as Survivor. Additional slugcat regions can be added after a comma and space; e.g. \"Slugcat;RA\", \"Slugcat;RA\", \"Slugcat;RA\"..."),
            new OpTextBox(CaptureSpecific, new Vector2(1f, 1f), 100f),

            new OpLabel(10f, 520f, "Blacklisted Cameras"),
            new OpLabelLong(new Vector2(1f, 1f), new Vector2(1f, 1f), "Skips problematic camermas. By default, these cameras are blacklisted: SU_B13, camera 2 - one indexed GW_S08; camera 2 - in vanilla only, SL_C01; cameras 4 & 5 - crescent order or will break. Format is as follows: {RA_XXX, {cam}}, {RA_XXX, {cam, cam, cam}}, {RA_XXX, {cam, cam}}"),
            new OpTextBox(Blacklist, new Vector2(1f, 1f) ,100f),
        };
        opTab.AddItems(UIArrPlayerOptions);
    }

    public override void Update()
    { 
    }

}
*/