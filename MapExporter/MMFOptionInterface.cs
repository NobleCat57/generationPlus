using System;
using System.Globalization;
using Menu.Remix;
using Menu.Remix.MixedUI;
using RWCustom;
using UnityEngine;

namespace MoreSlugcats
{
	// Token: 0x02000301 RID: 769
	public class MMFOptionInterface : OptionInterface
	{
		// Token: 0x06002120 RID: 8480 RVA: 0x0029BAA4 File Offset: 0x00299CA4
		public override void Initialize()
		{
			base.Initialize();
			this.Tabs = new OpTab[]
			{
				new OpTab(this, OptionInterface.Translate("Presets")),
				new OpTab(this, OptionInterface.Translate("General")),
				new OpTab(this, OptionInterface.Translate("Assists"))
			};
			OpLabel opLabel = new OpLabel(new Vector2(150f, 520f), new Vector2(300f, 30f), base.mod.LocalizedName, FLabelAlignment.Center, true, null);
			this.Tabs[0].AddItems(new UIelement[]
			{
				opLabel
			});
			OpLabel opLabel2 = new OpLabel(new Vector2(150f, 420f), new Vector2(300f, 30f), Custom.ReplaceLineDelimeters(OptionInterface.Translate("The presets below can be used to quickly reset settings.") + Environment.NewLine + OptionInterface.Translate("These are recommended starting points based on different playstyles.")), FLabelAlignment.Center, false, null);
			this.Tabs[0].AddItems(new UIelement[]
			{
				opLabel2
			});
			this.remixPresetBtn = new OpSimpleButton(new Vector2(250f, 360f), new Vector2(120f, 30f), OptionInterface.Translate("REMIX"))
			{
				description = OptionInterface.Translate("Standard Remix settings. Many mechanical tweaks that may mix up the way the game is experienced.")
			};
			this.classicPresetBtn = new OpSimpleButton(new Vector2(250f, 320f), new Vector2(120f, 30f), OptionInterface.Translate("CLASSIC"))
			{
				description = OptionInterface.Translate("Similar to the original Rain World experience, but with a few quality of life settings enabled.")
			};
			this.relaxedPresetBtn = new OpSimpleButton(new Vector2(250f, 280f), new Vector2(120f, 30f), OptionInterface.Translate("RELAXED"))
			{
				description = OptionInterface.Translate("Settings designed to make the game significantly easier, but may weaken the overall game experience.")
			};
			this.remixPresetBtn.OnClick += this.PresetRemix;
			this.classicPresetBtn.OnClick += this.PresetClassic;
			this.relaxedPresetBtn.OnClick += this.ConfirmPresetRelaxed;
			this.Tabs[0].AddItems(new UIelement[]
			{
				this.remixPresetBtn
			});
			this.Tabs[0].AddItems(new UIelement[]
			{
				this.classicPresetBtn
			});
			this.Tabs[0].AddItems(new UIelement[]
			{
				this.relaxedPresetBtn
			});
			ConfigurableBase[][] array = new ConfigurableBase[3][];
			string[] names = new string[]
			{
				OptionInterface.Translate("HUD"),
				OptionInterface.Translate("Remix"),
				OptionInterface.Translate("Legacy")
			};
			array[0] = new ConfigurableBase[]
			{
				MapExporterOptions.cfgSpeedrunTimer,
				MapExporterOptions.cfgHideRainMeterNoThreat,
				MapExporterOptions.cfgLoadingScreenTips,
				MapExporterOptions.cfgExtraTutorials,
				MapExporterOptions.cfgClearerDeathGradients,
				MapExporterOptions.cfgShowUnderwaterShortcuts,
				MapExporterOptions.cfgBreathTimeVisualIndicator,
				MapExporterOptions.cfgCreatureSense,
				MapExporterOptions.cfgTickTock,
				MapExporterOptions.cfgFastMapReveal,
				MapExporterOptions.cfgThreatMusicPulse
			};
			array[1] = new ConfigurableBase[]
			{
				MapExporterOptions.cfgExtraLizardSounds,
				MapExporterOptions.cfgVulnerableJellyfish,
				MapExporterOptions.cfgNewDynamicDifficulty,
				MapExporterOptions.cfgSurvivorPassageNotRequired,
				MapExporterOptions.cfgIncreaseStuns,
				MapExporterOptions.cfgUpwardsSpearThrow,
				MapExporterOptions.cfgDislodgeSpears,
				MapExporterOptions.cfgAlphaRedLizards,
				MapExporterOptions.cfgSandboxItemStems,
				MapExporterOptions.cfgNoArenaFleeing
			};
			array[2] = new ConfigurableBase[]
			{
				MapExporterOptions.cfgVanillaExploits,
				MapExporterOptions.cfgOldTongue,
				MapExporterOptions.cfgWallpounce
			};
			this.PopulateWithConfigs(1, array, names);
			array = new ConfigurableBase[3][];
			names = new string[]
			{
				OptionInterface.Translate("Quality of Life"),
				OptionInterface.Translate("Minor Assist"),
				OptionInterface.Translate("Major Assist")
			};
			array[0] = new ConfigurableBase[]
			{
				MapExporterOptions.cfgFasterShelterOpen,
				MapExporterOptions.cfgQuieterGates,
				MapExporterOptions.cfgDisableScreenShake,
				MapExporterOptions.cfgClimbingGrip,
				MapExporterOptions.cfgSwimBreathLeniency,
				MapExporterOptions.cfgJetfishItemProtection,
				MapExporterOptions.cfgKeyItemTracking,
				MapExporterOptions.cfgKeyItemPassaging,
				MapExporterOptions.cfgScavengerKillSquadDelay,
				MapExporterOptions.cfgDeerBehavior,
				MapExporterOptions.cfgHunterBatflyAutograb,
				MapExporterOptions.cfgHunterBackspearProtect
			};
			array[1] = new ConfigurableBase[]
			{
				MapExporterOptions.cfgMonkBreathTime,
				MapExporterOptions.cfgLargeHologramLight,
				MapExporterOptions.cfgGraspWiggling,
				MapExporterOptions.cfgNoRandomCycles,
				MapExporterOptions.cfgSafeCentipedes
			};
			array[2] = new ConfigurableBase[]
			{
				MapExporterOptions.cfgFreeSwimBoosts,
				MapExporterOptions.cfgHunterCycles,
				MapExporterOptions.cfgHunterBonusCycles,
				MapExporterOptions.cfgSlowTimeFactor,
				new Configurable<string>("CHEAT_MARK", null),
				MapExporterOptions.cfgGlobalMonkGates,
				MapExporterOptions.cfgDisableGateKarma,
				MapExporterOptions.cfgRainTimeMultiplier
			};
			this.PopulateWithConfigs(2, array, names);
			this.currentPresetLabel = new OpLabel(new Vector2(150f, 220f), new Vector2(300f, 30f), this.GetCurrentPresetString(), FLabelAlignment.Center, false, null);
			this.Tabs[0].AddItems(new UIelement[]
			{
				this.currentPresetLabel
			});
		}

