using System;
using System.Collections.Generic;

namespace MoreSlugcats
{
	// Token: 0x020002FE RID: 766
	public class MapExporterOptions
	{
		// Token: 0x06002117 RID: 8471 RVA: 0x0029AB58 File Offset: 0x00298D58
		public static void OnInit()
		{
			OptionInterface optionInterface = new MMFOptionInterface();
			MachineConnector.SetRegisteredOI(MapExporterOptions.MOD_ID, optionInterface);
			MapExporterOptions.boolPresets = new List<MMFPreset<bool>>();
			MapExporterOptions.intPresets = new List<MMFPreset<int>>();
			MapExporterOptions.floatPresets = new List<MMFPreset<float>>();
			optionInterface.config.configurables.Clear();
			MapExporterOptions.cfgSurvivorPassageNotRequired = optionInterface.config.Bind<bool>("cfgSurvivorPassageNotRequired", true, new ConfigurableInfo("Allows certain passages to gain progress even before the Survivor passage has been achieved", null, "", new object[]
			{
				"Passage progress without Survivor"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgSurvivorPassageNotRequired, true, false, true));
			MapExporterOptions.cfgQuieterGates = optionInterface.config.Bind<bool>("cfgQuieterGates", false, new ConfigurableInfo("Reduces the volume for the sound effects of gates and shelters opening", null, "", new object[]
			{
				"Quieter gates/shelters"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgQuieterGates, false, false, false));
			MapExporterOptions.cfgNoRandomCycles = optionInterface.config.Bind<bool>("cfgNoRandomCycles", false, new ConfigurableInfo("All cycles will have the same duration, and will always use the longest duration possible", null, "", new object[]
			{
				"No randomized cycle durations"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgNoRandomCycles, false, false, true));
			MapExporterOptions.cfgCreatureSense = optionInterface.config.Bind<bool>("cfgCreatureSense", true, new ConfigurableInfo("Show icons of nearby creatures on the minimap", null, "", new object[]
			{
				"Slug Senses"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgCreatureSense, true, true, true));
			MapExporterOptions.cfgFastMapReveal = optionInterface.config.Bind<bool>("cfgFastMapReveal", true, new ConfigurableInfo("Increase the speed that the minimap reveals itself", null, "", new object[]
			{
				"Fast map reveal"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgFastMapReveal, true, false, true));
			MapExporterOptions.cfgNoArenaFleeing = optionInterface.config.Bind<bool>("cfgNoArenaFleeing", true, new ConfigurableInfo("Prevent injured creatures from fleeing to dens in arena mode", null, "", new object[]
			{
				"Arena creatures cannot flee"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgNoArenaFleeing, true, false, true));
			MapExporterOptions.cfgHunterBatflyAutograb = optionInterface.config.Bind<bool>("cfgHunterBatflyAutograb", true, new ConfigurableInfo("Stops Hunter from automatically grabbing batflies with a free hand", null, "", new object[]
			{
				"No Hunter batfly auto-grabbing"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgHunterBatflyAutograb, true, false, true));
			MapExporterOptions.cfgHunterBackspearProtect = optionInterface.config.Bind<bool>("cfgHunterBackspearProtect", true, new ConfigurableInfo("Stops Scavengers from being able to steal the spear off of Hunter's back", null, "", new object[]
			{
				"No stealing Hunter back-spear"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgHunterBackspearProtect, true, false, true));
			MapExporterOptions.cfgLoadingScreenTips = optionInterface.config.Bind<bool>("cfgLoadingScreenTips", true, new ConfigurableInfo("Periodically shows tips and tutorials during the loading screen between cycles", null, "", new object[]
			{
				"Loading screen tips"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgLoadingScreenTips, true, false, true));
			MapExporterOptions.cfgExtraTutorials = optionInterface.config.Bind<bool>("cfgExtraTutorials", true, new ConfigurableInfo("Introduces a few additional in-game tutorial messages for certain mechanics and scenarios", null, "", new object[]
			{
				"Extra tutorials"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgExtraTutorials, true, true, true));
			MapExporterOptions.cfgIncreaseStuns = optionInterface.config.Bind<bool>("cfgIncreaseStuns", false, new ConfigurableInfo("Increases the amount of time that rocks and snail pops can cause some creatures to be stunned for", null, "", new object[]
			{
				"Increased stun times"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgIncreaseStuns, false, false, true));
			MapExporterOptions.cfgShowUnderwaterShortcuts = optionInterface.config.Bind<bool>("cfgShowUnderwaterShortcuts", true, new ConfigurableInfo("Prevents underwater shortcut symbols from being obscured by the water layer", null, "", new object[]
			{
				"Show underwater shortcuts"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgShowUnderwaterShortcuts, true, true, true));
			MapExporterOptions.cfgGraspWiggling = optionInterface.config.Bind<bool>("cfgGraspWiggling", true, new ConfigurableInfo("Gives a chance of escaping from different grasps by rapidly wiggling with the movement buttons", null, "", new object[]
			{
				"Wiggle out of grasps"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgGraspWiggling, true, false, true));
			MapExporterOptions.cfgJetfishItemProtection = optionInterface.config.Bind<bool>("cfgJetfishItemProtection", true, new ConfigurableInfo("Prevents Jetfish from being able to knock items out of your hands", null, "", new object[]
			{
				"Jetfish item protection"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgJetfishItemProtection, true, true, true));
			MapExporterOptions.cfgKeyItemPassaging = optionInterface.config.Bind<bool>("cfgKeyItemPassaging", true, new ConfigurableInfo("Passages bring all key items in a shelter with you to the new destination, rather than just the stomach item", null, "", new object[]
			{
				"Key items on Passage"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgKeyItemPassaging, true, false, true));
			MapExporterOptions.cfgKeyItemTracking = optionInterface.config.Bind<bool>("cfgKeyItemTracking", true, new ConfigurableInfo("Key items are tracked on the map and will respawn on subsequent cycles if they are lost, at the location they were lost", null, "", new object[]
			{
				"Key item tracking"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgKeyItemTracking, true, true, true));
			MapExporterOptions.cfgSafeCentipedes = optionInterface.config.Bind<bool>("cfgSafeCentipedes", true, new ConfigurableInfo("Centipedes will release you if you go through a pipe while you are grabbed by one", null, "", new object[]
			{
				"Centipede pipe protection"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgSafeCentipedes, true, true, true));
			MapExporterOptions.cfgMonkBreathTime = optionInterface.config.Bind<bool>("cfgMonkBreathTime", true, new ConfigurableInfo("Increases the amount of underwater breath time that Monk has", null, "", new object[]
			{
				"Monk extended breath"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgMonkBreathTime, true, false, true));
			MapExporterOptions.cfgLargeHologramLight = optionInterface.config.Bind<bool>("cfgLargeHologramLight", false, new ConfigurableInfo("Increases the radius of Monk's hologram light in pitch-black areas", null, "", new object[]
			{
				"Monk extra light assistance"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgLargeHologramLight, false, false, true));
			MapExporterOptions.cfgNewDynamicDifficulty = optionInterface.config.Bind<bool>("cfgNewDynamicDifficulty", true, new ConfigurableInfo("Dynamic difficulty is influenced by number of regions visited more than number of cycles survived", null, "", new object[]
			{
				"New dynamic difficulty"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgNewDynamicDifficulty, true, true, true));
			MapExporterOptions.cfgScavengerKillSquadDelay = optionInterface.config.Bind<bool>("cfgScavengerKillSquadDelay", true, new ConfigurableInfo("Give a grace period on cycle start and region entry before scavenger kill squads can attack you", null, "", new object[]
			{
				"Scavenger kill squad leniency"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgScavengerKillSquadDelay, true, false, true));
			MapExporterOptions.cfgClimbingGrip = optionInterface.config.Bind<bool>("cfgClimbingGrip", true, new ConfigurableInfo("Prevents falling off from poles when throwing objects", null, "", new object[]
			{
				"Stronger climbing grip"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgClimbingGrip, true, false, true));
			MapExporterOptions.cfgSwimBreathLeniency = optionInterface.config.Bind<bool>("cfgSwimBreathLeniency", true, new ConfigurableInfo("Increases the amount of time before you are forced to come up for air while drowning", null, "", new object[]
			{
				"Breath time leniency"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgSwimBreathLeniency, true, true, true));
			MapExporterOptions.cfgFreeSwimBoosts = optionInterface.config.Bind<bool>("cfgFreeSwimBoosts", false, new ConfigurableInfo("Swim boosting will not consume additional breath time", null, "", new object[]
			{
				"No swim boost penalty"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgFreeSwimBoosts, false, false, true));
			MapExporterOptions.cfgHunterCycles = optionInterface.config.Bind<int>("cfgHunterCycles", 20, new ConfigurableInfo("Changes the amount of cycles Hunter starts with in their campaign", new ConfigAcceptableRange<int>(1, 9999), "", new object[]
			{
				"Hunter Cycles"
			}));
			MapExporterOptions.intPresets.Add(new MMFPreset<int>(MapExporterOptions.cfgHunterCycles, 20, 20, 20));
			MapExporterOptions.cfgHunterBonusCycles = optionInterface.config.Bind<int>("cfgHunterBonusCycles", 5, new ConfigurableInfo("Changes the amount of bonus cycles Hunter can receive during their campaign", new ConfigAcceptableRange<int>(0, 9999), "", new object[]
			{
				"Hunter Bonus Cycles"
			}));
			MapExporterOptions.intPresets.Add(new MMFPreset<int>(MapExporterOptions.cfgHunterBonusCycles, 5, 5, 5));
			MapExporterOptions.cfgRainTimeMultiplier = optionInterface.config.Bind<float>("cfgRainTimeMultiplier", 1f, new ConfigurableInfo("Multiplies the total duration of the rain timer by this amount", new ConfigAcceptableRange<float>(0.25f, 10f), "", new object[]
			{
				"Rain Timer Multiplier"
			}));
			MapExporterOptions.floatPresets.Add(new MMFPreset<float>(MapExporterOptions.cfgRainTimeMultiplier, 1f, 1f, 2f));
			MapExporterOptions.cfgSlowTimeFactor = optionInterface.config.Bind<float>("cfgSlowTimeFactor", 1f, new ConfigurableInfo("Reduces the overall speed of the game to assist with reaction times", new ConfigAcceptableRange<float>(1f, 5f), "", new object[]
			{
				"Slow Motion Factor"
			}));
			MapExporterOptions.floatPresets.Add(new MMFPreset<float>(MapExporterOptions.cfgSlowTimeFactor, 1f, 1f, 1f));
			MapExporterOptions.cfgThreatMusicPulse = optionInterface.config.Bind<bool>("cfgThreatMusicPulse", false, new ConfigurableInfo("Shows a visual pulse on screen when threats are nearby", null, "", new object[]
			{
				"Threat music visual pulse"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgThreatMusicPulse, false, false, false));
			MapExporterOptions.cfgClearerDeathGradients = optionInterface.config.Bind<bool>("cfgClearerDeathGradients", false, new ConfigurableInfo("Makes the death gradients on bottomless pits more visible", null, "", new object[]
			{
				"Stronger bottomless pit indicators"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgClearerDeathGradients, false, false, true));
			MapExporterOptions.cfgGlobalMonkGates = optionInterface.config.Bind<bool>("cfgGlobalMonkGates", false, new ConfigurableInfo("For all campaigns, gates will remain open permanently after passing through them once", null, "", new object[]
			{
				"Monk-style gates for all campaigns"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgGlobalMonkGates, false, false, true));
			MapExporterOptions.cfgDisableGateKarma = optionInterface.config.Bind<bool>("cfgDisableGateKarma", false, new ConfigurableInfo("Allow passing any gate for free, regardless of your current karma level", null, "", new object[]
			{
				"Disable all karma requirements"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgDisableGateKarma, false, false, false));
			MapExporterOptions.cfgBreathTimeVisualIndicator = optionInterface.config.Bind<bool>("cfgBreathTimeVisualIndicator", false, new ConfigurableInfo("Show a visual indicator on the UI of your remaining breath time", null, "", new object[]
			{
				"Visual breath meter"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgBreathTimeVisualIndicator, false, false, true));
			MapExporterOptions.cfgOldTongue = optionInterface.config.Bind<bool>("cfgOldTongue", false, new ConfigurableInfo("Use the throw button to activate tongue controls rather than the jump button", null, "", new object[]
			{
				"Legacy tongue controls"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgOldTongue, false, false, false));
			MapExporterOptions.cfgDislodgeSpears = optionInterface.config.Bind<bool>("cfgDislodgeSpears", false, new ConfigurableInfo("Gives the player the ability to dislodge spears that are embedded in walls", null, "", new object[]
			{
				"Pull spears from walls"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgDislodgeSpears, false, false, true));
			MapExporterOptions.cfgDisableScreenShake = optionInterface.config.Bind<bool>("cfgDisableScreenShake", false, new ConfigurableInfo("Removes visual effects that cause the screen to shake", null, "", new object[]
			{
				"Reduce screen shaking"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgDisableScreenShake, false, false, false));
			MapExporterOptions.cfgSpeedrunTimer = optionInterface.config.Bind<bool>("cfgSpeedrunTimer", false, new ConfigurableInfo("The current session playtime will always be visible as a UI element in-game", null, "", new object[]
			{
				"Speedrun timer"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgSpeedrunTimer, false, false, false));
			MapExporterOptions.cfgDeerBehavior = optionInterface.config.Bind<bool>("cfgDeerBehavior", true, new ConfigurableInfo("Adds additional deer behavior, like being able to influence their behavior by wiggling in their antlers", null, "", new object[]
			{
				"Tweaked deer behavior"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgDeerBehavior, true, true, true));
			MapExporterOptions.cfgUpwardsSpearThrow = optionInterface.config.Bind<bool>("cfgUpwardsSpearThrow", true, new ConfigurableInfo("Gives additional options for the directions and ways that objects can be thrown in certain circumstances", null, "", new object[]
			{
				"Upwards spear throwing"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgUpwardsSpearThrow, true, true, true));
			MapExporterOptions.cfgExtraLizardSounds = optionInterface.config.Bind<bool>("cfgExtraLizardSounds", true, new ConfigurableInfo("All lizard breeds have unique sound effects and voices", null, "", new object[]
			{
				"Additional lizard voices"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgExtraLizardSounds, true, true, true));
			MapExporterOptions.cfgWallpounce = optionInterface.config.Bind<bool>("cfgWallpounce", true, new ConfigurableInfo("Enable the wall pounce mechanic", null, "", new object[]
			{
				"Wall pouncing"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgWallpounce, true, false, false));
			MapExporterOptions.cfgTickTock = optionInterface.config.Bind<bool>("cfgTickTock", true, new ConfigurableInfo("The rain timer makes a tick-tock noise while the UI is visible", null, "", new object[]
			{
				"Rain timer tick-tock"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgTickTock, true, false, true));
			MapExporterOptions.cfgHideRainMeterNoThreat = optionInterface.config.Bind<bool>("cfgHideRainMeterNoThreat", true, new ConfigurableInfo("Hide the remaining cycle time while in maps that are safe from the rain", null, "", new object[]
			{
				"Hide rain timer in safe areas"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgHideRainMeterNoThreat, true, true, true));
			MapExporterOptions.cfgAlphaRedLizards = optionInterface.config.Bind<bool>("cfgAlphaRedLizards", true, new ConfigurableInfo("Red Lizards have a tongue and can snap spears in half with their bite", null, "", new object[]
			{
				"Alpha red lizards"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgAlphaRedLizards, true, false, false));
			MapExporterOptions.cfgSandboxItemStems = optionInterface.config.Bind<bool>("cfgSandboxItemStems", true, new ConfigurableInfo("Items that typically attach to the terrain with a stem will spawn with their stems when placed in Sandbox mode", null, "", new object[]
			{
				"Item stems in sandbox"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgSandboxItemStems, true, true, true));
			MapExporterOptions.cfgVulnerableJellyfish = optionInterface.config.Bind<bool>("cfgVulnerableJellyfish", true, new ConfigurableInfo("Jellyfish are vulnerable to being stabbed", null, "", new object[]
			{
				"Vulnerable jellyfish"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgVulnerableJellyfish, true, false, true));
			MapExporterOptions.cfgVanillaExploits = optionInterface.config.Bind<bool>("cfgVanillaExploits", false, new ConfigurableInfo("Advantageous glitches and speedrunner exploits are made available to use again with this option", null, "", new object[]
			{
				"Vanilla exploits"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgVanillaExploits, false, true, true));
			MapExporterOptions.cfgFasterShelterOpen = optionInterface.config.Bind<bool>("cfgFasterShelterOpen", false, new ConfigurableInfo("Reduces the amount of time taken to get started with a new cycle", null, "", new object[]
			{
				"Faster shelter opening"
			}));
			MapExporterOptions.boolPresets.Add(new MMFPreset<bool>(MapExporterOptions.cfgFasterShelterOpen, false, false, true));
		}

		// Token: 0x06002118 RID: 8472 RVA: 0x0029BA09 File Offset: 0x00299C09
		public static void OnDisable(ProcessManager manager)
		{
		}

		// Token: 0x04001F13 RID: 7955
		public static string MOD_ID = "rwremix";

		// Token: 0x04001F14 RID: 7956
		public static Configurable<bool> cfgSpeedrunTimer;

		// Token: 0x04001F15 RID: 7957
		public static Configurable<bool> cfgHideRainMeterNoThreat;

		// Token: 0x04001F16 RID: 7958
		public static Configurable<bool> cfgLoadingScreenTips;

		// Token: 0x04001F17 RID: 7959
		public static Configurable<bool> cfgExtraTutorials;

		// Token: 0x04001F18 RID: 7960
		public static Configurable<bool> cfgClearerDeathGradients;

		// Token: 0x04001F19 RID: 7961
		public static Configurable<bool> cfgShowUnderwaterShortcuts;

		// Token: 0x04001F1A RID: 7962
		public static Configurable<bool> cfgBreathTimeVisualIndicator;

		// Token: 0x04001F1B RID: 7963
		public static Configurable<bool> cfgCreatureSense;

		// Token: 0x04001F1C RID: 7964
		public static Configurable<bool> cfgTickTock;

		// Token: 0x04001F1D RID: 7965
		public static Configurable<bool> cfgFastMapReveal;

		// Token: 0x04001F1E RID: 7966
		public static Configurable<bool> cfgThreatMusicPulse;

		// Token: 0x04001F1F RID: 7967
		public static Configurable<bool> cfgExtraLizardSounds;

		// Token: 0x04001F20 RID: 7968
		public static Configurable<bool> cfgVulnerableJellyfish;

		// Token: 0x04001F21 RID: 7969
		public static Configurable<bool> cfgNewDynamicDifficulty;

		// Token: 0x04001F22 RID: 7970
		public static Configurable<bool> cfgSurvivorPassageNotRequired;

		// Token: 0x04001F23 RID: 7971
		public static Configurable<bool> cfgIncreaseStuns;

		// Token: 0x04001F24 RID: 7972
		public static Configurable<bool> cfgUpwardsSpearThrow;

		// Token: 0x04001F25 RID: 7973
		public static Configurable<bool> cfgDislodgeSpears;

		// Token: 0x04001F26 RID: 7974
		public static Configurable<bool> cfgAlphaRedLizards;

		// Token: 0x04001F27 RID: 7975
		public static Configurable<bool> cfgSandboxItemStems;

		// Token: 0x04001F28 RID: 7976
		public static Configurable<bool> cfgNoArenaFleeing;

		// Token: 0x04001F29 RID: 7977
		public static Configurable<bool> cfgVanillaExploits;

		// Token: 0x04001F2A RID: 7978
		public static Configurable<bool> cfgOldTongue;

		// Token: 0x04001F2B RID: 7979
		public static Configurable<bool> cfgWallpounce;

		// Token: 0x04001F2C RID: 7980
		public static Configurable<bool> cfgFasterShelterOpen;

		// Token: 0x04001F2D RID: 7981
		public static Configurable<bool> cfgQuieterGates;

		// Token: 0x04001F2E RID: 7982
		public static Configurable<bool> cfgSwimBreathLeniency;

		// Token: 0x04001F2F RID: 7983
		public static Configurable<bool> cfgJetfishItemProtection;

		// Token: 0x04001F30 RID: 7984
		public static Configurable<bool> cfgKeyItemTracking;

		// Token: 0x04001F31 RID: 7985
		public static Configurable<bool> cfgKeyItemPassaging;

		// Token: 0x04001F32 RID: 7986
		public static Configurable<bool> cfgScavengerKillSquadDelay;

		// Token: 0x04001F33 RID: 7987
		public static Configurable<bool> cfgDeerBehavior;

		// Token: 0x04001F34 RID: 7988
		public static Configurable<bool> cfgHunterBatflyAutograb;

		// Token: 0x04001F35 RID: 7989
		public static Configurable<bool> cfgHunterBackspearProtect;

		// Token: 0x04001F36 RID: 7990
		public static Configurable<bool> cfgDisableScreenShake;

		// Token: 0x04001F37 RID: 7991
		public static Configurable<bool> cfgClimbingGrip;

		// Token: 0x04001F38 RID: 7992
		public static Configurable<bool> cfgMonkBreathTime;

		// Token: 0x04001F39 RID: 7993
		public static Configurable<bool> cfgLargeHologramLight;

		// Token: 0x04001F3A RID: 7994
		public static Configurable<bool> cfgGraspWiggling;

		// Token: 0x04001F3B RID: 7995
		public static Configurable<bool> cfgFreeSwimBoosts;

		// Token: 0x04001F3C RID: 7996
		public static Configurable<bool> cfgNoRandomCycles;

		// Token: 0x04001F3D RID: 7997
		public static Configurable<bool> cfgSafeCentipedes;

		// Token: 0x04001F3E RID: 7998
		public static Configurable<int> cfgHunterCycles;

		// Token: 0x04001F3F RID: 7999
		public static Configurable<int> cfgHunterBonusCycles;

		// Token: 0x04001F40 RID: 8000
		public static Configurable<float> cfgSlowTimeFactor;

		// Token: 0x04001F41 RID: 8001
		public static Configurable<bool> cfgGlobalMonkGates;

		// Token: 0x04001F42 RID: 8002
		public static Configurable<bool> cfgDisableGateKarma;

		// Token: 0x04001F43 RID: 8003
		public static Configurable<float> cfgRainTimeMultiplier;

		// Token: 0x04001F44 RID: 8004
		public static List<MMFPreset<bool>> boolPresets;

		// Token: 0x04001F45 RID: 8005
		public static List<MMFPreset<int>> intPresets;

		// Token: 0x04001F46 RID: 8006
		public static List<MMFPreset<float>> floatPresets;
	}
}
