using ConsoleAppGladiators.Models;
using System;
using Xunit;

namespace ConsoleAppGladiators.Tests.UnitTests
{
    public class ColseumTests
    {
        [Fact]
        public void ColseumStartsEmpty()
        {
            //Arrange
            Coloseum coloseum;

            //Act
            coloseum = new Coloseum();

            //Assert
            Assert.Empty(coloseum.AllFighters());
        }

        [Fact]
        public void AddGladiatorToColseum()
        {
            //Arrange
            Coloseum coloseum;
            coloseum = new Coloseum();
            Gladiator gladiator1 = new Gladiator();
            Gladiator gladiator2 = new Gladiator();
            Gladiator gladiator3 = new Gladiator();

            //Act
            coloseum.AddGladiator(gladiator1);
            coloseum.AddGladiator(gladiator2);
            coloseum.AddGladiator(gladiator3);

            //Assert
            Assert.Contains(gladiator1 ,coloseum.AllFighters());
            Assert.Contains(gladiator2 ,coloseum.AllFighters());
            Assert.Contains(gladiator3 ,coloseum.AllFighters());
        }

        [Fact]
        public void RemoveAGladiatorFromColseum()
        {
            //Arrange
            Coloseum coloseum;
            coloseum = new Coloseum();
            Gladiator gladiator1 = new Gladiator();
            Gladiator gladiator2 = new Gladiator();
            Gladiator gladiator3 = new Gladiator();
            coloseum.AddGladiator(gladiator1);
            coloseum.AddGladiator(gladiator2);//to be removed
            coloseum.AddGladiator(gladiator3);

            //Act
            bool result = coloseum.RemoveGladiator(gladiator2.id);

            //Assert
            Assert.True(result);
            Assert.Contains(gladiator1, coloseum.AllFighters());
            Assert.DoesNotContain(gladiator2, coloseum.AllFighters());
            Assert.Contains(gladiator3, coloseum.AllFighters());
        }

        [Fact]
        public void CantRemoveANoneExistingGladiatorFromColseum()
        {
            //Arrange
            Coloseum coloseum;
            coloseum = new Coloseum();
            Gladiator gladiator1 = new Gladiator();
            Gladiator gladiator2 = new Gladiator();
            Gladiator gladiator3 = new Gladiator();
            coloseum.AddGladiator(gladiator1);
            coloseum.AddGladiator(gladiator2);
            coloseum.AddGladiator(gladiator3);

            //Act
            bool result = coloseum.RemoveGladiator(int.MaxValue);//using int max to mark a none existing Id.

            //Assert
            Assert.False(result);
            Assert.Contains(gladiator1, coloseum.AllFighters());
            Assert.Contains(gladiator2, coloseum.AllFighters());
            Assert.Contains(gladiator3, coloseum.AllFighters());
        }
    }
}
