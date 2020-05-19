using Microsoft.Xna.Framework;
using TaoMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using TaoMod.Projectiles;
using static Terraria.ModLoader.ModContent;
using TaoMod.Items.Consumables;

namespace TaoMod.NPCs.Shaoyang
{
	[AutoloadBossHead]
	public class Shaoyang : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shaoyang");
			NPCID.Sets.MustAlwaysDraw[npc.type] = true;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 4000;
			npc.damage = 25;
			npc.defense = 15;
			npc.knockBackResist = 0f;
			npc.width = 64;
			npc.height = 64;
			npc.value = Item.buyPrice(0, 1, 50, 45);
			npc.boss = true;
			npc.scale = 1.25f;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath27;
			npc.alpha = 255;
			//music = MusicID.Title;
		    //musicPriority = MusicPriority.BossHigh; 
			bossBag = ItemType<ShaoyangTreasureBag>();
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 8000;
			npc.defense = 19;
			npc.damage = 50;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position + new Vector2(10f, 0f), Vector2.Zero, Main.rand.Next(61, 63), 2f);
			}
		}

		public override void NPCLoot()
		{
			if (!Main.expertMode)
			{
				Item.NewItem(npc.getRect(), ItemType<EssenceofYang>(), Main.rand.Next(4,9));
			}
			if (!TaoWorld.downedShaoyang)
			{
				TaoWorld.downedShaoyang = true;
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
				}
			}
		}

		private int AlphaTimer = 0;
		private int ShootSpear = 0;
		private int ExpertShootSpear = 0;
		private int DashTimer = 0;
		private Vector2 speed = new Vector2(65);
		private Vector2 lightTrailVelocity = new Vector2(0);
		private int DashDuration = 0;
		private int stillVelocity = 1;
		private int LightTrailTimer = 0;
		private int Phase1ChaseSpeed = 4;
		private int FunnyExplosionOrbTimer = 0;
		private bool CreateOrbField;
		public override void AI()
		{
			npc.rotation++;
			npc.TargetClosest(true);
			if (++AlphaTimer % 3 == 0 && npc.alpha > 40)
			{
				npc.alpha -= 5;
				AlphaTimer = 0;
			}

			if (Main.expertMode)
			{
				if (npc.life > 3999)
				{
					npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * Phase1ChaseSpeed;
					FunnyExplosionOrbTimer++;
					if (FunnyExplosionOrbTimer % 150 == 0)
					{
						float numberProjectiles = 12;
						float rotation = MathHelper.ToRadians(360);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Vector2 perturbedSpeed = new Vector2(2, 2).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
							Projectile.NewProjectile(npc.Center, perturbedSpeed, ProjectileType<YangOrb>(), 35, 0f);
						}
						FunnyExplosionOrbTimer = 0;
					}
					ShootSpear++;
					ExpertShootSpear++;
					if (++ShootSpear % 480 == 0)
					{
						if (++ExpertShootSpear % 4 == 0)
						{
							NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y, NPCType<YangSpear>());
							NPC.NewNPC((int)npc.Center.X + 50, (int)npc.position.Y - 53, NPCType<YangSpear>());
							NPC.NewNPC((int)npc.Center.X - 50, (int)npc.position.Y - 53, NPCType<YangSpear>());

							ExpertShootSpear = 0;
						}
						ShootSpear = 0;
					}
					else if (npc.life < 4001 && npc.life > 199)
					{
						if (DashDuration > 0)
						{
							LightTrailTimer++;
						}
						if (LightTrailTimer >= 3)
						{
							Projectile.NewProjectile(npc.Center, lightTrailVelocity, ProjectileType<LightTrail>(), 10, 0f);
							LightTrailTimer = 0;
						}
						DashTimer++;
						DashDuration--;
						if (++DashTimer % 180 == 0)
						{
							if (DashDuration < 0)
							{
								DashDuration = 100;
								Main.PlaySound(new LegacySoundStyle(SoundID.Roar, 0), npc.Center);
								npc.DirectionTo(Main.player[npc.target].Center);
								npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * speed;
								float numberProjectiles = 6;
								float rotation = MathHelper.ToRadians(80);
								for (int i = 0; i < numberProjectiles; i++)
								{
									Vector2 perturbedSpeed = new Vector2(2, 2).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
									Projectile.NewProjectile(npc.Center, perturbedSpeed, ProjectileType<YangOrb>(), 35, 0f);
								}
							}
						}
						if (DashTimer > 0 && DashDuration == 0)
						{
							npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * stillVelocity;
						}
					}
					else if (npc.life < 201)
					{
						if (CreateOrbField == false)
						{
							float numberProjectiles = 6;
							float rotation = MathHelper.ToRadians(80);
							for (int i = 0; i < numberProjectiles; i++)
							{
								Vector2 perturbedSpeed = new Vector2(1, 1).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
								Projectile.NewProjectile(npc.Center, perturbedSpeed, ProjectileType<YangOrb>(), 35, 0f);
							}
							CreateOrbField = true;
						}
						if (DashDuration > 0)
						{
							LightTrailTimer++;
						}
						if (LightTrailTimer >= 3)
						{
							Projectile.NewProjectile(npc.Center, lightTrailVelocity, ProjectileType<LightTrail>(), 10, 0f);
							LightTrailTimer = 0;
						}
						DashTimer++;
						DashDuration--;
						if (++DashTimer % 180 == 0)
						{
							if (DashDuration < 0)
							{
								DashDuration = 100;
								Main.PlaySound(new LegacySoundStyle(SoundID.Roar, 0), npc.Center);
								npc.DirectionTo(Main.player[npc.target].Center);
								npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * speed;
								float numberProjectiles = 6;
								float rotation = MathHelper.ToRadians(80);
								for (int i = 0; i < numberProjectiles; i++)
								{
									Vector2 perturbedSpeed = new Vector2(2, 2).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
									Projectile.NewProjectile(npc.Center, perturbedSpeed, ProjectileType<YangOrb>(), 35, 0f);
								}
							}
						}
					}
				}
			}
			else
			{
				if (npc.life > 1999)
				{
					npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * Phase1ChaseSpeed;
					FunnyExplosionOrbTimer++;
					if (FunnyExplosionOrbTimer % 225 == 0)
					{
						float numberProjectiles = 6;
						float rotation = MathHelper.ToRadians(360);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Vector2 perturbedSpeed = new Vector2(2, 2).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
							Projectile.NewProjectile(npc.Center, perturbedSpeed, ProjectileType<YangOrb>(), 25, 0f);
						}
						FunnyExplosionOrbTimer = 0;
					}
					ShootSpear++;
					if (++ShootSpear % 600 == 0)
					{
						NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y, NPCType<YangSpear>());
						ShootSpear = 0;
					}
				}
				else if (npc.life < 2001)
				{
					if (DashDuration > 0)
					{
						LightTrailTimer++;
					}
					if (LightTrailTimer >= 3)
					{
						Projectile.NewProjectile(npc.Center, lightTrailVelocity, ProjectileType<LightTrail>(), 10, 0f);
						LightTrailTimer = 0;
					}
					DashTimer++;
					DashDuration--;
					if (++DashTimer % 300 == 0)
					{
						if (DashDuration < 0)
						{
							DashDuration = 180;
							Main.PlaySound(new LegacySoundStyle(SoundID.Roar, 0), npc.Center);
							npc.DirectionTo(Main.player[npc.target].Center);
							npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * speed;
							float numberProjectiles = 4;
							float rotation = MathHelper.ToRadians(85);
							for (int i = 0; i < numberProjectiles; i++)
							{
								Vector2 perturbedSpeed = new Vector2(2, 2).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
								Projectile.NewProjectile(npc.Center, perturbedSpeed, ProjectileType<YangOrb>(), 35, 0f);
							}
						}
					}
					if (DashTimer > 0 && DashDuration == 0)
					{
						npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * stillVelocity;
					}
				}
			}
		}
	}
}
