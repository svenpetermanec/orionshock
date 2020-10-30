﻿// Copyright (c) 2020 Pryaxis & Orion Contributors
// 
// This file is part of Orion.
// 
// Orion is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Orion is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Orion.  If not, see <https://www.gnu.org/licenses/>.

namespace Orion.Core.World.Tiles
{
    /// <summary>
    /// Specifies a wall ID.
    /// </summary>
    public enum WallId : ushort
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        None = 0,
        Stone = 1,
        NaturalDirt = 2,
        NaturalEbonstone = 3,
        Wood = 4,
        GrayBrick = 5,
        RedBrick = 6,
        NaturalBlueBrick = 7,
        NaturalGreenBrick = 8,
        NaturalPinkBrick = 9,
        GoldBrick = 10,
        SilverBrick = 11,
        CopperBrick = 12,
        NaturalHellstoneBrick = 13,
        NaturalObsidianBrick = 14,
        NaturalMud = 15,
        Dirt = 16,
        BlueBrick = 17,
        GreenBrick = 18,
        PinkBrick = 19,
        ObsidianBrick = 20,
        Glass = 21,
        PearlstoneBrick = 22,
        IridescentBrick = 23,
        MudstoneBrick = 24,
        CobaltBrick = 25,
        MythrilBrick = 26,
        Planked = 27,
        NaturalPearlstone = 28,
        CandyCane = 29,
        GreenCandyCane = 30,
        SnowBrick = 31,
        AdamantiteBeam = 32,
        DemoniteBrick = 33,
        SandstoneBrick = 34,
        EbonstoneBrick = 35,
        RedStucco = 36,
        YellowStucco = 37,
        GreenStucco = 38,
        GrayStucco = 39,
        NaturalSnow = 40,
        Ebonwood = 41,
        RichMahogany = 42,
        Pearlwood = 43,
        RainbowBrick = 44,
        TinBrick = 45,
        TungstenBrick = 46,
        PlatinumBrick = 47,
        NaturalAmethystStone = 48,
        NaturalTopazStone = 49,
        NaturalSapphireStone = 50,
        NaturalEmeraldStone = 51,
        NaturalRubyStone = 52,
        NaturalDiamondStone = 53,
        NaturalGreenMossy = 54,
        NaturalBrownMossy = 55,
        NaturalRedMossy = 56,
        NaturalBlueMossy = 57,
        NaturalPurpleMossy = 58,
        NaturalRockyDirt = 59,
        LivingLeaf = 60,
        NaturalOldStone = 61,
        NaturalSpider = 62,
        NaturalGrass = 63,
        NaturalJungle = 64,
        NaturalFlower = 65,
        Grass = 66,
        Jungle = 67,
        Flower = 68,
        NaturalCorruptGrass = 69,
        NaturalHallowedGrass = 70,
        NaturalIce = 71,
        Cactus = 72,
        Cloud = 73,
        Mushroom = 74,
        BoneBlock = 75,
        SlimeBlock = 76,
        FleshBlock = 77,
        LivingWood = 78,
        NaturalObsidian = 79,
        NaturalMushroom = 80,
        NaturalCrimsonGrass = 81,
        Disc = 82,
        NaturalCrimstone = 83,
        IceBrick = 84,
        Shadewood = 85,
        NaturalHive = 86,
        NaturalLihzahrdBrick = 87,
        PurpleStainedGlass = 88,
        YellowStainedGlass = 89,
        BlueStainedGlass = 90,
        GreenStainedGlass = 91,
        RedStainedGlass = 92,
        MulticoloredStainedGlass = 93,
        NaturalBlueSlab = 94,
        NaturalBlueTiled = 95,
        NaturalPinkSlab = 96,
        NaturalPinkTiled = 97,
        NaturalGreenSlab = 98,
        NaturalGreenTiled = 99,
        BlueSlab = 100,
        BlueTiled = 101,
        PinkSlab = 102,
        PinkTiled = 103,
        GreenSlab = 104,
        GreenTiled = 105,
        WoodenFence = 106,
        LeadFence = 107,
        Hive = 108,
        PalladiumColumn = 109,
        BubblegumBlock = 110,
        TitanstoneBlock = 111,
        LihzahrdBrick = 112,
        Pumpkin = 113,
        Hay = 114,
        SpookyWood = 115,
        ChristmasTreeWallpaper = 116,
        OrnamentWallpaper = 117,
        CandyCaneWallpaper = 118,
        FestiveWallpaper = 119,
        StarsWallpaper = 120,
        SquigglesWallpaper = 121,
        SnowflakeWallpaper = 122,
        KrampusHornWallpaper = 123,
        BluegreenWallpaper = 124,
        GrinchFingerWallpaper = 125,
        FancyGrayWallpaper = 126,
        IceFloeWallpaper = 127,
        MusicWallpaper = 128,
        PurpleRainWallpaper = 129,
        RainbowWallpaper = 130,
        SparkleStoneWallpaper = 131,
        StarlitHeavenWallpaper = 132,
        BubbleWallpaper = 133,
        CopperPipeWallpaper = 134,
        DuckyWallpaper = 135,
        Waterfall = 136,
        Lavafall = 137,
        EbonwoodFence = 138,
        RichMahoganyFence = 139,
        PearlwoodFence = 140,
        ShadewoodFence = 141,
        WhiteDynasty = 142,
        BlueDynasty = 143,
        ArcaneRune = 144,
        IronFence = 145,
        CopperPlating = 146,
        StoneSlab = 147,
        Sail = 148,
        BorealWood = 149,
        BorealWoodFence = 150,
        PalmWood = 151,
        PalmWoodFence = 152,
        AmberGemspark = 153,
        AmethystGemspark = 154,
        DiamondGemspark = 155,
        EmeraldGemspark = 156,
        OfflineAmberGemspark = 157,
        OfflineAmethystGemspark = 158,
        OfflineDiamondGemspark = 159,
        OfflineEmeraldGemspark = 160,
        OfflineRubyGemspark = 161,
        OfflineSapphireGemspark = 162,
        OfflineTopazGemspark = 163,
        RubyGemspark = 164,
        SapphireGemspark = 165,
        TopazGemspark = 166,
        TinPlating = 167,
        Confetti = 168,
        MidnightConfetti = 169,
        NaturalCaveDirt = 170,
        NaturalRoughDirt = 171,
        Honeyfall = 172,
        ChlorophyteBrick = 173,
        CrimtaneBrick = 174,
        ShroomitePlating = 175,
        MartianConduit = 176,
        HellstoneBrick = 177,
        NaturalMarble = 178,
        SmoothMarble = 179,
        NaturalGranite = 180,
        SmoothGranite = 181,
        MeteoriteBrick = 182,
        Marble = 183,
        Granite = 184,
        NaturalCraggyStone = 185,
        CrystalBlock = 186,
        NaturalSandstone = 187,
        NaturalCorruptGrowth = 188,
        NaturalCorruptMass = 189,
        NaturalCorruptPustule = 190,
        NaturalCorruptTendril = 191,
        NaturalCrimsonCrust = 192,
        NaturalCrimsonScab = 193,
        NaturalCrimsonTeeth = 194,
        NaturalCrimsonBlister = 195,
        NaturalLayeredDirt = 196,
        NaturalCrumblingDirt = 197,
        NaturalCrackedDirt = 198,
        NaturalWavyDirt = 199,
        NaturalHallowedPrism = 200,
        NaturalHallowedCavern = 201,
        NaturalHallowedShard = 202,
        NaturalHallowedCrystalline = 203,
        NaturalLichenStone = 204,
        NaturalLeafyJungle = 205,
        NaturalIvyStone = 206,
        NaturalJungleVine = 207,
        NaturalEmber = 208,
        NaturalCinder = 209,
        NaturalMagma = 210,
        NaturalSmoulderingStone = 211,
        NaturalWornStone = 212,
        NaturalStalactiteStone = 213,
        NaturalMottledStone = 214,
        NaturalFracturedStone = 215,
        NaturalHardenedSand = 216,
        NaturalHardenedEbonsand = 217,
        NaturalHardenedCrimsand = 218,
        NaturalHardenedPearlsand = 219,
        NaturalEbonsandstone = 220,
        NaturalCrimsandstone = 221,
        NaturalPearlsandstone = 222,
        NaturalDesertFossil = 223,
        LuminiteBrick = 224,
        Cog = 225,
        Sandfall = 226,
        Snowfall = 227,
        SillyPinkBalloon = 228,
        SillyPurpleBalloon = 229,
        SillyGreenBalloon = 230,
        IronBrick = 231,
        LeadBrick = 232,
        LesionBlock = 233,
        CrimstoneBrick = 234,
        SmoothSandstone = 235,
        SpiderNest = 236,
        SolarBrick = 237,
        VortexBrick = 238,
        NebulaBrick = 239,
        StardustBrick = 240,
        OrangeStainedGlass = 241,
        GoldStarry = 242,
        BlueStarry = 243,
        NaturalLivingWood = 244,
        WroughtIronFence = 245,
        Ebonstone = 246,
        Mud = 247,
        Pearlstone = 248,
        Snow = 249,
        AmethystStone = 250,
        TopazStone = 251,
        SapphireStone = 252,
        EmeraldStone = 253,
        RubyStone = 254,
        DiamondStone = 255,
        GreenMossy = 256,
        BrownMossy = 257,
        RedMossy = 258,
        BlueMossy = 259,
        PurpleMossy = 260,
        RockyDirt = 261,
        OldStone = 262,
        Spider = 263,
        CorruptGrass = 264,
        HallowedGrass = 265,
        Ice = 266,
        Obsidian = 267,
        CrimsonGrass = 268,
        Crimstone = 269,
        CaveDirt = 270,
        RoughDirt = 271,
        UnusedMarble = 272,
        UnusedGranite = 273,
        CraggyStone = 274,
        Sandstone = 275,
        CorruptGrowth = 276,
        CorruptMass = 277,
        CorruptPustule = 278,
        CorruptTendril = 279,
        CrimsonCrust = 280,
        CrimsonScab = 281,
        CrimsonTeeth = 282,
        CrimsonBlister = 283,
        LayeredDirt = 284,
        CrumblingDirt = 285,
        CrackedDirt = 286,
        WavyDirt = 287,
        HallowedPrism = 288,
        HallowedCavern = 289,
        HallowedShard = 290,
        HallowedCrystalline = 291,
        LichenStone = 292,
        LeafyJungle = 293,
        IvyStone = 294,
        JungleVine = 295,
        Ember = 296,
        Cinder = 297,
        Magma = 298,
        SmoulderingStone = 299,
        WornStone = 300,
        StalactiteStone = 301,
        MottledStone = 302,
        FracturedStone = 303,
        HardenedSand = 304,
        HardenedEbonsand = 305,
        HardenedCrimsand = 306,
        HardenedPearlsand = 307,
        Ebonsandstone = 308,
        Crimsandstone = 309,
        Pearlsandstone = 310,
        DesertFossil = 311,
        Bamboo = 312,
        LargeBamboo = 313,
        AmberStone = 314,
        BambooFence = 315
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
