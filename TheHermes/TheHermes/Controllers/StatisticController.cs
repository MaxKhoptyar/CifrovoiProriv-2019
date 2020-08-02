using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheHermes.Models;
using TheHermesEntities;

namespace TheHermes.Controllers
{
    public class Population2 : Population
    {
        public double Share { get; set; }
        public int Color { get; set; }
        public double ShareWoman { get; set; }
    }
    public class Region
    {
        public string Name { get; set; }
        public int Hight { get; set; }
        public double Share { get; set; }
        public int Color { get; set; }
    }
    public class MakeMoney2 : MakeMoney
    {
        public double Share1 { get; set; }//доля работающего населения
        public double Share2 { get; set; }//доля людей, получающего доход от аренды
        public int All { get; set; }//все население

        public int Color1 { get; set; } //цветовая метка для трудящихся.

        public int Color2 { get; set; }//цветовая метка для сдащих
    }
    public class StatisticController : Controller
    {
        // GET: Statistic
        public ActionResult Index(string mapNumber)
        {
            if (mapNumber == null | mapNumber == "1")
            {

                var ListRegion = LocalStorage.Population;
                var summ = 0;

                foreach (Population item in ListRegion)
                {
                    summ += item.UrbanPopulationMen + item.UrbanPopulationWomen + item.RuralPopulationMen + item.RuralPopulationWomen;
                }

                List<Population2> ListRegion2 = new List<Population2>();

                foreach (Population item in ListRegion)
                {
                    if (!LocalStorage.DictionaryRegions.ContainsKey(item.Region))
                    {
                        continue;
                    }
                    var summ_reg = (double)item.UrbanPopulationMen + item.UrbanPopulationWomen + item.RuralPopulationMen + item.RuralPopulationWomen;
                    Population2 Region2 = new Population2()
                    {
                        Region = LocalStorage.DictionaryRegions[item.Region],
                        UrbanPopulationMen = item.UrbanPopulationMen,
                        UrbanPopulationWomen = item.UrbanPopulationWomen,
                        RuralPopulationMen = item.RuralPopulationMen,
                        RuralPopulationWomen = item.RuralPopulationWomen,
                        Share = summ_reg / summ * 10,
                        ShareWoman = (item.UrbanPopulationWomen + item.RuralPopulationWomen) / summ_reg
                    };

                    ListRegion2.Add(Region2);

                }

                var ListRegion3 = ListRegion2.OrderBy(item => item.Share);//распределение по численности населения и цветовые метки.
                var Counter = 1;
                foreach (Population2 item in ListRegion3)
                {
                    if (Counter < 8) { item.Color = 1; }
                    if ((Counter > 7) && (Counter < 15)) { item.Color = 2; }
                    if ((Counter > 14) && (Counter < 22)) { item.Color = 3; }
                    if ((Counter > 21) && (Counter < 29)) { item.Color = 4; }
                    if ((Counter > 28) && (Counter < 36)) { item.Color = 5; }
                    if ((Counter > 35) && (Counter < 43)) { item.Color = 6; }
                    if ((Counter > 42) && (Counter < 50)) { item.Color = 7; }
                    if ((Counter > 49) && (Counter < 57)) { item.Color = 8; }
                    if ((Counter > 56) && (Counter < 64)) { item.Color = 9; }
                    if (Counter > 63) { item.Color = 10; }

                    Counter++;
                }
                var m = new MapModel();
                m.KeyValues = new List<KeyValue>();
                foreach (var lr in ListRegion3)
                {
                    m.KeyValues.Add(new KeyValue() { Key = lr.Region, Value = lr.Color.ToString() });
                }
                return View(m);
            }
            if (mapNumber == "2")//kachesstvo obr
            {
                var ListEducation = LocalStorage.Education;

                List<Region> Regions = new List<Region>();

                var RRRR = ListEducation.GroupBy(item => item.Region);

                foreach (var group in RRRR)
                {
                    var first = group.First();
                    var summ1 = group.Sum(item => item.Higher);//сумма людей с высшим образованием
                    var summ2 = (double)group.Sum(item => item.Total);//сумма людей всего по региону

                    if (!LocalStorage.DictionaryRegions.ContainsKey(first.Region))
                    {
                        continue;
                    }

                    Region region = new Region()
                    {
                        Name = LocalStorage.DictionaryRegions[first.Region],
                        Hight = summ1,
                        Share = summ1 / summ2
                    };

                    Regions.Add(region);
                }

                var Regions2 = Regions.OrderBy(item => item.Share);

                var Counter = 0;

                foreach (Region item in Regions2)
                {
                    if (Counter < 9) { item.Color = 1; }
                    if ((Counter > 8) && (Counter < 17)) { item.Color = 2; }
                    if ((Counter > 16) && (Counter < 26)) { item.Color = 3; }
                    if ((Counter > 25) && (Counter < 35)) { item.Color = 4; }
                    if ((Counter > 34) && (Counter < 44)) { item.Color = 5; }
                    if ((Counter > 43) && (Counter < 53)) { item.Color = 6; }
                    if ((Counter > 52) && (Counter < 62)) { item.Color = 7; }
                    if ((Counter > 61) && (Counter < 71)) { item.Color = 8; }
                    if ((Counter > 70) && (Counter < 80)) { item.Color = 9; }
                    if (Counter > 79) { item.Color = 10; }
                    Counter++;
                }
                var m = new MapModel();
                m.KeyValues = new List<KeyValue>();
                foreach (var lr in Regions2)
                {
                    m.KeyValues.Add(new KeyValue() { Key = lr.Name, Value = lr.Color.ToString() });
                }
                return View(m);
            }
            if (mapNumber == "3")//procent predrinimat
            {

            }
            if (mapNumber == "4")//zhenskaya dolya
            {

            }
            if (mapNumber == "5")// doly trudoustroennih
            {
                var ListMakeMoney = LocalStorage.MakeMoney;
                List<MakeMoney2> Rusalts = new List<MakeMoney2>();
                var RRRR = ListMakeMoney.GroupBy(item => item.Region);

                foreach (var group in RRRR)
                {
                    var first = group.First();
                    var summ1 = (double)group.Sum(item => item.LaborActivity);//сумма людей трудящихся
                    var summ2 = (double)group.Sum(item => item.Rent);//сумма людей имеющих доходы от сдачи в наем
                    var summ3 = group.Sum(item => item.AllPopulation);//сумма людей всего по региону

                    if (!LocalStorage.DictionaryRegions.ContainsKey(first.Region))
                    {
                        continue;
                    }
                    MakeMoney2 makeMoney2 = new MakeMoney2()
                    {
                        Region = LocalStorage.DictionaryRegions[first.Region],
                        All = summ3,
                        Share1 = summ1 / summ3,
                        Share2 = summ2 / summ3,
                    };

                    Rusalts.Add(makeMoney2);
                }

                var Results2 = Rusalts.OrderBy(item => item.Share1);//упорядоченный список объектов с трудящимися (долей).
                var Results3 = Rusalts.OrderBy(item => item.Share2);//упорядоченный список со сдающими (доля).

                var Counter = 0;
                foreach (var item in Results2)
                {
                    //Console.WriteLine(item.Region);


                    if (Counter < 9) { item.Color1 = 1; }
                    else if ((Counter > 8) && (Counter < 17)) { item.Color1 = 2; }
                    else if ((Counter > 16) && (Counter < 25)) { item.Color1 = 3; }
                    else if ((Counter > 24) && (Counter < 33)) { item.Color1 = 4; }
                    else if ((Counter > 32) && (Counter < 41)) { item.Color1 = 5; }
                    else if ((Counter > 40) && (Counter < 49)) { item.Color1 = 6; }
                    else if ((Counter > 48) && (Counter < 57)) { item.Color1 = 7; }
                    else if ((Counter > 56) && (Counter < 64)) { item.Color1 = 8; }
                    else if ((Counter > 63) && (Counter < 72)) { item.Color1 = 9; }
                    else if (Counter > 71) { item.Color1 = 10; }
                    Counter++;
                }
                Counter = 0;
                var m = new MapModel();
                m.KeyValues = new List<KeyValue>();
                foreach (var lr in Results2)
                {
                    m.KeyValues.Add(new KeyValue() { Key = lr.Region, Value = lr.Color1.ToString() });
                }
                return View(m);
            }
            if (mapNumber == "6")//zhenskaya dolya
            {
                var ListMakeMoney = LocalStorage.MakeMoney;
                List<MakeMoney2> Rusalts = new List<MakeMoney2>();
                var RRRR = ListMakeMoney.GroupBy(item => item.Region);

                foreach (var group in RRRR)
                {
                    var first = group.First();
                    var summ1 = (double)group.Sum(item => item.LaborActivity);//сумма людей трудящихся
                    var summ2 = (double)group.Sum(item => item.Rent);//сумма людей имеющих доходы от сдачи в наем
                    var summ3 = group.Sum(item => item.AllPopulation);//сумма людей всего по региону
                    if (!LocalStorage.DictionaryRegions.ContainsKey(first.Region))
                    {
                        continue;
                    }
                    MakeMoney2 makeMoney2 = new MakeMoney2()
                    {
                        Region = LocalStorage.DictionaryRegions[first.Region],
                        All = summ3,
                        Share1 = summ1 / summ3,
                        Share2 = summ2 / summ3,
                    };
                    Rusalts.Add(makeMoney2);
                }

                //var Results2 = Rusalts.OrderBy(item => item.Share1);//упорядоченный список объектов с трудящимися (долей).
                var Results3 = Rusalts.OrderBy(item => item.Share2);//упорядоченный список со сдающими (доля).
                var Counter = 0;

                foreach (var item in Results3)
                {
                    //Console.WriteLine(item.Region);


                    if (Counter < 9) { item.Color2 = 1; }
                    else if ((Counter > 8) && (Counter < 17)) { item.Color2 = 2; }
                    else if ((Counter > 16) && (Counter < 25)) { item.Color2 = 3; }
                    else if ((Counter > 24) && (Counter < 33)) { item.Color2 = 4; }
                    else if ((Counter > 32) && (Counter < 41)) { item.Color2 = 5; }
                    else if ((Counter > 40) && (Counter < 49)) { item.Color2 = 6; }
                    else if ((Counter > 48) && (Counter < 57)) { item.Color2 = 7; }
                    else if ((Counter > 56) && (Counter < 64)) { item.Color2 = 8; }
                    else if ((Counter > 63) && (Counter < 72)) { item.Color2 = 9; }
                    else if (Counter > 71) { item.Color2 = 10; }
                    Counter++;
                }

                var m = new MapModel();
                m.KeyValues = new List<KeyValue>();
                foreach (var lr in Results3)
                {
                    m.KeyValues.Add(new KeyValue() { Key = lr.Region, Value = lr.Color2.ToString() });
                }
                return View(m);
            }
            return View();
        }

        public ActionResult Region(string regionNumber)
        {
            var n = "";
            foreach (var region in LocalStorage.DictionaryRegions)
            {
                if (region.Value == regionNumber)
                {
                    n = region.Key;
                    break;
                }
            }

            var m = new RegionModel();
            m.Name = n;
            return View(m);
        }
        public ActionResult RealTime()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

    }
}