		// Token: 0x06002121 RID: 8481 RVA: 0x0029BFA0 File Offset: 0x0029A1A0
		public override string ValidationString()
		{
			string text = "[" + base.mod.id + "]  ";
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < MapExporterOptions.boolPresets.Count; i++)
			{
				num += (int)Mathf.Pow(2f, (float)(i % 4)) * (MapExporterOptions.boolPresets[i].config.Value ? 1 : 0);
				if (i % 4 == 3 || i == MapExporterOptions.boolPresets.Count - 1)
				{
					text += num.ToString("X");
					num2++;
					if (num2 % 4 == 0)
					{
						text += "  ";
					}
					num = 0;
				}
			}
			for (int j = 0; j < MapExporterOptions.intPresets.Count; j++)
			{
				text = text + " " + MapExporterOptions.intPresets[j].config.Value.ToString();
			}
			for (int k = 0; k < MapExporterOptions.floatPresets.Count; k++)
			{
				text = text + " " + MapExporterOptions.floatPresets[k].config.Value.ToString("0.00");
			}
			text = text + " " + Custom.rainWorld.options.fpsCap.ToString();
			text = text + " " + (Custom.rainWorld.options.vsync ? "1" : "0");
			text = text + " " + Custom.rainWorld.options.analogSensitivity.ToString("0.00");
			string str = text;
			string str2 = " ";
			Options.Quality quality = Custom.rainWorld.options.quality;
			return str + str2 + ((quality != null) ? quality.ToString() : null);
		}

