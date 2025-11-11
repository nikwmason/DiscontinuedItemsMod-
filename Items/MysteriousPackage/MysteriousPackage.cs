using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DiscontinuedItemsMod.Items.MysteriousPackage
{
    public class MysteriousPackage : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.name = "Mysterious Package";
            item.toolTip = "Summons a Pet Drone";
            item.shoot = mod.ProjectileType("PetName");
            item.buffType = mod.BuffType("PetDrone");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}