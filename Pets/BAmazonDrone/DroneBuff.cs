using Terraria;
using Terraria.ModLoader;

namespace DiscontinuedItemsMod.Pets.BAmazonDrone
{
	public class PetDrone : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Pet Drone";
			Main.buffTip[Type] = "Summons a Pet Drone";
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("PetName")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("PetName"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}