		// Token: 0x06002122 RID: 8482 RVA: 0x0029C171 File Offset: 0x0029A371
		private void WarningOff(UIfocusable trigger)
		{
		}

		// Token: 0x06002123 RID: 8483 RVA: 0x0029C174 File Offset: 0x0029A374
		private string GetCurrentPresetString()
		{
			string text = OptionInterface.Translate("Currently Active Preset") + ": ";
			if (this.CheckPresetRemix())
			{
				text += this.remixPresetBtn.text;
			}
			else if (this.CheckPresetClassic())
			{
				text += this.classicPresetBtn.text;
			}
			else if (this.CheckPresetRelaxed())
			{
				text += this.relaxedPresetBtn.text;
			}
			else
			{
				text += OptionInterface.Translate("NONE (User Defined)");
			}
			return text;
		}

		// Token: 0x06002124 RID: 8484 RVA: 0x0029C1FC File Offset: 0x0029A3FC
		private void PopulateWithConfigs(int tabIndex, ConfigurableBase[][] lists, string[] names)
		{
			new OpLabel(new Vector2(100f, 560f), new Vector2(400f, 30f), this.Tabs[tabIndex].name, FLabelAlignment.Center, true, null);
			OpTab opTab = this.Tabs[tabIndex];
			float num = 40f;
			float num2 = 20f;
			float num3 = 550f;
			UIconfig uiconfig = null;
			for (int i = 0; i < lists.Length; i++)
			{
				bool flag = false;
				opTab.AddItems(new UIelement[]
				{
					new OpLabel(new Vector2(num2, num3 - num + 10f), new Vector2(260f, 30f), "~ " + names[i] + " ~", FLabelAlignment.Center, true, null)
				});
				FTextParams ftextParams = new FTextParams();
				if (InGameTranslator.LanguageID.UsesLargeFont(Custom.rainWorld.inGameTranslator.currentLanguage))
				{
					ftextParams.lineHeightOffset = -12f;
				}
				else
				{
					ftextParams.lineHeightOffset = -5f;
				}
				for (int j = 0; j < lists[i].Length; j++)
				{
					switch (ValueConverter.GetTypeCategory(lists[i][j].settingType))
					{
					case ValueConverter.TypeCategory.String:
						if (lists[i][j].defaultValue == "CHEAT_MARK")
						{
							flag = true;
						}
						break;
					case ValueConverter.TypeCategory.Boolean:
					{
						num += 30f;
						Configurable<bool> configurable = lists[i][j] as Configurable<bool>;
						OpCheckBox opCheckBox = new OpCheckBox(configurable, new Vector2(num2, num3 - num))
						{
							description = OptionInterface.Translate(configurable.info.description),
							sign = i
						};
						opCheckBox.OnChange += this.RefreshCurrentPresetLabel;
						UIfocusable.MutualVerticalFocusableBind(opCheckBox, uiconfig ?? opCheckBox);
						OpLabel opLabel = new OpLabel(new Vector2(num2 + 40f, num3 - num), new Vector2(240f, 30f), Custom.ReplaceLineDelimeters(OptionInterface.Translate(configurable.info.Tags[0] as string)), FLabelAlignment.Left, false, ftextParams)
						{
							bumpBehav = opCheckBox.bumpBehav,
							description = opCheckBox.description
						};
						if (flag)
						{
							opCheckBox.colorEdge = this.cheatColor;
							opLabel.color = this.cheatColor;
						}
						opTab.AddItems(new UIelement[]
						{
							opCheckBox,
							opLabel
						});
						uiconfig = opCheckBox;
						if (opCheckBox.Key == MapExporterOptions.cfgDisableGateKarma.key)
						{
							opCheckBox.OnChange += this.ConfirmDisableKarma;
						}
						break;
					}
					case ValueConverter.TypeCategory.Integrals:
					{
						num += 36f;
						Configurable<int> configurable2 = lists[i][j] as Configurable<int>;
						OpUpdown opUpdown = new OpUpdown(configurable2, new Vector2(num2, num3 - num), 100f)
						{
							description = OptionInterface.Translate(configurable2.info.description),
							sign = i
						};
						opUpdown.OnChange += this.RefreshCurrentPresetLabel;
						UIfocusable.MutualVerticalFocusableBind(opUpdown, uiconfig ?? opUpdown);
						OpLabel opLabel2 = new OpLabel(new Vector2(num2 + 110f, num3 - num), new Vector2(170f, 36f), Custom.ReplaceLineDelimeters(OptionInterface.Translate(configurable2.info.Tags[0] as string)), FLabelAlignment.Left, false, ftextParams)
						{
							bumpBehav = opUpdown.bumpBehav,
							description = opUpdown.description
						};
						if (flag)
						{
							opUpdown.colorEdge = this.cheatColor;
							opUpdown.colorText = this.cheatColor;
							opLabel2.color = this.cheatColor;
						}
						opTab.AddItems(new UIelement[]
						{
							opUpdown,
							opLabel2
						});
						uiconfig = opUpdown;
						break;
					}
					case ValueConverter.TypeCategory.Floats:
					{
						num += 36f;
						Configurable<float> configurable3 = lists[i][j] as Configurable<float>;
						OpUpdown opUpdown2 = new OpUpdown(configurable3, new Vector2(num2, num3 - num), 100f, (configurable3 == MapExporterOptions.cfgSlowTimeFactor) ? 2 : 1)
						{
							description = OptionInterface.Translate(configurable3.info.description),
							sign = i
						};
						opUpdown2.OnChange += this.RefreshCurrentPresetLabel;
						UIfocusable.MutualVerticalFocusableBind(opUpdown2, uiconfig ?? opUpdown2);
						OpLabel opLabel3 = new OpLabel(new Vector2(num2 + 110f, num3 - num), new Vector2(170f, 36f), Custom.ReplaceLineDelimeters(OptionInterface.Translate(configurable3.info.Tags[0] as string)), FLabelAlignment.Left, false, ftextParams)
						{
							bumpBehav = opUpdown2.bumpBehav,
							description = opUpdown2.description
						};
						if (flag)
						{
							opUpdown2.colorEdge = this.cheatColor;
							opUpdown2.colorText = this.cheatColor;
							opLabel3.color = this.cheatColor;
						}
						opTab.AddItems(new UIelement[]
						{
							opUpdown2,
							opLabel3
						});
						uiconfig = opUpdown2;
						break;
					}
					}
				}
				num3 -= 70f;
				if (i == 0)
				{
					num2 += 300f;
					num3 = 550f;
					num = 40f;
					uiconfig = null;
				}
			}
			for (int k = 0; k < lists.Length; k++)
			{
				if (k == 0 || k == 1)
				{
					lists[k][0].BoundUIconfig.SetNextFocusable(UIfocusable.NextDirection.Up, lists[k][0].BoundUIconfig);
				}
				if (k == 0 || k == lists.Length - 1)
				{
					lists[k][lists[k].Length - 1].BoundUIconfig.SetNextFocusable(UIfocusable.NextDirection.Down, FocusMenuPointer.GetPointer(FocusMenuPointer.MenuUI.SaveButton));
				}
			}
			int num4 = 0;
			for (int l = 1; l < lists.Length; l++)
			{
				for (int m = 0; m < lists[l].Length; m++)
				{
					if (lists[l][m].BoundUIconfig != null)
					{
						lists[l][m].BoundUIconfig.SetNextFocusable(UIfocusable.NextDirection.Right, lists[l][m].BoundUIconfig);
						if (num4 < lists[0].Length)
						{
							if (lists[0][num4].BoundUIconfig == null)
							{
								num4++;
							}
							else
							{
								UIfocusable.MutualHorizontalFocusableBind(lists[0][num4].BoundUIconfig, lists[l][m].BoundUIconfig);
								lists[0][num4].BoundUIconfig.SetNextFocusable(UIfocusable.NextDirection.Left, FocusMenuPointer.GetPointer(FocusMenuPointer.MenuUI.CurrentTabButton));
								num4++;
							}
						}
						else
						{
							lists[l][m].BoundUIconfig.SetNextFocusable(UIfocusable.NextDirection.Left, lists[0][lists[0].Length - 1].BoundUIconfig);
						}
					}
				}
			}
		}

