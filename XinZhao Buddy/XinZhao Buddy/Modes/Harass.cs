﻿using EloBuddy;
using EloBuddy.SDK;
using XinZhao_Buddy.Internal;

namespace XinZhao_Buddy.Modes
{
    internal class Harass
    {
        public static void Execute()
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                return;
            }

            if (Menu.Harass.E && Spells.E.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.E.Range, DamageType.Magical, Player.Instance.Position);
                if (target != null &&
                    (!Player.Instance.IsInAutoAttackRange(target) || Player.Instance.Health < target.Health))
                {
                    Spells.E.Cast(target);
                }
            }

            if (Menu.Harass.Hydra)
            {
                var hydra = new Item((int) ItemId.Ravenous_Hydra_Melee_Only, 250);
                var tiamat = new Item((int) ItemId.Tiamat_Melee_Only, 250);
                var item = hydra.IsReady() ? hydra : tiamat;
                var target = TargetSelector.GetTarget(item.Range, DamageType.Physical);
                if ((Item.HasItem((int) ItemId.Ravenous_Hydra_Melee_Only, Player.Instance) ||
                     Item.HasItem((int) ItemId.Tiamat_Melee_Only, Player.Instance)) && item.IsReady() &&
                    target.Distance(Player.Instance) < item.Range - 80)
                {
                    item.Cast();
                }
            }
        }
    }
}