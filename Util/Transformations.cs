﻿using Buffs;
using DBZMOD;
using DBZMOD.Projectiles.Auras;
using Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Util
{
    // class for helping out with all the buff integers, lists of buffs in order, presence of buffs/abstraction
    public static class Transformations
    {
        private static Mod _modInstance;
        public static Mod modInstance
        {
            get
            {
                if (_modInstance == null)
                {
                    _modInstance = DBZMOD.DBZMOD.instance;
                }
                return _modInstance;
            }
        }

        private static Dictionary<string, BuffInfo> _buffInfoDict;
        // Using the buff internal name as the key. The BuffId is inside.
        public static Dictionary<string, BuffInfo> BuffInfoDict
        {
            get
            {
                if (_buffInfoDict == null)
                {
                    SeedBuffInfoDictionary();
                }
                return _buffInfoDict;
            }
        }

        // called on startup to cache the values of the mod's buffs in our own internal dictionary for faster lookups.
        public static void SeedBuffInfoDictionary()
        {
            _buffInfoDict = new Dictionary<string, BuffInfo>();
            _buffInfoDict[SSJ1.BuffKeyName] = SSJ1;
            _buffInfoDict[SSJ2.BuffKeyName] = SSJ2;
            _buffInfoDict[SSJ3.BuffKeyName] = SSJ3;
            _buffInfoDict[SSJG.BuffKeyName] = SSJG;
            _buffInfoDict[LSSJ.BuffKeyName] = LSSJ;
            _buffInfoDict[LSSJ2.BuffKeyName] = LSSJ2;
            _buffInfoDict[ASSJ.BuffKeyName] = ASSJ;
            _buffInfoDict[USSJ.BuffKeyName] = USSJ;
            _buffInfoDict[Kaioken.BuffKeyName] = Kaioken;
            _buffInfoDict[Kaioken3.BuffKeyName] = Kaioken3;
            _buffInfoDict[Kaioken10.BuffKeyName] = Kaioken10;
            _buffInfoDict[Kaioken20.BuffKeyName] = Kaioken20;
            _buffInfoDict[Kaioken100.BuffKeyName] = Kaioken100;
            _buffInfoDict[SSJ1Kaioken.BuffKeyName] = SSJ1Kaioken;
            _buffInfoDict[KaiokenFatigue.BuffKeyName] = KaiokenFatigue;
            _buffInfoDict[TransformationExhaustion.BuffKeyName] = TransformationExhaustion;
        }

        // the following are cached info classes that get passed around for all sorts of things.
        private static BuffInfo _SSJ1;
        public static BuffInfo SSJ1
        {
            get
            {
                if (_SSJ1 == null)
                {
                    _SSJ1 = new BuffInfo(MenuSelectionID.SSJ1, BuffKeyNames.SSJ1, modInstance.BuffType(BuffKeyNames.SSJ1), 0.6f, "Sounds/SSJAscension",
                        "Super Saiyan 1", DefaultTransformationTextColor, new Type[] { typeof(SSJ2AuraProj) }, new string[] { "SSJ1AuraProjStart" });
                }
                return _SSJ1;
            }
        }
        private static BuffInfo _SSJ1Kaioken;
        public static BuffInfo SSJ1Kaioken
        {
            get
            {
                if (_SSJ1Kaioken == null)
                {
                    _SSJ1Kaioken = new BuffInfo(MenuSelectionID.None, BuffKeyNames.SSJ1Kaioken, modInstance.BuffType(BuffKeyNames.SSJ1Kaioken), 0.8f, "Sounds/KaioAuraAscend",
                        null, DefaultTransformationTextColor, new Type[] { typeof(SSJ1AuraProj), typeof(KaiokenAuraProj) }, new string[] { "SSJ1AuraProjStart" });                    
                }
                return _SSJ1Kaioken;
            }
        }

        public static BuffInfo _SSJ2;
        public static BuffInfo SSJ2
        {
            get
            {
                if (_SSJ2 == null)
                {
                    _SSJ2 = new BuffInfo(MenuSelectionID.SSJ2, BuffKeyNames.SSJ2, modInstance.BuffType(BuffKeyNames.SSJ2), 0.7f, "Sounds/SSJAscension",
                         "Super Saiyan 2", DefaultTransformationTextColor, new Type[] { typeof(SSJ2AuraProj) }, new string[] { "SSJ2AuraProj" });
                }
                return _SSJ2;
            }
        }

        public static BuffInfo _SSJ3;
        public static BuffInfo SSJ3
        {
            get
            {
                if (_SSJ3 == null)
                {
                    _SSJ3 = new BuffInfo(MenuSelectionID.SSJ3, BuffKeyNames.SSJ3, modInstance.BuffType(BuffKeyNames.SSJ3), 0.7f, "Sounds/SSJAscension",
                         "Super Saiyan 3", DefaultTransformationTextColor, new Type[] { typeof(SSJ3AuraProj) }, new string[] { "SSJ3AuraProj" });
                }
                return _SSJ3;
            }
        }

        public static BuffInfo _SSJG;
        public static BuffInfo SSJG
        {
            get
            {
                if (_SSJG == null)
                {
                    _SSJG = new BuffInfo(MenuSelectionID.SSJG, BuffKeyNames.SSJG, modInstance.BuffType(BuffKeyNames.SSJG), 0.7f, "Sounds/SSJAscension",
                         "Super Saiyan God", DefaultTransformationTextColor, new Type[] { typeof(SSJGAuraProj) }, new string[] { "SSJGTransformStart" });
                }
                return _SSJG;
            }
        }

        public static BuffInfo _SSJB;
        public static BuffInfo SSJB
        {
            get
            {
                if (_SSJB == null)
                {
                    _SSJB = new BuffInfo(MenuSelectionID.SSJB, BuffKeyNames.SSJB, modInstance.BuffType(BuffKeyNames.SSJB), 0.7f, "Sounds/SSJAscension",
                         null, DefaultTransformationTextColor, new Type[] { }, new string[] { });
                }
                return _SSJB;
            }
        }

        public static BuffInfo _LSSJ;
        public static BuffInfo LSSJ
        {
            get
            {
                if (_LSSJ == null)
                {
                    _LSSJ = new BuffInfo(MenuSelectionID.LSSJ1, BuffKeyNames.LSSJ, modInstance.BuffType(BuffKeyNames.LSSJ), 0.7f, "Sounds/SSJAscension",
                         "Legendary Super Saiyan", DefaultTransformationTextColor, new Type[] { typeof(LSSJAuraProj) }, new string[] { "LSSJAuraProj" });
                }
                return _LSSJ;
            }
        }

        public static BuffInfo _LSSJ2;
        public static BuffInfo LSSJ2
        {
            get
            {
                if (_LSSJ2 == null)
                {
                    _LSSJ2 = new BuffInfo(MenuSelectionID.LSSJ2, BuffKeyNames.LSSJ2, modInstance.BuffType(BuffKeyNames.LSSJ2), 0.7f, "Sounds/SSJAscension",
                         "Legendary Super Saiyan 2", DefaultTransformationTextColor, new Type[] { typeof(LSSJ2AuraProj) }, new string[] { "LSSJ2AuraProj" });
                }
                return _LSSJ2;
            }
        }

        public static BuffInfo _ASSJ;
        public static BuffInfo ASSJ
        {
            get
            {
                if (_ASSJ == null)
                {
                    _ASSJ = new BuffInfo(MenuSelectionID.None, BuffKeyNames.ASSJ, modInstance.BuffType(BuffKeyNames.ASSJ), 1.0f, "Sounds/SSJAscension",
                         "Ascended Super Saiyan", DefaultTransformationTextColor, new Type[] { typeof(SSJ3AuraProj) }, new string[] { "SSJ3AuraProj" });
                }
                return _ASSJ;
            }
        }

        public static BuffInfo _USSJ;
        public static BuffInfo USSJ
        {
            get
            {
                if (_USSJ == null)
                {
                    _USSJ = new BuffInfo(MenuSelectionID.None, BuffKeyNames.USSJ, modInstance.BuffType(BuffKeyNames.USSJ), 0.7f, "Sounds/SSJAscension",
                         "Ultra Super Saiyan", DefaultTransformationTextColor, new Type[] { typeof(SSJ3AuraProj) }, new string[] { "SSJ3AuraProj" });
                }
                return _USSJ;
            }
        }

        public static BuffInfo _Kaioken;
        public static BuffInfo Kaioken
        {
            get
            {
                if (_Kaioken == null)
                {
                    _Kaioken = new BuffInfo(MenuSelectionID.None, BuffKeyNames.Kaioken, modInstance.BuffType(BuffKeyNames.Kaioken), 0.5f, "Sounds/KaioAuraStart",
                         null, DefaultTransformationTextColor, new Type[] { typeof(KaiokenAuraProj) }, new string[] { "KaiokenAuraProj" });
                }
                return _Kaioken;
            }
        }

        public static BuffInfo _Kaioken3;
        public static BuffInfo Kaioken3
        {
            get
            {
                if (_Kaioken3 == null)
                {
                    _Kaioken3 = new BuffInfo(MenuSelectionID.None, BuffKeyNames.Kaioken3, modInstance.BuffType(BuffKeyNames.Kaioken3), 0.6f, "Sounds/KaioAuraAscend",
                         null, DefaultTransformationTextColor, new Type[] { typeof(KaiokenAuraProjx3) }, new string[] { "KaiokenAuraProjx3" });
                }
                return _Kaioken3;
            }
        }

        public static BuffInfo _Kaioken10;
        public static BuffInfo Kaioken10
        {
            get
            {
                if (_Kaioken10 == null)
                {
                    _Kaioken10 = new BuffInfo(MenuSelectionID.None, BuffKeyNames.Kaioken10, modInstance.BuffType(BuffKeyNames.Kaioken10), 0.6f, "Sounds/KaioAuraAscend",
                         null, DefaultTransformationTextColor, new Type[] { typeof(KaiokenAuraProjx10) }, new string[] { "KaiokenAuraProjx10" });
                }
                return _Kaioken10;
            }
        }

        public static BuffInfo _Kaioken20;
        public static BuffInfo Kaioken20
        {
            get
            {
                if (_Kaioken20 == null)
                {
                    _Kaioken20 = new BuffInfo(MenuSelectionID.None, BuffKeyNames.Kaioken20, modInstance.BuffType(BuffKeyNames.Kaioken20), 0.7f, "Sounds/KaioAuraAscend",
                         null, DefaultTransformationTextColor, new Type[] { typeof(KaiokenAuraProjx20) }, new string[] { "KaiokenAuraProjx20" });
                }
                return _Kaioken20;
            }
        }

        public static BuffInfo _Kaioken100;
        public static BuffInfo Kaioken100
        {
            get
            {
                if (_Kaioken100 == null)
                {
                    _Kaioken100 = new BuffInfo(MenuSelectionID.None, BuffKeyNames.Kaioken100, modInstance.BuffType(BuffKeyNames.Kaioken100), 0.8f, "Sounds/KaioAuraAscend",
                         null, DefaultTransformationTextColor, new Type[] { typeof(KaiokenAuraProjx100) }, new string[] { "KaiokenAuraProjx100" });
                }
                return _Kaioken100;
            }
        }

        // the two debuffs from transforms
        public static BuffInfo _KaiokenFatigue;
        public static BuffInfo KaiokenFatigue
        {
            get
            {
                if (_KaiokenFatigue == null)
                {
                    _KaiokenFatigue = new BuffInfo(MenuSelectionID.None, BuffKeyNames.KaiokenFatigue, modInstance.BuffType(BuffKeyNames.KaiokenFatigue), 0.0f, null,
                         null, DefaultTransformationTextColor, new Type[] { }, new string[] { });
                }
                return _KaiokenFatigue;
            }
        }
        public static BuffInfo _TransformationExhaustion;
        public static BuffInfo TransformationExhaustion
        {
            get
            {
                if (_TransformationExhaustion == null)
                {
                    _TransformationExhaustion = new BuffInfo(MenuSelectionID.None, BuffKeyNames.TransformationExhaustion, modInstance.BuffType(BuffKeyNames.TransformationExhaustion), 0.0f, null,
                         null, DefaultTransformationTextColor, new Type[] { }, new string[] { });
                }
                return _TransformationExhaustion;
            }
        }

        // returns the buff Id of a transformation menu selection
        public static BuffInfo GetBuffFromMenuSelection(MenuSelectionID menuId)
        {
            // don't return any of the buffs by menu selection if there isn't a selection. That's bad.
            if (menuId == MenuSelectionID.None)
                return null;

            return BuffInfoDict.Values.Where(x => x.MenuId == menuId).FirstOrDefault();
        }

        // the typical color used for super saiyan transformation Text, except God
        public static Color DefaultTransformationTextColor = new Color(219, 219, 48);

        public static Color GodTransformationTextColor = new Color(229, 20, 51);

        public static BuffInfo GetBuffByKeyName(string keyName)
        {
            return BuffInfoDict[keyName];
        }

        public static BuffInfo GetBuffByBuffId(int buffId)
        {
            return BuffInfoDict.Values.Where(x => x.BuffId == buffId).FirstOrDefault();
        }

        // returns a list of transformation steps specific to non-legendary SSJ players
        public static BuffInfo[] SSJBuffs()
        {
            BuffInfo[] buffs = { SSJ1, SSJ2, SSJ3, SSJG };
            return buffs;
        }

        // a list of transformation steps specific to kaioken usage
        public static BuffInfo[] KaiokenBuffs()
        {
            BuffInfo[] buffs = { Kaioken, Kaioken3, Kaioken10, Kaioken20, Kaioken100 };
            return buffs;
        }

        // a list of transformation steps specific to legendary SSJ players
        public static BuffInfo[] LegendaryBuffs()
        {
            BuffInfo[] buffs = { SSJ1, LSSJ, LSSJ2 };
            return buffs;
        }

        // a list of transformation steps from SSJ1 through ascended SSJ forms
        public static BuffInfo[] AscensionBuffs()
        {
            BuffInfo[] buffs = { SSJ1, ASSJ, USSJ };
            return buffs;
        }

        // A bunch of lists joined together, in order to contain every possible transformation buff.
        // when adding new ones, make sure they wind up here in some form, even if you just have to add them one at a time.
        // (Union() excludes duplicates automatically)
        public static List<BuffInfo> AllBuffs()
        {
            return BuffInfoDict.Values.Where(x => x.BuffKeyName != BuffKeyNames.KaiokenFatigue && x.BuffKeyName != BuffKeyNames.TransformationExhaustion).ToList();
        }

        // whether the player is in any of the transformation states. Relies on AllBuffs() containing every possible transformation buff.
        public static bool IsPlayerTransformed(Player player)
        {
            foreach (BuffInfo buff in AllBuffs())
            {
                if (player.HasBuff(buff.BuffId))
                    return true;
            }

            return false;
        }

        public static bool PlayerHasBuffIn(Player player, BuffInfo[] buffs)
        {
            foreach (BuffInfo buff in buffs)
            {
                if (player.HasBuff(buff.BuffId))
                    return true;
            }

            return false;
        }

        public static bool BuffIsIn(BuffInfo buff, BuffInfo[] buffs) { return buffs.Contains(buff); }

        // whether the buff Id is one of the "normal" SSJ States (1, 2, 3, G)
        public static bool IsSSJ(BuffInfo buff)
        { return SSJBuffs().Contains(buff); }

        // whether the player is in *any* of the "normal" SSJ states (1, 2, 3, G)
        public static bool IsSSJ(Player player)
        {
            return PlayerHasBuffIn(player, SSJBuffs());
        }

        // fairly special state, whether the player is in SSJ1 and Kaioken combined, which has some special behaviors.
        public static bool IsSSJ1Kaioken(Player player)
        {
            return player.HasBuff(SSJ1Kaioken.BuffId);
        }

        // whether the buff ID is one of the Kaioken states, this excludes SSJ1Kaioken for Next/Previous behavior reasons.
        public static bool IsKaioken(BuffInfo buff)
        {
            return KaiokenBuffs().Contains(buff);
        }

        // whether the player is in one of the Kaioken states, this excludes SSJ1Kaioken for Next/Previous behavior reasons.
        public static bool IsKaioken(Player player)
        {
            return PlayerHasBuffIn(player, KaiokenBuffs());
        }

        // whether the buff ID is one of the legendary states; caution, this includes SSJ1 for "Next/Previous" behavior reasons.
        public static bool IsLegendary(BuffInfo buff)
        {
            return LegendaryBuffs().Contains(buff);
        }

        // whether the player is in one of the legendary states; caution, this includes SSJ1 for "Next/Previous" behavior reasons.
        public static bool IsLegendary(Player player)
        {
            return PlayerHasBuffIn(player, LegendaryBuffs());
        }

        // whether the player is in SSJG, specifically, for now.
        public static bool IsGodlike(Player player)
        {
            return player.HasBuff(SSJG.BuffId);
        }

        // specifically whether or not the player is in SSJ1, not to be confused with SSJ, "any" SSJ non-legendary form.
        public static bool IsSSJ1(Player player)
        {
            return player.HasBuff(SSJ1.BuffId);
        }

        // specifically whether or not the player is in ASSJ, used primarily for checking if ascension is valid.
        public static bool IsASSJ(Player player)
        {
            return player.HasBuff(ASSJ.BuffId);
        }

        // specifically whether or not the player is in ASSJ, used primarily for checking if ascension is valid.
        public static bool IsUSSJ(Player player)
        {
            return player.HasBuff(USSJ.BuffId);
        }

        // overload method of CanTransform(player, buffId [as int])
        public static bool CanTransform(Player player, MenuSelectionID menuId)
        {
            return CanTransform(player, GetBuffFromMenuSelection(menuId));
        }

        // whether the buff ID is one of the ascended states.
        public static bool IsAscended(BuffInfo buff)
        {
            return buff == ASSJ || buff == USSJ;
        }

        // whether the player is in either ascended state, used when ascending (charge + transform)
        public static bool IsAscended(Player player)
        {
            return player.HasBuff(ASSJ.BuffId) || player.HasBuff(USSJ.BuffId);
        }

        // handle all the conditions of a transformation which would prevent the player from reaching that state. Return false if you can't transform.
        // this doesn't include a few bits of player state which get handled in the player class. See MyPlayer CanTransform for more flags.
        public static bool CanTransform(Player player, BuffInfo buff)
        {
            if (buff == null)
                return false;

            MyPlayer modPlayer = MyPlayer.ModPlayer(player);
            if (buff == SSJ1)
                return !IsKaioken(player) && modPlayer.SSJ1Achieved;
            if (buff == SSJ2)
                return !IsKaioken(player) && modPlayer.playerTrait != "Legendary" && modPlayer.SSJ2Achieved;
            if (buff == SSJ3)
                return !IsKaioken(player) && modPlayer.playerTrait != "Legendary" && modPlayer.SSJ3Achieved;
            if (buff == SSJG)
                return !IsKaioken(player) && modPlayer.playerTrait != "Legendary" && modPlayer.SSJGAchieved;
            if (buff == LSSJ)
                return !IsKaioken(player) && modPlayer.playerTrait == "Legendary" && modPlayer.LSSJAchieved;
            if (buff == LSSJ2)
                return !IsKaioken(player) && modPlayer.playerTrait == "Legendary" && modPlayer.LSSJ2Achieved;
            //if (buffId == SSJB)
            //  return !IsKaioken(player) && modPlayer.SSJBAchieved;
            if (buff == ASSJ)
                return !IsKaioken(player) && (IsSSJ1(player) || IsUSSJ(player)) && modPlayer.ASSJAchieved;
            if (buff == USSJ)
                return !IsKaioken(player) && IsASSJ(player) && modPlayer.USSJAchieved;
            if (buff == Kaioken)
                return !IsSSJ(player) && !IsLegendary(player) && !IsAscended(player) && modPlayer.KaioAchieved;
            if (buff == Kaioken3)
                return !IsSSJ(player) && !IsLegendary(player) && !IsAscended(player) && modPlayer.KaioFragment1;
            if (buff == Kaioken10)
                return !IsSSJ(player) && !IsLegendary(player) && !IsAscended(player) && modPlayer.KaioFragment2;
            if (buff == Kaioken20)
                return !IsSSJ(player) && !IsLegendary(player) && !IsAscended(player) && modPlayer.KaioFragment3;
            if (buff == Kaioken100)
                return !IsSSJ(player) && !IsLegendary(player) && !IsAscended(player) && modPlayer.KaioFragment4;
            if (buff == SSJ1Kaioken)
                return IsSSJ1(player) && modPlayer.KaioAchieved;
            return false;
        }

        // handle a transformation where the startup goes to the menu selection instead of stepping up or down.
        public static void DoTransform(Player player, MenuSelectionID buffId, Mod mod)
        {
            if (buffId == MenuSelectionID.None)
                return;
            DoTransform(player, GetBuffFromMenuSelection(buffId), mod);
        }

        public static void AddKaiokenExhaustion(Player player, int multiplier)
        {
            MyPlayer modPlayer = MyPlayer.ModPlayer(player);
            player.AddBuff(KaiokenFatigue.BuffId, (int)Math.Ceiling(modPlayer.KaiokenTimer * multiplier));
            modPlayer.KaiokenTimer = 0f;
        }

        public static void AddTransformationExhaustion(Player player) { player.AddBuff(TransformationExhaustion.BuffId, 600); }

        public static bool IsExhaustedFromTransformation(Player player) { return player.HasBuff(TransformationExhaustion.BuffId); }

        public static bool IsTiredFromKaioken(Player player) { return player.HasBuff(KaiokenFatigue.BuffId); }

        // wipes out all transformation buffs, requires them to be a part of the AllBuffs() union (it's a bunch of lists joined together).
        public static void ClearAllTransformations(Player player, bool isPoweringDown)
        {
            foreach (BuffInfo buff in AllBuffs())
            {
                // don't clear buffs the player doesn't have, obviously.
                if (!player.HasBuff(buff.BuffId))
                    continue;

                // this way, we can apply exhaustion debuffs correctly.
                if (isPoweringDown)
                {
                    if (buff == SSJ1Kaioken)
                    {
                        // add both debuffs, and kaioken exhaustion is doubled
                        AddKaiokenExhaustion(player, 2);
                        AddTransformationExhaustion(player);
                    }
                    else if (KaiokenBuffs().Contains(buff))
                    {
                        // add the tired debuff and clear the kaioken timer
                        AddKaiokenExhaustion(player, 1);
                    }
                    else
                    {
                        // add the exhaustion debuff for transformations
                        AddTransformationExhaustion(player);
                    }
                }
                foreach (Type auraType in buff.AuraProjectileTypes)
                {
                    FindAndKillPlayerAurasOfType(player, auraType);
                }
                                
                player.ClearBuff(buff.BuffId);
            }
        }

        public static void FindAndKillPlayerAurasOfType(Player player, Type auraType)
        {
            foreach (Projectile proj in Main.projectile)
            {
                if (Main.player[proj.owner] != player)
                    continue;
                if (proj.modProjectile == null)
                    continue;
                // if it's an instance of an aura projectile kill it.
                if (proj.modProjectile.GetType().Equals(auraType))
                    proj.Kill();
            }
        }

        // create the projectile(s) representing the transformation aura.
        public static void DoProjectileForBuff(Player player, BuffInfo buff, Mod mod)
        {
            foreach (string projectileKey in buff.ProjectileKeys)
            {
                Projectile.NewProjectile(player.Center.X - 40, player.Center.Y + 90, 0, 0, mod.ProjectileType(projectileKey), 0, 0, player.whoAmI);
            }
        }

        // actually handle transforming. Takes quite a few steps to clean up after itself and do all the things.
        public static void DoTransform(Player player, BuffInfo buff, Mod mod)
        {
            BuffInfo currentTransformation = GetCurrentTransformation(player);

            MyPlayer modPlayer = MyPlayer.ModPlayer(player);
            
            bool isPoweringDown = buff == null || (currentTransformation == SSJ1Kaioken && buff.BuffId == SSJ1.BuffId);

            // don't.. try to apply the same transformation. This just stacks projectile auras and looks dumb.
            if (buff == currentTransformation)
                return;

            // remove all *transformation* buffs from the player.
            ClearAllTransformations(player, isPoweringDown);

            // if the buff needs dust aura, do that.
            if (SSJBuffs().Contains(buff) || buff == ASSJ || buff == USSJ)
                modPlayer.SSJDustAura();

            // add whatever buff it is for a really long time.
            player.AddBuff(buff.BuffId, 666666, false);

            // create the projectile starter if applicable.
            DoProjectileForBuff(player, buff, mod);

            if (!Main.dedServ && buff.SoundKey != null)
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, buff.SoundKey).WithVolume(buff.Volume));

            if (!string.IsNullOrEmpty(buff.TransformationText))
                CombatText.NewText(player.Hitbox, buff.TransformationTextColor, buff.TransformationText, false, false);
        }

        // return the first located transformation of a given player. Assumes there should only ever be one, returns the first it finds.
        public static BuffInfo GetCurrentTransformation(Player player)
        {
            foreach (BuffInfo buff in AllBuffs())
            {
                if (player.HasBuff(buff.BuffId))
                {
                    return buff;
                }
            }

            // is the player transformed? Something bad may have happened.
            return null;
        }

        // based on some conditions, figure out what the next "step" of transformation should be.
        public static BuffInfo GetNextTransformationStep(Player player)
        {
            BuffInfo currentTransformation = GetCurrentTransformation(player);

            // SSJ1 is always the starting point if there isn't a current form tree to step through.
            if (currentTransformation == null)
                return SSJ1;

            // the player is legendary and doing a legendary step up.
            if (IsLegendary(currentTransformation) && MyPlayer.ModPlayer(player).playerTrait == "Legendary")
            {
                for (int i = 0; i < LegendaryBuffs().Length; i++)
                {
                    if (LegendaryBuffs()[i] == currentTransformation && i < LegendaryBuffs().Length - 1)
                    {
                        return LegendaryBuffs()[i + 1];
                    }
                }
            }

            // the player isn't legendary and is doing a normal step up.
            if (IsSSJ(currentTransformation) && MyPlayer.ModPlayer(player).playerTrait != "Legendary")
            {
                for (int i = 0; i < SSJBuffs().Length; i++)
                {
                    if (SSJBuffs()[i] == currentTransformation && i < SSJBuffs().Length - 1)
                    {
                        return SSJBuffs()[i + 1];
                    }
                }
            }

            // whatever happened here, the function couldn't find a next step. Either the player is maxed in their steps, or something bad happened.
            return null;
        }

        // based on some conditions, figure out what the previous "step" of transformation should be. Note this includes ascension stepping down.
        public static BuffInfo GetPreviousTransformationStep(Player player)
        {
            BuffInfo currentTransformation = GetCurrentTransformation(player);

            // the player is legendary and doing a legendary step down.
            if (IsLegendary(currentTransformation) && MyPlayer.ModPlayer(player).playerTrait == "Legendary")
            {
                for (int i = 0; i < LegendaryBuffs().Length; i++)
                {
                    if (LegendaryBuffs()[i] == currentTransformation && i > 0)
                    {
                        return LegendaryBuffs()[i - 1];
                    }
                }
            }

            // the player isn't legendary and is doing a normal step down.
            if (IsSSJ(currentTransformation) && MyPlayer.ModPlayer(player).playerTrait != "Legendary")
            {
                for (int i = 0; i < SSJBuffs().Length; i++)
                {
                    if (SSJBuffs()[i] == currentTransformation && i > 0)
                    {
                        return SSJBuffs()[i - 1];
                    }
                }
            }

            // figure out what the step down for ascension should be, if the player is in an ascended form.
            if (IsAscended(currentTransformation))
            {
                for (int i = 0; i < AscensionBuffs().Length; i++)
                {
                    if (AscensionBuffs()[i] == currentTransformation && i > 0)
                    {
                        return AscensionBuffs()[i - 1];
                    }
                }
            }

            // either the player is at minimum or something bad has happened.
            return null;
        }

        // based on some conditions, figure out what the next "step" of kaioken should be.
        public static BuffInfo GetNextKaiokenStep(Player player)
        {
            BuffInfo currentTransformation = GetCurrentTransformation(player);

            // player is going into SSJ1 Kaioken, which is unique.
            if (currentTransformation == SSJ1)
                return SSJ1Kaioken;

            // special handling for Kaioken from no transformed state.
            if (currentTransformation == null)
                return Kaioken;

            // the player is doing some kind of kaioken transformation step up.
            if (IsKaioken(currentTransformation))
            {
                for (int i = 0; i < KaiokenBuffs().Length; i++)
                {
                    if (KaiokenBuffs()[i] == currentTransformation && i < KaiokenBuffs().Length - 1)
                    {
                        return KaiokenBuffs()[i + 1];
                    }
                }
            }

            // whatever happened here, the function couldn't find a next step. Either the player is maxed in their steps, or something bad happened.
            return currentTransformation;
        }

        // based on some conditions, figure out what the previous "step" of kaioken should be.
        public static BuffInfo GetPreviousKaiokenStep(Player player)
        {
            BuffInfo currentTransformation = GetCurrentTransformation(player);

            // player is going into SSJ1 Kaioken, which is unique.
            if (currentTransformation == SSJ1Kaioken)
                return SSJ1;

            // the player is doing some kind of kaioken transformation step up.
            if (IsKaioken(currentTransformation))
            {
                for (int i = 0; i < KaiokenBuffs().Length; i++)
                {
                    if (KaiokenBuffs()[i] == currentTransformation && i > 0)
                    {
                        return KaiokenBuffs()[i - 1];
                    }
                }
            }

            // whatever happened here, the function couldn't find a next step. Either the player is maxed in their steps, or something bad happened.
            return currentTransformation;
        }

        // based on some conditions, figure out what the next "step" of ascension should be.
        public static BuffInfo GetNextAscensionStep(Player player)
        {
            BuffInfo currentTransformation = GetCurrentTransformation(player);

            if (IsAscended(currentTransformation))
            {
                for (int i = 0; i < AscensionBuffs().Length; i++)
                {
                    if (AscensionBuffs()[i] == currentTransformation && i < AscensionBuffs().Length - 1)
                    {
                        return AscensionBuffs()[i + 1];
                    }
                }
            }

            return currentTransformation;
        }
    }
}