		// Token: 0x06002125 RID: 8485 RVA: 0x0029C83F File Offset: 0x0029AA3F
		public void RefreshCurrentPresetLabel()
		{
			this.currentPresetLabel.text = this.GetCurrentPresetString();
		}

		// Token: 0x06002126 RID: 8486 RVA: 0x0029C854 File Offset: 0x0029AA54
		public void PresetRemix(UIfocusable trigger)
		{
			for (int i = 0; i < MapExporterOptions.boolPresets.Count; i++)
			{
				if (MapExporterOptions.boolPresets[i].config.BoundUIconfig != null)
				{
					MapExporterOptions.boolPresets[i].config.BoundUIconfig.value = ValueConverter.ConvertToString<bool>(MapExporterOptions.boolPresets[i].remixValue);
				}
			}
			for (int j = 0; j < MapExporterOptions.intPresets.Count; j++)
			{
				if (MapExporterOptions.intPresets[j].config.BoundUIconfig != null)
				{
					MapExporterOptions.intPresets[j].config.BoundUIconfig.value = ValueConverter.ConvertToString<int>(MapExporterOptions.intPresets[j].remixValue);
				}
			}
			for (int k = 0; k < MapExporterOptions.floatPresets.Count; k++)
			{
				if (MapExporterOptions.floatPresets[k].config.BoundUIconfig != null)
				{
					MapExporterOptions.floatPresets[k].config.BoundUIconfig.value = ValueConverter.ConvertToString<float>(MapExporterOptions.floatPresets[k].remixValue);
				}
			}
			this.RefreshCurrentPresetLabel();
		}

