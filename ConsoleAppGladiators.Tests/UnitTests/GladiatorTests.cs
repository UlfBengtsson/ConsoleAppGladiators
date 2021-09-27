using ConsoleAppGladiators.Models;
using System;
using Xunit;

namespace ConsoleAppGladiators.Tests
{
    public class GladiatorTests
    {
        [Fact]
        public void NpcGladiatorGetsStatsAndNameTest()
        {
            //Arrange
            Gladiator gladiator;

            //Act
            gladiator = new Gladiator();

            //Assert
            Assert.NotEqual(0, gladiator.id);
            Assert.True(gladiator.Alive);
            Assert.InRange(gladiator.Dex, 1, 12);
            Assert.InRange(gladiator.Str, 1, 12);
            Assert.InRange(gladiator.Vit, 1, 12);
            Assert.InRange(gladiator.HP, 10, 120);
            Assert.False(string.IsNullOrWhiteSpace(gladiator.Name));
            Assert.True( gladiator.Name.Length > 1 );
        }

        [Fact]
        public void PlayerGladiatorGetsStatsAndNameTest()
        {
            //Arrange
            string name = "Maximus";
            int str = 12;
            int dex = 12;
            int vit = 12;
            int hp = 120;
            Gladiator gladiator;

            //Act
            gladiator = new Gladiator(name, str, dex, vit);

            //Assert
            Assert.NotEqual(0, gladiator.id);
            Assert.True(gladiator.Alive);
            Assert.Equal(dex, gladiator.Dex);
            Assert.Equal(str, gladiator.Str);
            Assert.Equal(vit, gladiator.Vit);
            Assert.Equal(hp, gladiator.HP);
            Assert.False(string.IsNullOrWhiteSpace(gladiator.Name));
            Assert.True(gladiator.Name.Length > 1);
        }

        [Fact]
        public void PlayerGladiatorGetsUniqueIdTest()
        {
            //Arrange
            string name = "Maximus";
            int str = 12;
            int dex = 12;
            int vit = 12;
            Gladiator gladiator1;
            Gladiator gladiator2;
            Gladiator gladiator3;

            //Act
            gladiator1 = new Gladiator(name, str, dex, vit);
            gladiator2 = new Gladiator(name, str, dex, vit);
            gladiator3 = new Gladiator(name, str, dex, vit);

            //Assert
            Assert.NotEqual(0, gladiator1.id);
            Assert.NotEqual(0, gladiator2.id);
            Assert.NotEqual(0, gladiator3.id);
            Assert.NotEqual(gladiator1.id, gladiator2.id);
            Assert.NotEqual(gladiator1.id, gladiator3.id);
            Assert.NotEqual(gladiator2.id, gladiator3.id);

        }

        [Fact]
        public void NpcGladiatorGetsUniqueIdTest()
        {
            //Arrange
            Gladiator gladiator1;
            Gladiator gladiator2;
            Gladiator gladiator3;

            //Act
            gladiator1 = new Gladiator();
            gladiator2 = new Gladiator();
            gladiator3 = new Gladiator();

            //Assert
            Assert.NotEqual(0, gladiator1.id);
            Assert.NotEqual(0, gladiator2.id);
            Assert.NotEqual(0, gladiator3.id);
            Assert.NotEqual(gladiator1.id, gladiator2.id);
            Assert.NotEqual(gladiator1.id, gladiator3.id);
            Assert.NotEqual(gladiator2.id, gladiator3.id);

        }

        [Fact]
        public void PlayerAndNpcGladiatorsGetsUniqueIdTest()
        {
            //Arrange
            string name = "Maximus";
            int str = 12;
            int dex = 12;
            int vit = 12;
            Gladiator gladiator1Player;
            Gladiator gladiator2Npc;
            Gladiator gladiator3Player;

            //Act
            gladiator1Player = new Gladiator(name, str, dex, vit);
            gladiator2Npc = new Gladiator();
            gladiator3Player = new Gladiator(name, str, dex, vit);

            //Assert
            Assert.NotEqual(0, gladiator1Player.id);
            Assert.NotEqual(0, gladiator2Npc.id);
            Assert.NotEqual(0, gladiator3Player.id);
            Assert.NotEqual(gladiator1Player.id, gladiator2Npc.id);
            Assert.NotEqual(gladiator1Player.id, gladiator3Player.id);
            Assert.NotEqual(gladiator2Npc.id, gladiator3Player.id);

        }

        [Fact]
        public void TakeDamageOk()
        {
            //Arrange
            Gladiator gladiator = new Gladiator();
            int hpBefore = gladiator.HP;

            //Act
            bool reslut = gladiator.TakeDamage(1);

            //Assert
            Assert.True(reslut);
            Assert.True(gladiator.Alive);
            Assert.Equal(hpBefore - 1, gladiator.HP);
        }

        [Fact]
        public void TakeDamageInstaKillWorks()
        {
            //Arrange
            Gladiator gladiator = new Gladiator("test glad", 1, 1, 1);
            bool instaKill = gladiator.TakeDamage(999);

            //Act
            bool reslut = gladiator.TakeDamage(1);

            //Assert
            Assert.True(instaKill);
            Assert.False(gladiator.Alive);//is dead
        }

        [Fact]
        public void NoTakeDamageWorks()
        {
            //Arrange
            Gladiator gladiator = new Gladiator("test glad",1,1,1);
            bool instaKill = gladiator.TakeDamage(999);
            int hpAfterDeath = gladiator.HP;

            //Act
            bool reslut = gladiator.TakeDamage(1);
            int hpUnchanged = gladiator.HP;

            //Assert
            Assert.True(instaKill);
            Assert.False(gladiator.Alive);
            Assert.Equal(hpAfterDeath, hpUnchanged);
        }
    }
}
