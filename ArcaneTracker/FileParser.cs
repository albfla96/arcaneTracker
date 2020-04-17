using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ArcaneTracker
{
    class FileParser
    {
        public void RandomName()
        {
            Arcane arcane = new Arcane();
            
            StreamReader reader = File.OpenText("C:\\Users\\Flavius\\Desktop\\arcaneTracker\\arcanes.txt");
            string line;
            while((line = reader.ReadLine()) != null)
            {
                Regex regex = new Regex(@"\s+-+\s");
                
                string[] items = regex.Split(line);
                arcane.Name = items[0];
                //Console.WriteLine(arcane.Name);
                //Console.WriteLine(items[1]);
                //Console.WriteLine(arcane.Rank);

                Regex rankRegex = new Regex(@"\[?[\/]");


                if (items[1].Contains('+'))
                {
                    arcane.isMaxRank = true;
                    arcane.Rank = arcane.MaxRank;
                    Regex surplusArcanesRegex = new Regex(@"\s\[?[+]\s");
                    string[] surplus = surplusArcanesRegex.Split(items[1]);
                    arcane.SurplusArcanes = Convert.ToInt32(surplus[1]);
                    //Console.WriteLine(arcane.SurplusArcanes);
                    //Console.WriteLine(surplus[0]);
                    string[] arcaneRank = rankRegex.Split(surplus[0]);
                    arcane.MaxRank = Convert.ToInt32(arcaneRank[1]);
                    //Console.WriteLine(arcane.MaxRank);
                }
                else if (items[1].Contains('(') && items[1].Contains(')'))
                {
                    //Regex notMaxRankRegex = new Regex(@"\[?[\(]\d[?[\/]\d[?[\)]");
                    Regex notMaxRankRegex = new Regex(@"[?[([^)]");
                    string[] notMaxRankedArcanes = notMaxRankRegex.Split(items[1]);
                    //Console.WriteLine(notMaxRankedArcanes[0]);
                    string[] arcaneRank = rankRegex.Split(notMaxRankedArcanes[0]);
                    arcane.Rank = Convert.ToInt32(arcaneRank[0]);
                    arcane.MaxRank = Convert.ToInt32(arcaneRank[1]);

                    string[] requiredArcanes = rankRegex.Split(notMaxRankedArcanes[1]);
                    arcane.ArcanesRequiredToReachMaxRank = Convert.ToInt32(requiredArcanes[1]);
                    arcane.Rank0OwnedArcanes = Convert.ToInt32(requiredArcanes[0]);

                    //Console.WriteLine(arcane.Rank0OwnedArcanes + "//" + arcane.ArcanesRequiredToReachMaxRank);

                    
                    


                }



                Console.ReadLine();
            }
        }
    }
}