		// Token: 0x06002127 RID: 8487 RVA: 0x0029C978 File Offset: 0x0029AB78
		public void PresetClassic(UIfocusable trigger)
		{
			for (int i = 0; i < MapExporterOptions.boolPresets.Count; i++)
			{
				if (MapExporterOptions.boolPresets[i].config.BoundUIconfig != null)
				{
					MapExporterOptions.boolPresets[i].config.BoundUIconfig.value = ValueConverter.ConvertToString<bool>(MapExporterOptions.boolPresets[i].classicValue);
				}
			}
			for (int j = 0; j < MapExporterOptions.intPresets.Count; j++)
			{
				if (MapExporterOptions.intPresets[j].config.BoundUIconfig != null)
				{
					MapExporterOptions.intPresets[j].config.BoundUIconfig.value = ValueConverter.ConvertToString<int>(MapExporterOptions.intPresets[j].classicValue);
				}
			}
			for (int k = 0; k < MapExporterOptions.floatPresets.Count; k++)
			{
				if (MapExporterOptions.floatPresets[k].config.BoundUIconfig != null)
				{
					MapExporterOptions.floatPresets[k].config.BoundUIconfig.value = ValueConverter.ConvertToString<float>(MapExporterOptions.floatPresets[k].classicValue);
				}
			}
			this.RefreshCurrentPresetLabel();
		}

		// Token: 0x06002128 RID: 8488 RVA: 0x0029CA9C File Offset: 0x0029AC9C
		public void ConfirmDisableKarma()
		{
			if (!ConfigContainer.mute && MapExporterOptions.cfgDisableGateKarma.BoundUIconfig.value == ValueConverter.ConvertToString<bool>(true))
			{
				ConfigConnector.CreateDialogBoxYesNo(string.Concat(new string[]
				{
					OptionInterface.Translate("This option disables multiple core mechanics of the game."),
					Environment.NewLine,
					OptionInterface.Translate("It also largely negates the game's difficulty curve and progression."),
					Environment.NewLine,
					OptionInterface.Translate("This may SIGNIFICANTLY alter your experience with the game."),
					Environment.NewLine,
					" ",
					Environment.NewLine,
					OptionInterface.Translate("You should try the 'Monk-style Gates' option first before resorting to using this option."),
					Environment.NewLine,
					" ",
					Environment.NewLine,
					OptionInterface.Translate("Are you sure you want to disable ALL karma mechanics?")
				}), new Action(this.EnableDisabledKarma), new Action(this.DisableDisabledKarma));
			}
		}

