using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using RWCustom;
using System;
using MoreSlugcats;
using JollyCoop;

namespace MapExporter;

public class RoomInfo : IJsonObject
{
    readonly Dictionary<string, RoomEntry> rooms;
    readonly List<SettingsEntry> roomSettings;
    readonly HashSet<string> worldPlacedObjects;
    readonly string acronym;

    public string copyRooms;
    public RoomInfo(RainWorldGame game, World world, AbstractRoom room, IEnumerable<string> raw)
    {
        acronym = world.name;

        rooms = new Dictionary<string, RoomEntry>();
        roomSettings = new List<SettingsEntry>();

        worldPlacedObjects = new HashSet<string>();

        LoadValidRooms(game, world, room);
        LoadRoomSettings(raw);
    }

        static bool IsSlugcatFromMSC(SlugcatStats.Name i)
        {
            if (!(i.value == "Rivulet") && !(i.value == "Artificer") && !(i.value == "Saint") && !(i.value == "Spear") && !(i.value == "Gourmand"))
            {
                return i.value == "Inv";
            }

            return true;
        }
        static bool HiddenOrUnplayableSlugcat(SlugcatStats.Name i)
        {
            if (i == SlugcatStats.Name.Night)
            {
                return true;
            }

            if (ModManager.MSC && i == MoreSlugcatsEnums.SlugcatStatsName.Sofanthiel)
            {
                return true;
            }

            if (ModManager.MSC && i == MoreSlugcatsEnums.SlugcatStatsName.Slugpup)
            {
                return true;
            }

            if (ModManager.JollyCoop && i == JollyEnums.Name.JollyPlayer1)
            {
                return true;
            }

            if (ModManager.JollyCoop && i == JollyEnums.Name.JollyPlayer2)
            {
                return true;
            }

            if (ModManager.JollyCoop && i == JollyEnums.Name.JollyPlayer3)
            {
                return true;
            }

            if (ModManager.JollyCoop && i == JollyEnums.Name.JollyPlayer4)
            {
                return true;
            }

            return false;
        }

    public RoomEntry GetOrCreateRoomEntry(string name)
    {
        return rooms.TryGetValue(name, out var value) ? value : rooms[name] = new(name);
    }

    //helpers
    static string PathOfRegion(string slugcat, string region)
    {
        return Directory.CreateDirectory(Path.Combine(Custom.LegacyRootFolderDirectory(), "export", slugcat.ToLower(), region.ToLower())).FullName;
    }

    static string PathOfSlugcatData()
    {
        return Path.Combine(Path.Combine(Custom.LegacyRootFolderDirectory(), "export", "slugcats.json"));
    }

    static string PathOfMetadata(string slugcat, string region)
    {
        return Path.Combine(PathOfRegion(slugcat, region), "metadata.json");
    }

    static string PathOfRoomSettings(string slugcat, string region)
    {
        return Path.Combine(PathOfRegion(slugcat, region), "roomsettings.json");
    }

    static string PathOfScreenshot(string slugcat, string region, string room, int num)
    {
        return $"{Path.Combine(PathOfRegion(slugcat, region), room.ToLower())}_{num}.png";
    }

    private static int ScugPriority(string slugcat)
    {
        return slugcat switch
        {
            "white" => 10,      // do White first, they have the most generic regions
            "artificer" => 9,   // do Artificer next, they have Metropolis, Waterfront Facility, and past-GW
            "saint" => 8,       // do Saint next for Undergrowth and Silent Construct
            "rivulet" => 7,     // do Rivulet for The Rot
            "inv" => 6,         // because
            _ => 0              // everyone else has a mix of duplicate rooms
        };
    }

    //determine the valid rooms

