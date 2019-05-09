﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TweetsieFileManager : IFileManager
    {
        private IFileFormatter formatter;
        private IFileParser parser;

        public TweetsieFileManager(IFileParser parser, IFileFormatter formatter)
        {
            this.parser = parser;
            this.formatter = formatter;
        }

        public List<EnemyCreateInfo> loadEnemyTypes()
        {
            List<EnemyCreateInfo> enemyCreateInfos = new List<EnemyCreateInfo>();
            ObjectList objList = parser.parseFile("Enemies");

            int healthColumn = objList.HeaderRow.IndexOf("Health");
            int strengthColumn = objList.HeaderRow.IndexOf("Strength");
            int nameColumn = objList.HeaderRow.IndexOf("Name");
            int foodColumn = objList.HeaderRow.IndexOf("Food");
            int scoreColumn = objList.HeaderRow.IndexOf("ScoreValue");

            foreach(List<string> enemy in objList.ObjectRows)
            {
                enemyCreateInfos.Add(new EnemyCreateInfo(enemy[nameColumn], int.Parse(enemy[healthColumn]), int.Parse(enemy[strengthColumn]),
                    int.Parse(enemy[foodColumn]), int.Parse(enemy[scoreColumn])));
            }
            return enemyCreateInfos;
        }

        public List<HunterJobInfo> loadHunterJobsInfos()
        {
            List<HunterJobInfo> jobInfos = new List<HunterJobInfo>();
            ObjectList objList = parser.parseFile("Job");

            int nameColumn = objList.HeaderRow.IndexOf("Name");
            int healthColumn = objList.HeaderRow.IndexOf("Health");
            int strengthColumn = objList.HeaderRow.IndexOf("Strength");
            int multColumn = objList.HeaderRow.IndexOf("ScoreMultiplier");
            int moneyColumn = objList.HeaderRow.IndexOf("StartingMoney");

            foreach(List<string> obj in objList.ObjectRows)
            {
                jobInfos.Add(new HunterJobInfo(
                       obj[nameColumn],
                       int.Parse(obj[healthColumn]),
                       int.Parse(obj[strengthColumn]),
                       double.Parse(obj[multColumn]),
                       int.Parse(obj[moneyColumn])
                    )
                );
            }
            return jobInfos;
        }

        public List<Location> loadLocations()
        {
            List<Location> locations = new List<Location>();
            ObjectList objList = parser.parseFile("Locations");
            //Location Distance    Stop? Breakchance     Next Second Next
            int nameColumn = objList.HeaderRow.IndexOf("Location");
            int distanceColumn = objList.HeaderRow.IndexOf("Distance");
            int stopColumn = objList.HeaderRow.IndexOf("Stop?");
            int breakColumn = objList.HeaderRow.IndexOf("BreakChance");
            int nextColumn = objList.HeaderRow.IndexOf("Next");
            int secondColumn = objList.HeaderRow.IndexOf("Distance");

            foreach(List<string> loc in objList.ObjectRows)
            {
                locations.Add(
                    new Location(
                        loc[nameColumn],
                        int.Parse(loc[distanceColumn]),
                        bool.Parse(loc[stopColumn]),
                        int.Parse(loc[breakColumn]),
                        int.Parse(loc[nextColumn]),
                        int.Parse(loc[secondColumn])
                        )
                    );
            }
            return locations;
        }

        public ScoreTable loadScoreTable()
        {
            List<Score> scores = new List<Score>();
            ObjectList objList = parser.parseFile("Scores");

            int nameColumn = objList.HeaderRow.IndexOf("Name");
            int valueColumn = objList.HeaderRow.IndexOf("Score");
            foreach(List<string> score in objList.ObjectRows)
            {
                scores.Add(new Score(score[nameColumn], int.Parse(score[valueColumn])));
            }
            ScoreTable table = new ScoreTable(scores);
            table.sort();
            return table;
        }

        public void saveScoreTable(ScoreTable scores)
        {
            ObjectList objList = new ObjectList();
            objList.HeaderRow.Add("Name");
            objList.HeaderRow.Add("Score");
            for(int i = 0; i < scores.Scores.Count; ++i)
            {
                objList.ObjectRows.Add(new List<string>());
                objList.ObjectRows[i].Add(scores.Scores[i].Name);
                objList.ObjectRows[i].Add(scores.Scores[i].Value.ToString());
            }

            formatter.saveFile(objList);
        }
    }
}