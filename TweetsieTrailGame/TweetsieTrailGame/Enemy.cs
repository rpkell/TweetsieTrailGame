﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class Enemy: Combatant
    {
        private int foodAmount;
        private int scoreValue;

        public Enemy(int health, int strength, string name, int foodAmount, int scoreValue) : base(health, strength, name)
        {
            this.foodAmount = foodAmount;
            this.scoreValue = scoreValue;
        }

        public Enemy(EnemyCreateInfo info): base(info.Health, info.Strength, info.Name)
        {
            foodAmount = info.FoodAmount;
            scoreValue = info.ScoreValue;
        }

        public int FoodAmount
        {
            get
            {
                return foodAmount;
            }
        }

        public int ScoreValue
        {
            get
            {
                return scoreValue;
            }
        }
    }
}