    //Find the room settings
    public void LoadValidRooms(RainWorldGame game, World world, AbstractRoom room)
    {
        SlugcatStats.Name slugcat = game.StoryCharacter;
        HashSet<string> worldPlacedObjects;
        worldPlacedObjects = new HashSet<string>();

        string path = AssetManager.ResolveFilePath(
                $"World{Path.DirectorySeparatorChar}{world.name}-rooms{Path.DirectorySeparatorChar}{room.name}_settings-{world.game.GetStorySession.saveState.saveStateNumber}.txt"
                );

        if (!File.Exists(path))
        {
            path = AssetManager.ResolveFilePath(
                $"World{Path.DirectorySeparatorChar}{world.name}-rooms{Path.DirectorySeparatorChar}{room.name}_settings.txt"
                );
            if (!File.Exists(path))
            {
                path = AssetManager.ResolveFilePath(
                    $"World{Path.DirectorySeparatorChar}gates{Path.DirectorySeparatorChar}{room.name}_settings.txt"
                    );
                if (!File.Exists(path))
                {
                    MapExporterMain.Logger.LogWarning($"No room data for {world.game.StoryCharacter}/{world.name}-rooms/{room.name} at {path}");

                    path = AssetManager.ResolveFilePath(
                    $"World{Path.DirectorySeparatorChar}gates{Path.DirectorySeparatorChar}{room.name}_settings-{world.game.GetStorySession.saveState.saveStateNumber}.txt"
                    );

                    if (!File.Exists(path))
                    {
                        MapExporterMain.Logger.LogWarning($"No gate data for {world.game.StoryCharacter}/gates/{room.name} at {path}");
                    }
                    else
                    {
                        MapExporterMain.Logger.LogDebug($"Found specific gate data for {world.game.StoryCharacter}/gates/{room.name} at {path}");

                        AssimilatePlacedObjects(File.ReadAllLines(path));
                    }
                }
                else
                {
                    MapExporterMain.Logger.LogDebug($"Found generic gate data for {world.game.StoryCharacter}/gates/{room.name} at {path}");

                    AssimilatePlacedObjects(File.ReadAllLines(path));
                }
            }
            else
            {
                MapExporterMain.Logger.LogDebug($"Found generic room data for {world.game.StoryCharacter}/{world.name}-rooms/{room.name} at {path}");

                AssimilatePlacedObjects(File.ReadAllLines(path));
            }


        }
        else
        {
            MapExporterMain.Logger.LogDebug($"Found specific room data for {world.game.StoryCharacter}/{world.name}-rooms/{room.name} at {path}");

            AssimilatePlacedObjects(File.ReadAllLines(path));
        }

        File.WriteAllText(PathOfRoomSettings(slugcat.value, world.name), Json.Serialize(worldPlacedObjects));

        void AssimilatePlacedObjects(IEnumerable<string> raw)
        {
            bool insideofplacedobjects = false;
            foreach (var item in raw)
            {
                if (item == "PlacedObjects: ") insideofplacedobjects = true;
                else if (item == "AmbientSounds: ") insideofplacedobjects = false;
                else if (insideofplacedobjects)
                {
                    if (string.IsNullOrEmpty(item) || item.StartsWith("//")) continue;
                    worldPlacedObjects.Add(item);
                }
            }
        }

    }
    //separate PlacedObjects from the rest of room settings
    public void LoadRoomSettings(IEnumerable<string> raw)
    {
        bool withinbounds = false;
        foreach (var item in raw)
        {
            if (item == "PlacedObjects: ") withinbounds = true;
            else if (item == "AmbientSounds: ") withinbounds = false;
            else if (withinbounds)
            {
                if (string.IsNullOrEmpty(item) || item.StartsWith("//")) continue;
                worldPlacedObjects.Add(item);
            }
        }
    }


    public Dictionary<string, object> ToJson()
    {
        var ret = new Dictionary<string, object>
        {
            ["acronym"] = acronym,
        };
        if (copyRooms == null)
        {
            ret["rooms"] = rooms;
            ret["roomSettings"] = roomSettings;
        }
        else
        {
            ret["copyRooms"] = copyRooms;
        }
        ret["placedObjects"] = worldPlacedObjects.ToArray();
        return ret;
    }
        public class RoomEntry : IJsonObject
        {
            public string roomName;

            public RoomEntry(string roomName)
            {
                this.roomName = roomName;
            }

            // from map txt
            public Vector2 devPos;
            public Vector2 canPos;
            public int canLayer;
            public string subregion;
            public bool everParsed = false;
            public void ParseEntry(string entry)
            {
                string[] fields = Regex.Split(entry, ", ");
                canPos.x = float.Parse(fields[0]);
                canPos.y = float.Parse(fields[1]);
                devPos.x = float.Parse(fields[2]);
                devPos.y = float.Parse(fields[3]);
                canLayer = int.Parse(fields[4]);
                subregion = fields[5];
                everParsed = true;
            }

            // wish there was a better way to do this
            public Dictionary<string, object> ToJson()
            {
                return new Dictionary<string, object>()
                {
                    { "roomName", roomName },
                    { "canLayer", canLayer },
                    { "subregion", subregion },
                };
            }
        }

        sealed class SettingsEntry : IJsonObject
        {
            public string roomA;
            public string roomB;
            public IntVector2 posA;
            public IntVector2 posB;
            public int dirA;
            public int dirB;

            public SettingsEntry(string entry)
            {
                string[] fields = Regex.Split(entry, ", ");
                roomA = fields[0];
                roomB = fields[1];
                posA = new IntVector2(int.Parse(fields[2]), int.Parse(fields[3]));
                posB = new IntVector2(int.Parse(fields[4]), int.Parse(fields[5]));
                dirA = int.Parse(fields[6]);
                dirB = int.Parse(fields[7]);
            }

            public Dictionary<string, object> ToJson()
            {
                return new Dictionary<string, object>()
                {
                    { "roomA", roomA },
                    { "roomB", roomB },
                    { "dirA", dirA },
                    { "dirB", dirB },
                };
            }
        }

}