		// Token: 0x06002129 RID: 8489 RVA: 0x0029CB80 File Offset: 0x0029AD80
		public void EnableDisabledKarma()
		{
			MapExporterOptions.cfgDisableGateKarma.BoundUIconfig.value = ValueConverter.ConvertToString<bool>(true);
		}

		// Token: 0x0600212A RID: 8490 RVA: 0x0029CB97 File Offset: 0x0029AD97
		public void DisableDisabledKarma()
		{
			MapExporterOptions.cfgDisableGateKarma.BoundUIconfig.value = ValueConverter.ConvertToString<bool>(false);
		}

		// Token: 0x0600212B RID: 8491 RVA: 0x0029CBB0 File Offset: 0x0029ADB0
		public void ConfirmPresetRelaxed(UIfocusable trigger)
		{
			ConfigConnector.CreateDialogBoxYesNo(string.Concat(new string[]
			{
				OptionInterface.Translate("RELAXED preset is a significant reduction in difficulty."),
				Environment.NewLine,
				OptionInterface.Translate("If you are having trouble, you may want to try The Monk campaign first. It may help you get a better feel for the game and ease you into Rain World."),
				Environment.NewLine,
				" ",
				Environment.NewLine,
				OptionInterface.Translate("By comparison, the RELAXED preset may weaken the overall game experience."),
				Environment.NewLine,
				" ",
				Environment.NewLine,
				OptionInterface.Translate("Are you sure you want to use this preset?")
			}), new Action(this.PresetRelaxed), null);
		}

		// Token: 0x0600212C RID: 8492 RVA: 0x0029CC4C File Offset: 0x0029AE4C
		public void PresetRelaxed()
		{
			for (int i = 0; i < MapExporterOptions.boolPresets.Count; i++)
			{
				if (MapExporterOptions.boolPresets[i].config.BoundUIconfig != null)
				{
					MapExporterOptions.boolPresets[i].config.BoundUIconfig.value = ValueConverter.ConvertToString<bool>(MapExporterOptions.boolPresets[i].casualValue);
				}
			}
			for (int j = 0; j < MapExporterOptions.intPresets.Count; j++)
			{
				if (MapExporterOptions.intPresets[j].config.BoundUIconfig != null)
				{
					MapExporterOptions.intPresets[j].config.BoundUIconfig.value = ValueConverter.ConvertToString<int>(MapExporterOptions.intPresets[j].casualValue);
				}
			}
			for (int k = 0; k < MapExporterOptions.floatPresets.Count; k++)
			{
				if (MapExporterOptions.floatPresets[k].config.BoundUIconfig != null)
				{
					MapExporterOptions.floatPresets[k].config.BoundUIconfig.value = ValueConverter.ConvertToString<float>(MapExporterOptions.floatPresets[k].casualValue);
				}
			}
			this.RefreshCurrentPresetLabel();
		}

