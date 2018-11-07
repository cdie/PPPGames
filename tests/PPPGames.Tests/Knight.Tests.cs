using FluentAssertions;
using Moq;
using PPPGames.Models;
using PPPGames.Models.Abstractions;
using PPPGames.Models.FightSkills;
using PPPGames.Models.Stuff;
using System;
using Xunit;

namespace PPPGames.Tests
{
    public class GameTester
    {
        [Fact]
        public void Arthur_Shouldnt_Kill_Perceval_In_OneHit()
        {
            var perceval = new Knight(
                    new KnightState("Perceval", 100, 100),
                    new BasicStuff(),
                    new SnakeFightSkill());
            var arthur = new Knight(
                    new KnightState("Arthur", 10000, 75),
                    new EpicStuff(),
                    new SnakeFightSkill());

            arthur.Hit(perceval);

            perceval.GetKnightState().Alive.Should().BeTrue();
        }

        [Fact]
        public void Arthur_Should_Kill_Perceval_In_TwoHist()
        {
            var perceval = new Knight(
                    new KnightState("Perceval", 100, 100),
                    new BasicStuff(),
                    new SnakeFightSkill());
            var arthur = new Knight(
                    new KnightState("Arthur", 10000, 75),
                    new EpicStuff(),
                    new SnakeFightSkill());

            arthur.Hit(perceval);
            arthur.Hit(perceval);

            perceval.GetKnightState().Alive.Should().BeFalse();

        }

        [Fact]
        public void Arthur_Should_Be_Able_To_Kill_Perceval_If_He_Has_InvincibleFightSkill()
        {

            var invincibleFightSkillMoq = new Mock<IFightSkill>();
            invincibleFightSkillMoq.Setup(m => m.GetDamageReducer())
                .Returns(int.MaxValue);

            var perceval = new Knight(
                    new KnightState("Perceval", 100, 100),
                    new BasicStuff(),
                    invincibleFightSkillMoq.Object);
            var arthur = new Knight(
                    new KnightState("Arthur", 10000, 75),
                    new EpicStuff(),
                    new SnakeFightSkill());

            for (int i = 0; i < 100; i++)
            {
                arthur.Hit(perceval);
            }

            perceval.GetKnightState().Alive.Should().BeTrue();
            perceval.GetKnightState().PointsOfLife.Should().Be(100);
        }
    }
}
