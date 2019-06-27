using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Terramon.NPCs
{
	[AutoloadHead]
	public class PokemonTrainer : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Terramon/NPCs/PokemonTrainer";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Pokémon Trainer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pokémon Trainer");
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 26;
			npc.height = 44;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Red";
				case 1:
					return "Red";
				case 2:
					return "Red";
				default:
					return "Red";
			}
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}
		
		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(mod.ItemType("Pokeball"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("GreatBall"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("UltraBall"));
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(8))
			{
				case 0:
					return "There's a lot of Pokemon out in the world, but you need Pokeballs to catch 'em!";
				case 1:
					return "I just got back from my Alola vacation. See my tan lines?";
				case 2:
					return "Pokemon are sorted into different tiers. If you complete a certain action, Pokemon in a higher tier may start appearing!";
				case 3:
					return "While carrying your Pokedex, '/pokedex' will open it up!";
				case 4:
					return "Pokemon appear in their respective regions. To encounter rock types, visit Kalor; the desert region.";
				case 5:
					return "Gotta Catch Em' All!";
				case 6:
					return "As your journey progresses, I'll be selling new things. Check back here every so often.";
				case 7:
					return "Rare Candies can level up your Pokemon. They live up to their name by being quite challenging to find!";
				default:
					return "Gotta Catch Em' All!";
			}
		}

		/* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.Next(4) == 0)
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		//public override void NPCLoot()
		//{
		//	Item.NewItem(npc.getRect(), mod.ItemType<Items.Armor.ExampleCostume>());
		//}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 0;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("PokeballProjectile");
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}