		// Token: 0x0600212D RID: 8493 RVA: 0x0029CD70 File Offset: 0x0029AF70
		public bool CheckPresetRemix()
		{
			for (int i = 0; i < MapExporterOptions.boolPresets.Count; i++)
			{
				if (MapExporterOptions.boolPresets[i].config.BoundUIconfig != null && MapExporterOptions.boolPresets[i].config.BoundUIconfig.value != ValueConverter.ConvertToString<bool>(MapExporterOptions.boolPresets[i].remixValue))
				{
					return false;
				}
			}
			for (int j = 0; j < MapExporterOptions.intPresets.Count; j++)
			{
				int num;
				bool flag = int.TryParse(MapExporterOptions.intPresets[j].config.BoundUIconfig.value, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
				int num2 = int.Parse(ValueConverter.ConvertToString<int>(MapExporterOptions.intPresets[j].remixValue), NumberStyles.Any, CultureInfo.InvariantCulture);
				if (!flag || num != num2)
				{
					return false;
				}
			}
			for (int k = 0; k < MapExporterOptions.floatPresets.Count; k++)
			{
				float num3;
				bool flag2 = float.TryParse(MapExporterOptions.floatPresets[k].config.BoundUIconfig.value, NumberStyles.Any, CultureInfo.InvariantCulture, out num3);
				float num4 = float.Parse(ValueConverter.ConvertToString<float>(MapExporterOptions.floatPresets[k].remixValue), NumberStyles.Any, CultureInfo.InvariantCulture);
				if (!flag2 || num3 != num4)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600212E RID: 8494 RVA: 0x0029CEC8 File Offset: 0x0029B0C8
		public bool CheckPresetClassic()
		{
			for (int i = 0; i < MapExporterOptions.boolPresets.Count; i++)
			{
				if (MapExporterOptions.boolPresets[i].config.BoundUIconfig != null && MapExporterOptions.boolPresets[i].config.BoundUIconfig.value != ValueConverter.ConvertToString<bool>(MapExporterOptions.boolPresets[i].classicValue))
				{
					return false;
				}
			}
			for (int j = 0; j < MapExporterOptions.intPresets.Count; j++)
			{
				int num;
				bool flag = int.TryParse(MapExporterOptions.intPresets[j].config.BoundUIconfig.value, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
				int num2 = int.Parse(ValueConverter.ConvertToString<int>(MapExporterOptions.intPresets[j].classicValue), NumberStyles.Any, CultureInfo.InvariantCulture);
				if (!flag || num != num2)
				{
					return false;
				}
			}
			for (int k = 0; k < MapExporterOptions.floatPresets.Count; k++)
			{
				float num3;
				bool flag2 = float.TryParse(MapExporterOptions.floatPresets[k].config.BoundUIconfig.value, NumberStyles.Any, CultureInfo.InvariantCulture, out num3);
				float num4 = float.Parse(ValueConverter.ConvertToString<float>(MapExporterOptions.floatPresets[k].classicValue), NumberStyles.Any, CultureInfo.InvariantCulture);
				if (!flag2 || num3 != num4)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600212F RID: 8495 RVA: 0x0029D020 File Offset: 0x0029B220
		public bool CheckPresetRelaxed()
		{
			for (int i = 0; i < MapExporterOptions.boolPresets.Count; i++)
			{
				if (MapExporterOptions.boolPresets[i].config.BoundUIconfig != null && MapExporterOptions.boolPresets[i].config.BoundUIconfig.value != ValueConverter.ConvertToString<bool>(MapExporterOptions.boolPresets[i].casualValue))
				{
					return false;
				}
			}
			for (int j = 0; j < MapExporterOptions.intPresets.Count; j++)
			{
				int num;
				bool flag = int.TryParse(MapExporterOptions.intPresets[j].config.BoundUIconfig.value, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
				int num2 = int.Parse(ValueConverter.ConvertToString<int>(MapExporterOptions.intPresets[j].casualValue), NumberStyles.Any, CultureInfo.InvariantCulture);
				if (!flag || num != num2)
				{
					return false;
				}
			}
			for (int k = 0; k < MapExporterOptions.floatPresets.Count; k++)
			{
				float num3;
				bool flag2 = float.TryParse(MapExporterOptions.floatPresets[k].config.BoundUIconfig.value, NumberStyles.Any, CultureInfo.InvariantCulture, out num3);
				float num4 = float.Parse(ValueConverter.ConvertToString<float>(MapExporterOptions.floatPresets[k].casualValue), NumberStyles.Any, CultureInfo.InvariantCulture);
				if (!flag2 || num3 != num4)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04001F4B RID: 8011
		private const int PRESET_TAB = 0;

		// Token: 0x04001F4C RID: 8012
		private const int GENERAL_TAB = 1;

		// Token: 0x04001F4D RID: 8013
		private const int ACCESSIBILITY_TAB = 2;

		// Token: 0x04001F4E RID: 8014
		private const string RED_MARK = "CHEAT_MARK";

		// Token: 0x04001F4F RID: 8015
		private readonly Color cheatColor = new Color(0.85f, 0.35f, 0.4f);

		// Token: 0x04001F50 RID: 8016
		private OpSimpleButton remixPresetBtn;

		// Token: 0x04001F51 RID: 8017
		private OpSimpleButton classicPresetBtn;

		// Token: 0x04001F52 RID: 8018
		private OpSimpleButton relaxedPresetBtn;

		// Token: 0x04001F53 RID: 8019
		private OpLabel currentPresetLabel;
	}
}
