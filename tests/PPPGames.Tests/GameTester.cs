using FluentAssertions;
using PPPGames.Helpers;
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
            var perceval = new Knight(100, new BasicStuff(), new SnakeFightSkill())
            {
                Name = "Perceval",
                Alive = true,
                PointsOfLife = 100
            };
            var arthur = new Knight(10000, new EpicStuff(), new SnakeFightSkill())
            {
                Name = "Arthur",
                Alive = true,
                PointsOfLife = 75
            };

            arthur.Hit(perceval);

            perceval.Alive.Should().BeTrue();
        }

        [Fact]
        public void Arthur_Should_Kill_Perceval_In_TwoHist()
        {
            var perceval = new Knight(100, new BasicStuff(), new SnakeFightSkill())
            {
                Name = "Perceval",
                Alive = true,
                PointsOfLife = 100
            };
            var arthur = new Knight(10000, new EpicStuff(), new SnakeFightSkill())
            {
                Name = "Arthur",
                Alive = true,
                PointsOfLife = 75
            };

            arthur.Hit(perceval);
            arthur.Hit(perceval);

            perceval.Alive.Should().BeFalse();

        }
    }
}
