using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text;
using TheHermesEntities;
using Extentions;
using TheHermesEntities.Common;
using OfficeOpenXml;

namespace DbWorker
{
    public static class DbStatisticWorker
    {
        public static List<Education> GetEducations()
        {
            var path = @"C:\Git\pub-03-01.xlsx";
            List<Education> ListEducation = new List<Education>();
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(path)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;

                var sb = new StringBuilder(); //this is your data
                var counter = 0;
                var age = 0;
                var shift = 0;
                var populationType = 0;
                var sex = 0;
                var NameRegion = "";

                int check1,
                    check2,
                    check3,
                    check4,
                    check5,
                    check6,
                    check7,
                    check8,
                    check9,
                    check10,
                    check11,
                    check12,
                    check13,
                    check14,
                    check15,
                    check16;
                var flag = 0; //вносить или не вносить новый объект

                for (int rowNum = 340; rowNum <= totalRows; rowNum++) //select starting row here
                {
                    var row =
                        myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(
                            c => c.Value == null ? string.Empty : c.Value.ToString());

                    if (counter != 0)
                    {
                        if (counter == shift) //Возраст 15-17 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 0;
                            sex = 0;
                        }
                        if (counter == shift + 1) //Возраст 18-19 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 1;
                            sex = 0;
                        }
                        if (counter == shift + 2) //Возраст 20-24 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 2;
                            sex = 0;
                        }
                        if (counter == shift + 3) //Возраст 25-29 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 3;
                            sex = 0;
                        }
                        if (counter == shift + 4) //Возраст 30-34 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 4;
                            sex = 0;
                        }
                        if (counter == shift + 5) //Возраст 35-39 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 5;
                            sex = 0;
                        }
                        if (counter == shift + 6) //Возраст 40-44 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 6;
                            sex = 0;
                        }
                        if (counter == shift + 7) //Возраст 45-49 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 7;
                            sex = 0;
                        }
                        if (counter == shift + 8) //Возраст 50-54 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 8;
                            sex = 0;
                        }
                        if (counter == shift + 9) //Возраст 55-59 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 9;
                            sex = 0;
                        }
                        if (counter == shift + 10) //Возраст 60-64 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 10;
                            sex = 0;
                        }
                        if (counter == shift + 11) //Возраст 65-69 городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 11;
                            sex = 0;
                        }
                        if (counter == shift + 12) //Возраст 70 и более городское население мужчины.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 12;
                            sex = 0;
                        }
                        if (counter == shift + 14) //городское население мужчины трудоспособное население
                        {
                            flag = 1;
                            populationType = 1;
                            age = 13;
                            sex = 0;
                        }
                        if (counter == shift + 15) //городское население мужчины старше трудоспособного
                        {
                            flag = 1;
                            populationType = 1;
                            age = 14;
                            sex = 0;
                        }
                        if (counter == shift + 16) //городское население мужчины возраста 16 - 29 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 15;
                            sex = 0;
                        }

                        if (counter == shift + 19) //городское население женщины возраста 15 - 17 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 0;
                            sex = 1;
                        }
                        if (counter == shift + 20) //городское население женщины возраста 18 - 19 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 1;
                            sex = 1;
                        }
                        if (counter == shift + 21) //городское население женщины возраста 20 - 24 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 2;
                            sex = 1;
                        }
                        if (counter == shift + 22) //городское население женщины возраста 25 - 29 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 3;
                            sex = 1;
                        }
                        if (counter == shift + 23) //городское население женщины возраста 30 - 34 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 4;
                            sex = 1;
                        }
                        if (counter == shift + 24) //городское население женщины возраста 35 - 39 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 5;
                            sex = 1;
                        }
                        if (counter == shift + 25) //городское население женщины возраста 40 - 44 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 6;
                            sex = 1;
                        }
                        if (counter == shift + 26) //городское население женщины возраста 45 - 49 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 7;
                            sex = 1;
                        }
                        if (counter == shift + 27) //городское население женщины возраста 50 - 54 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 8;
                            sex = 1;
                        }
                        if (counter == shift + 28) //городское население женщины возраста 55 - 59 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 9;
                            sex = 1;
                        }
                        if (counter == shift + 29) //городское население женщины возраста 60 - 64 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 10;
                            sex = 1;
                        }
                        if (counter == shift + 30) //городское население женщины возраста 65 - 69 лет
                        {
                            flag = 1;
                            populationType = 1;
                            age = 11;
                            sex = 1;
                        }
                        if (counter == shift + 31) //городское население женщины возраста 70 лет и старше.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 12;
                            sex = 1;
                        }
                        if (counter == shift + 33) //городское население женщины возраста трудоспособного
                        {
                            flag = 1;
                            populationType = 1;
                            age = 13;
                            sex = 1;
                        }
                        if (counter == shift + 34) //городское население женщины возраста старше трудоспособного
                        {
                            flag = 1;
                            populationType = 1;
                            age = 14;
                            sex = 1;
                        }
                        if (counter == shift + 35) //городское население женщины возраста 16-29
                        {
                            flag = 1;
                            populationType = 1;
                            age = 15;
                            sex = 1;
                        }

                        if (shift == 81) //Если не город, то заполняем сельское население.
                        {
                            if (counter == shift + 35 + 23) //Возраст 15-17 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 0;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 24) //Возраст 18-19 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 1;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 25) //Возраст 20-24 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 2;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 26) //Возраст 25-29 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 3;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 27) //Возраст 30-34 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 4;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 28) //Возраст 35-39 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 5;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 29) //Возраст 40-44 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 6;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 30) //Возраст 45-49 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 7;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 31) //Возраст 50-54 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 8;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 32) //Возраст 55-59 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 9;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 33) //Возраст 60-64 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 10;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 34) //Возраст 65-69 сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 11;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 35) //Возраст 70 лет и больше сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 12;
                                sex = 0;
                            }

                            if (counter == shift + 35 + 37) //Возраст трудоспособный сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 13;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 38) //Возраст старше трудоспособного сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 14;
                                sex = 0;
                            }
                            if (counter == shift + 35 + 39) //Возраст 16-29 лет сельское население мужчины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 15;
                                sex = 0;
                            }

                            if (counter == shift + 35 + 42) //Возраст 15-17 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 0;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 43) //Возраст 18-19 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 1;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 44) //Возраст 20-24 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 2;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 45) //Возраст 25-29 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 3;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 46) //Возраст 30-34 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 4;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 47) //Возраст 35-39 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 5;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 48) //Возраст 40-44 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 6;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 49) //Возраст 45-49 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 7;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 50) //Возраст 50-54 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 8;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 51) //Возраст 55-59 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 9;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 52) //Возраст 60-64 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 10;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 53) //Возраст 65-69 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 11;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 54) //Возраст старше 70 сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 12;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 56) //Возраст трудоспособный сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 13;
                                sex = 1;
                            }
                            if (counter == shift + 35 + 57) //Возраст старше трудоспособного сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 14;
                                sex = 1;
                            }

                            if (counter == shift + 35 + 58) //Возраст 16-29 лет сельское население женщины.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 15;
                                sex = 1;
                            }
                        }

                        counter++;
                    }

                    if (row.ToList()[0].Contains("область") | row.ToList()[0].Contains("Москва") | row.ToList()[0].Contains("Республика") | row.ToList()[0].Contains("ономный") | row.ToList()[0].Contains("етербург") | row.ToList()[0].Contains("край") | row.ToList()[0].Contains("Чукотс") | row.ToList()[0].Contains("Севастополь"))
                    {
                        counter = 1;
                        shift = 81;

                        if (row.ToList()[0].Contains("Москва") | row.ToList()[0].Contains("етербург") | row.ToList()[0].Contains("Севастополь"))
                        {
                            shift = 23;
                        }

                        NameRegion = row.ToList()[0];

                    }

                    if (flag == 1) //нужно внести новый объект
                    {
                        int temp;
                        if (int.TryParse(row.ToList()[2], out temp))
                        {
                            check1 = Convert.ToInt32(row.ToList()[2]);
                        }
                        else
                        {
                            check1 = 0;
                        }
                        if (int.TryParse(row.ToList()[3], out temp))
                        {
                            check2 = Convert.ToInt32(row.ToList()[3]);
                        }
                        else
                        {
                            check2 = 0;
                        }
                        if (int.TryParse(row.ToList()[4], out temp))
                        {
                            check3 = Convert.ToInt32(row.ToList()[4]);
                        }
                        else
                        {
                            check3 = 0;
                        }
                        if (int.TryParse(row.ToList()[5], out temp))
                        {
                            check4 = Convert.ToInt32(row.ToList()[5]);
                        }
                        else
                        {
                            check4 = 0;
                        }
                        if (int.TryParse(row.ToList()[6], out temp))
                        {
                            check5 = Convert.ToInt32(row.ToList()[6]);
                        }
                        else
                        {
                            check5 = 0;
                        }
                        if (int.TryParse(row.ToList()[7], out temp))
                        {
                            check6 = Convert.ToInt32(row.ToList()[7]);
                        }
                        else
                        {
                            check6 = 0;
                        }
                        if (int.TryParse(row.ToList()[8], out temp))
                        {
                            check7 = Convert.ToInt32(row.ToList()[8]);
                        }
                        else
                        {
                            check7 = 0;
                        }
                        if (int.TryParse(row.ToList()[9], out temp))
                        {
                            check8 = Convert.ToInt32(row.ToList()[9]);
                        }
                        else
                        {
                            check8 = 0;
                        }
                        if (int.TryParse(row.ToList()[10], out temp))
                        {
                            check9 = Convert.ToInt32(row.ToList()[10]);
                        }
                        else
                        {
                            check9 = 0;
                        }
                        if (int.TryParse(row.ToList()[11], out temp))
                        {
                            check10 = Convert.ToInt32(row.ToList()[11]);
                        }
                        else
                        {
                            check10 = 0;
                        }
                        if (int.TryParse(row.ToList()[12], out temp))
                        {
                            check11 = Convert.ToInt32(row.ToList()[12]);
                        }
                        else
                        {
                            check11 = 0;
                        }
                        if (int.TryParse(row.ToList()[13], out temp))
                        {
                            check12 = Convert.ToInt32(row.ToList()[13]);
                        }
                        else
                        {
                            check12 = 0;
                        }
                        if (int.TryParse(row.ToList()[14], out temp))
                        {
                            check13 = Convert.ToInt32(row.ToList()[14]);
                        }
                        else
                        {
                            check13 = 0;
                        }
                        if (int.TryParse(row.ToList()[15], out temp))
                        {
                            check14 = Convert.ToInt32(row.ToList()[15]);
                        }
                        else
                        {
                            check14 = 0;
                        }
                        if (int.TryParse(row.ToList()[16], out temp))
                        {
                            check15 = Convert.ToInt32(row.ToList()[16]);
                        }
                        else
                        {
                            check15 = 0;
                        }
                        if (int.TryParse(row.ToList()[17], out temp))
                        {
                            check16 = Convert.ToInt32(row.ToList()[17]);
                        }
                        else
                        {
                            check16 = 0;
                        }

                        Education education = new Education()
                        {
                            Region = NameRegion,
                            PopulationType = populationType,
                            Sex = sex,
                            Age = age,
                            Total = check1,
                            Indicated = check2,
                            Postgraduate = check3,
                            Higher = check4,
                            Bachelor = check5,
                            Specialist = check6,
                            Master = check7,
                            IncompleteHigher = check8,
                            AverageProf = check9,
                            InitialProf = check10,
                            Average = check11,
                            TheMain = check12,
                            Initial = check13,
                            NotGeneralEducation = check14,
                            Illiterate = check15,
                            NotIndicated = check16
                        };

                        ListEducation.Add(education);
                        flag = 0;

                        if ((shift == 23) && (age == 15) && (sex == 1))
                            //Если город без сельского населения и завершили заполнение по женщинам, то заполняем нули по сельским жителям.
                        {
                            for (int iii = 0; iii < 16; iii++)
                            {
                                for (int iii2 = 0; iii2 < 2; iii2++)
                                {
                                    Education education1 = new Education()
                                    {
                                        Region = NameRegion,
                                        PopulationType = 0,
                                        Sex = iii2,
                                        Age = iii,
                                        Total = 0,
                                        Indicated = 0,
                                        Postgraduate = 0,
                                        Higher = 0,
                                        Bachelor = 0,
                                        Specialist = 0,
                                        Master = 0,
                                        IncompleteHigher = 0,
                                        AverageProf = 0,
                                        InitialProf = 0,
                                        Average = 0,
                                        TheMain = 0,
                                        Initial = 0,
                                        NotGeneralEducation = 0,
                                        Illiterate = 0,
                                        NotIndicated = 0
                                    };

                                    ListEducation.Add(education1);
                                }

                            }
                        }
                    }
                }
            }
            return ListEducation;
        }

        public static List<Population> GetPopulations()
        {
            var path = @"C:\Git\pub-01-04.xlsx";
            List<Population> ListRegion = new List<Population>();

            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(path)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row - 2;
                var totalColumns = myWorksheet.Dimension.End.Column;

                var sb = new StringBuilder(); //this is your data
                var check1 = 0;
                var check2 = 0;
                for (int rowNum = 1; rowNum <= totalRows; rowNum++) //select starting row here
                {
                    var el = new Population();

                    var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    if ((row.ToList()[1].Contains("область") | row.ToList()[1].Contains("Москва") | row.ToList()[1].Contains("Республика") || row.ToList()[1].Contains("етербург") | row.ToList()[1].Contains("край") | row.ToList()[1].Contains("Чукотский") | row.ToList()[1].Contains("Севастополь")) | row.ToList()[1].Contains("ономный"))
                    {

                        if (row.ToList()[9] == "-") { check1 = 0; } else { check1 = Convert.ToInt32(row.ToList()[9]); }
                        if (row.ToList()[10] == "-") { check2 = 0; } else { check2 = Convert.ToInt32(row.ToList()[10]); }

                        Population population = new Population()
                        {
                            Region = row.ToList()[1],
                            UrbanPopulationMen = Convert.ToInt32(row.ToList()[6]),
                            UrbanPopulationWomen = Convert.ToInt32(row.ToList()[7]),
                            RuralPopulationMen = check1,
                            RuralPopulationWomen = check2
                        };

                        ListRegion.Add(population);

                        //sb.AppendLine(string.Join(",", row));

                    }
                }
            }
            return ListRegion;
        }
        public static List<StateOfMarriage> GetStateOfMarriages()
        {
            var path = @"C:\Git\pub-02-05.xlsx";
            List<StateOfMarriage> ListStateOfMarriage = new List<StateOfMarriage>();

            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(path)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;

                var sb = new StringBuilder(); //this is your data
                var counter = 0;
                var age = 0;
                var shift = 0;
                var populationType = 0;
                var NameRegion = "";
                int check1, check2, check3, check4, check5, check6, check7, check8, check9, check10, check11, check12, check13, check14, check15, check16, check17, check18, check19, check20;
                var flag = 0;//вносить или не вносить новый объект

                for (int rowNum = 8; rowNum <= totalRows; rowNum++) //select starting row here
                {
                    var el = new StateOfMarriage();
                    var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());

                    if (counter != 0)
                    {
                        if (counter == shift)//Возраст 16-17 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 0;
                        }
                        if (counter == shift + 1)//Возраст 18-19 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 1;
                        }
                        if (counter == shift + 2)//Возраст 20-24 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 2;
                        }
                        if (counter == shift + 3)//Возраст 25-29 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 3;
                        }
                        if (counter == shift + 4)//Возраст 30-34 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 4;
                        }
                        if (counter == shift + 5)//Возраст 35-39 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 5;
                        }
                        if (counter == shift + 6)//Возраст 40-44 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 6;
                        }
                        if (counter == shift + 7)//Возраст 45-49 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 7;
                        }
                        if (counter == shift + 8)//Возраст 50-54 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 8;
                        }
                        if (counter == shift + 9)//Возраст 55-59 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 9;
                        }
                        if (counter == shift + 10)//Возраст 60-64 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 10;
                        }
                        if (counter == shift + 11)//Возраст 65-69 городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 11;
                        }
                        if (counter == shift + 12)//Возраст 70 и более городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 12;
                        }
                        if (counter == shift + 13)//Возраст не указан городское население.
                        {
                            flag = 1;
                            populationType = 1;
                            age = 13;
                        }

                        if (shift == 21)//Если не Москва и не Санкт-Петербург
                        {
                            if (counter == shift + 17)//Возраст 16-17 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 0;
                            }
                            if (counter == shift + 18)//Возраст 18-19 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 1;
                            }
                            if (counter == shift + 19)//Возраст 20-24 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 2;
                            }
                            if (counter == shift + 20)//Возраст 25-29 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 3;
                            }
                            if (counter == shift + 21)//Возраст 30-34 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 4;
                            }
                            if (counter == shift + 22)//Возраст 35-39 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 5;
                            }
                            if (counter == shift + 23)//Возраст 40-44 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 6;
                            }
                            if (counter == shift + 24)//Возраст 45-49 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 7;
                            }
                            if (counter == shift + 25)//Возраст 50-54 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 8;
                            }
                            if (counter == shift + 26)//Возраст 55-59 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 9;
                            }
                            if (counter == shift + 27)//Возраст 60-64 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 10;
                            }
                            if (counter == shift + 28)//Возраст 65-69 сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 11;
                            }
                            if (counter == shift + 29)//Возраст 70 и более сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 12;
                            }
                            if (counter == shift + 30)//Возраст не указан сельское население.
                            {
                                flag = 1;
                                populationType = 0;
                                age = 13;
                            }
                        }

                        if (flag == 1)//нужно внести новый объект
                        {
                            int temp;
                            if (int.TryParse(row.ToList()[2], out temp)) { check1 = Convert.ToInt32(row.ToList()[2]); } else { check1 = 0; }
                            if (int.TryParse(row.ToList()[3], out temp)) { check2 = Convert.ToInt32(row.ToList()[3]); } else { check2 = 0; }
                            if (int.TryParse(row.ToList()[4], out temp)) { check3 = Convert.ToInt32(row.ToList()[4]); } else { check3 = 0; }
                            if (int.TryParse(row.ToList()[5], out temp)) { check4 = Convert.ToInt32(row.ToList()[5]); } else { check4 = 0; }
                            if (int.TryParse(row.ToList()[6], out temp)) { check5 = Convert.ToInt32(row.ToList()[6]); } else { check5 = 0; }
                            if (int.TryParse(row.ToList()[7], out temp)) { check6 = Convert.ToInt32(row.ToList()[7]); } else { check6 = 0; }
                            if (int.TryParse(row.ToList()[8], out temp)) { check7 = Convert.ToInt32(row.ToList()[8]); } else { check7 = 0; }
                            if (int.TryParse(row.ToList()[9], out temp)) { check8 = Convert.ToInt32(row.ToList()[9]); } else { check8 = 0; }
                            if (int.TryParse(row.ToList()[10], out temp)) { check9 = Convert.ToInt32(row.ToList()[10]); } else { check9 = 0; }
                            if (int.TryParse(row.ToList()[11], out temp)) { check10 = Convert.ToInt32(row.ToList()[11]); } else { check10 = 0; }
                            if (int.TryParse(row.ToList()[12], out temp)) { check11 = Convert.ToInt32(row.ToList()[12]); } else { check11 = 0; }
                            if (int.TryParse(row.ToList()[13], out temp)) { check12 = Convert.ToInt32(row.ToList()[13]); } else { check12 = 0; }
                            if (int.TryParse(row.ToList()[14], out temp)) { check13 = Convert.ToInt32(row.ToList()[14]); } else { check13 = 0; }
                            if (int.TryParse(row.ToList()[15], out temp)) { check14 = Convert.ToInt32(row.ToList()[15]); } else { check14 = 0; }
                            if (int.TryParse(row.ToList()[16], out temp)) { check15 = Convert.ToInt32(row.ToList()[16]); } else { check15 = 0; }
                            if (int.TryParse(row.ToList()[17], out temp)) { check16 = Convert.ToInt32(row.ToList()[17]); } else { check16 = 0; }
                            if (int.TryParse(row.ToList()[18], out temp)) { check17 = Convert.ToInt32(row.ToList()[18]); } else { check17 = 0; }
                            if (int.TryParse(row.ToList()[19], out temp)) { check18 = Convert.ToInt32(row.ToList()[19]); } else { check18 = 0; }
                            if (int.TryParse(row.ToList()[20], out temp)) { check19 = Convert.ToInt32(row.ToList()[20]); } else { check19 = 0; }
                            if (int.TryParse(row.ToList()[21], out temp)) { check20 = Convert.ToInt32(row.ToList()[21]); } else { check20 = 0; }

                            /*
                            if (row.ToList()[3] == "-") { check2 = 0; } else { check2 = Convert.ToInt32(row.ToList()[3]); }
                            if (row.ToList()[4] == "-") { check3 = 0; } else { check3 = Convert.ToInt32(row.ToList()[4]); }
                            if (row.ToList()[5] == "-") { check4 = 0; } else { check4 = Convert.ToInt32(row.ToList()[5]); }
                            if (row.ToList()[6] == "-") { check5 = 0; } else { check5 = Convert.ToInt32(row.ToList()[6]); }
                            if (row.ToList()[7] == "-") { check6 = 0; } else { check6 = Convert.ToInt32(row.ToList()[7]); }
                            if (row.ToList()[8] == "-") { check7 = 0; } else { check7 = Convert.ToInt32(row.ToList()[8]); }
                            if (row.ToList()[9] == "-") { check8 = 0; } else { check8 = Convert.ToInt32(row.ToList()[9]); }
                            if (row.ToList()[10] == "-") { check9 = 0; } else { check9 = Convert.ToInt32(row.ToList()[10]); }
                            if (row.ToList()[11] == "-") { check10 = 0; } else { check10 = Convert.ToInt32(row.ToList()[11]); }
                            if (row.ToList()[12] == "-") { check11 = 0; } else { check11 = Convert.ToInt32(row.ToList()[12]); }
                            if (row.ToList()[13] == "-") { check12 = 0; } else { check12 = Convert.ToInt32(row.ToList()[13]); }
                            if (row.ToList()[14] == "-") { check13 = 0; } else { check13 = Convert.ToInt32(row.ToList()[14]); }
                            if (row.ToList()[15] == "-") { check14 = 0; } else { check14 = Convert.ToInt32(row.ToList()[15]); }
                            if (row.ToList()[16] == "-") { check15 = 0; } else { check15 = Convert.ToInt32(row.ToList()[16]); }
                            if (row.ToList()[17] == "-") { check16 = 0; } else { check16 = Convert.ToInt32(row.ToList()[17]); }
                            if (row.ToList()[18] == "-") { check17 = 0; } else { check17 = Convert.ToInt32(row.ToList()[18]); }
                            if (row.ToList()[19] == "-") { check18 = 0; } else { check18 = Convert.ToInt32(row.ToList()[19]); }
                            if (row.ToList()[20] == "-") { check19 = 0; } else { check19 = Convert.ToInt32(row.ToList()[20]); }
                            if (row.ToList()[21] == "-") { check20 = 0; } else { check20 = Convert.ToInt32(row.ToList()[21]); }
                            */
                            StateOfMarriage stateOfMarriage = new StateOfMarriage()
                            {
                                Region = NameRegion,
                                PopulationType = populationType,
                                Age = age,
                                Men = check1,
                                ReportingMen = check2,
                                MarriedMen = check3,
                                RegisteredMarriageMen = check4,
                                UnregisteredMarriageMen = check5,
                                UnmarriedMen = check6,
                                OfficiallyDivorcedMen = check7,
                                DispersedMen = check8,
                                WidowedMen = check9,
                                NotReportingMen = check10,
                                Women = check11,
                                ReportingWomen = check12,
                                MarriedWomen = check13,
                                RegisteredMarriageWomen = check14,
                                UnregisteredMarriageWomen = check15,
                                UnmarriedWomen = check16,
                                OfficiallyDivorcedWomen = check17,
                                DispersedWomen = check18,
                                WidowedWomen = check19,
                                NotReportingWomen = check20
                            };

                            ListStateOfMarriage.Add(stateOfMarriage);
                            flag = 0;

                            if ((age == 13) && (shift == 4))//Если города без сельского населения, то добавляем нули для позиций по сельчанам. И последнюю запись по городу сделали.
                            {
                                for (int iii = 0; iii < 14; iii++)
                                {
                                    StateOfMarriage stateOfMarriage1 = new StateOfMarriage()
                                    {
                                        Region = NameRegion,
                                        PopulationType = 0,
                                        Age = iii,
                                        Men = 0,
                                        ReportingMen = 0,
                                        MarriedMen = 0,
                                        RegisteredMarriageMen = 0,
                                        UnregisteredMarriageMen = 0,
                                        UnmarriedMen = 0,
                                        OfficiallyDivorcedMen = 0,
                                        DispersedMen = 0,
                                        WidowedMen = 0,
                                        NotReportingMen = 0,
                                        Women = 0,
                                        ReportingWomen = 0,
                                        MarriedWomen = 0,
                                        RegisteredMarriageWomen = 0,
                                        UnregisteredMarriageWomen = 0,
                                        UnmarriedWomen = 0,
                                        OfficiallyDivorcedWomen = 0,
                                        DispersedWomen = 0,
                                        WidowedWomen = 0,
                                        NotReportingWomen = 0
                                    };

                                    ListStateOfMarriage.Add(stateOfMarriage1);

                                }

                            }

                        }

                        counter++;
                    }

                    if (row.ToList()[1].Contains("область") | row.ToList()[1].Contains("Москва") | row.ToList()[1].Contains("Республика") | row.ToList()[1].Contains("Округ") | row.ToList()[1].Contains("г.Санкт-Петербург") | row.ToList()[1].Contains("край") | row.ToList()[1].Contains("Чукотский") | row.ToList()[1].Contains("Севастополь"))
                    {
                        counter = 1;
                        shift = 21;

                        if (row.ToList()[1].Contains("Москва") | row.ToList()[1].Contains("г.Санкт-Петербург") | row.ToList()[1].Contains("Севастополь"))
                        {
                            shift = 4;
                        }

                        NameRegion = row.ToList()[1];
                    }

                }

            }
            return ListStateOfMarriage;
        }

        public static List<MakeMoney> GetMakeMoney()
        {
            var path = @"C:\Git\pub-05-02.xlsx";
            List<MakeMoney> ListMakeMoney = new List<MakeMoney>();

            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(path)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;

                var sb = new StringBuilder(); //this is your data
                var counter = 0;
                var NameRegion = "";
                var sex = 0;
                var populationType = 0;
                var age = 0;
                var flag = 0;//вносить или не вносить новый объект
                int check1, check2, check3, check4, check5, check6, check7, check8, check9, check10, check11, check12, check13, check14, check15, check16, check17, check18, check19, check20;
                for (int rowNum = 7; rowNum <= totalRows; rowNum++) //select starting row here
                {
                    var el = new MakeMoney();
                    var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());

                    if (counter != 0)
                    {
                        if (counter == 25)//Мужщины из города моложе трудоспособного возраста
                        {
                            flag = 1;
                            sex = 0;
                            populationType = 1;
                            age = 0;
                        }
                        if (counter == 26)//Мужщины из города трудоспособного возраста
                        {
                            flag = 1;
                            sex = 0;
                            populationType = 1;
                            age = 1;
                        }
                        if (counter == 27)//Мужщины из города старше трудоспособного возраста
                        {
                            flag = 1;
                            sex = 0;
                            populationType = 1;
                            age = 2;
                        }
                        if (counter == 30)//Женщины из города моложе трудоспособного возраста
                        {
                            flag = 1;
                            sex = 1;
                            populationType = 1;
                            age = 0;
                        }
                        if (counter == 31)//Женщины из города трудоспособного возраста
                        {
                            flag = 1;
                            sex = 1;
                            populationType = 1;
                            age = 1;
                        }
                        if (counter == 32)//Женщины из города старше трудоспособного возраста
                        {
                            flag = 1;
                            sex = 1;
                            populationType = 1;
                            age = 2;
                        }
                        if (counter == 41)//Мужщины из села моложе трудоспособного возраста
                        {
                            flag = 1;
                            sex = 0;
                            populationType = 0;
                            age = 0;
                        }
                        if (counter == 42)//Мужщины из села трудоспособного возраста
                        {
                            flag = 1;
                            sex = 0;
                            populationType = 0;
                            age = 1;
                        }
                        if (counter == 43)//Мужщины из села старше трудоспособного возраста
                        {
                            flag = 1;
                            sex = 0;
                            populationType = 0;
                            age = 2;
                        }
                        if (counter == 46)//Женщины из села моложе трудоспособного возраста
                        {
                            flag = 1;
                            sex = 1;
                            populationType = 0;
                            age = 0;
                        }
                        if (counter == 47)//Женщины из села трудоспособного возраста
                        {
                            flag = 1;
                            sex = 1;
                            populationType = 0;
                            age = 1;
                        }
                        if (counter == 48)//Женщины из села старше трудоспособного возраста
                        {
                            flag = 1;
                            sex = 1;
                            populationType = 0;
                            age = 2;
                        }

                        if (flag == 1)//нужно внести новый объект
                        {
                            if (row.ToList()[2] == "-") { check1 = 0; } else { check1 = Convert.ToInt32(row.ToList()[2]); }
                            if (row.ToList()[3] == "-") { check2 = 0; } else { check2 = Convert.ToInt32(row.ToList()[3]); }
                            if (row.ToList()[4] == "-") { check3 = 0; } else { check3 = Convert.ToInt32(row.ToList()[4]); }
                            if (row.ToList()[5] == "-") { check4 = 0; } else { check4 = Convert.ToInt32(row.ToList()[5]); }
                            if (row.ToList()[6] == "-") { check5 = 0; } else { check5 = Convert.ToInt32(row.ToList()[6]); }
                            if (row.ToList()[7] == "-") { check6 = 0; } else { check6 = Convert.ToInt32(row.ToList()[7]); }
                            if (row.ToList()[8] == "-") { check7 = 0; } else { check7 = Convert.ToInt32(row.ToList()[8]); }
                            if (row.ToList()[9] == "-") { check8 = 0; } else { check8 = Convert.ToInt32(row.ToList()[9]); }
                            if (row.ToList()[10] == "-") { check9 = 0; } else { check9 = Convert.ToInt32(row.ToList()[10]); }
                            if (row.ToList()[11] == "-") { check10 = 0; } else { check10 = Convert.ToInt32(row.ToList()[11]); }
                            if (row.ToList()[12] == "-") { check11 = 0; } else { check11 = Convert.ToInt32(row.ToList()[12]); }
                            if (row.ToList()[13] == "-") { check12 = 0; } else { check12 = Convert.ToInt32(row.ToList()[13]); }
                            if (row.ToList()[14] == "-") { check13 = 0; } else { check13 = Convert.ToInt32(row.ToList()[14]); }
                            if (row.ToList()[15] == "-") { check14 = 0; } else { check14 = Convert.ToInt32(row.ToList()[15]); }
                            if (row.ToList()[16] == "-") { check15 = 0; } else { check15 = Convert.ToInt32(row.ToList()[16]); }
                            if (row.ToList()[17] == "-") { check16 = 0; } else { check16 = Convert.ToInt32(row.ToList()[17]); }
                            if (row.ToList()[18] == "-") { check17 = 0; } else { check17 = Convert.ToInt32(row.ToList()[18]); }
                            if (row.ToList()[19] == "-") { check18 = 0; } else { check18 = Convert.ToInt32(row.ToList()[19]); }
                            if (row.ToList()[20] == "-") { check19 = 0; } else { check19 = Convert.ToInt32(row.ToList()[20]); }
                            if (row.ToList()[21] == "-") { check20 = 0; } else { check20 = Convert.ToInt32(row.ToList()[21]); }
                            MakeMoney makemoney = new MakeMoney()
                            {
                                Region = NameRegion,
                                Sex = sex,
                                PopulationType = populationType,
                                Age = age,
                                AllPopulation = check1,
                                Reporting = check2,
                                AllReporting = check3,
                                LaborActivity = check4,
                                PersonalSubsidiaryPlots = check5,
                                Scholarship = check6,
                                Pension = check7,
                                DisabilityPension = check8,
                                Allowance = check9,
                                UnemploymentBenefits = check10,
                                StateSecurity = check11,
                                Dividends = check12,
                                Rent = check13,
                                Dependence = check14,
                                Other = check15,
                                NotSpecified = check16,
                                NumberOfSources1 = check17,
                                NumberOfSources2 = check18,
                                NumberOfSources3 = check19,
                                NumberOfSources4 = check20
                            };
                            ListMakeMoney.Add(makemoney);
                            flag = 0;
                        }


                        counter++;
                    }

                    if (row.ToList()[1].Contains("область") | row.ToList()[1].Contains("Москва") | row.ToList()[1].Contains("Республика") | row.ToList()[1].Contains("омный") | row.ToList()[1].Contains("етербург") | row.ToList()[1].Contains("край") | row.ToList()[1].Contains("Чукотский") | row.ToList()[1].Contains("Севастополь"))
                    {
                        counter = 1;
                        NameRegion = row.ToList()[1];
                    }



                    //     MakeMoney makemoney = new MakeMoney()
                    //      {
                    //         Region = row.ToList()[1],

                    //    };

                    //    ListMakeMoney.Add(makemoney);

                    //}
                }


            }
            return ListMakeMoney;
        }

        public static Dictionary<string, string> GetDictionary()
        {
            var d = new Dictionary<string, string>();
            d.Add("Белгородская область", "RU-BEL");
            d.Add("Брянская область", "RU-BRY");
            d.Add("Владимирская область", "RU-VLA");
            d.Add("Воронежская область", "RU-VOR");//
            d.Add("Ивановская область", "RU-IVA");
            d.Add("Калужская область", "RU-KLU");
            d.Add("Костромская область", "RU-KOS");
            d.Add("Курская область", "RU-KRS");
            d.Add("Липецкая область", "RU-LIP");
            d.Add("Московская область", "RU-MOS");
            d.Add("Орловская область", "RU-ORL");
            d.Add("Рязанская область", "RU-RYA");
            d.Add("Смоленская область", "RU-SMO");
            d.Add("Тамбовская область", "RU-TAM");
            d.Add("Тверская область", "RU-TVE");
            d.Add("Тульская область", "RU-TUL");
            d.Add("Ярославская область", "RU-YAR");
            d.Add("г. Москва", "RU-MOW");
            d.Add("Республика Карелия", "RU-KR");
            d.Add("Республика Коми", "RU-KO");
            d.Add("Архангельская область", "RU-ARK");
            d.Add("Вологодская область", "RU-VLG");
            d.Add("Калининградская область", "RU-KGD");
            d.Add("Ленинградская область", "RU-LEN");
            d.Add("Мурманская область", "RU-MUR");
            d.Add("Новгородская область", "RU-NGR");
            d.Add("Псковская область", "RU-PSK");
            d.Add("Республика Адыгея", "RU-AD");
            d.Add("Республика Калмыкия", "RU-KL");
            d.Add("Краснодарский край", "RU-KDA");
            d.Add("Астраханская область", "RU-AST");
            d.Add("Волгоградская область", "RU-VGG");
            d.Add("Ростовская область", "RU-ROS");
            d.Add("Республика Дагестан", "RU-DA");
            d.Add("Республика Ингушетия", "RU-IN");
            d.Add("Кабардино-Балкарская Республика", "RU-KB");
            d.Add("Карачаево-Черкесская Республика", "RU-KC");
            d.Add("Республика Северная Осетия – Алания", "RU-SE");
            d.Add("Чеченская Республика", "RU-CE");
            d.Add("Ставропольский край", "RU-STA");
            d.Add("Республика Башкортостан", "RU-BA");
            d.Add("Республика Марий Эл", "RU-ME");
            d.Add("Республика Мордовия", "RU-MO");
            d.Add("Республика Татарстан", "RU-TA");
            d.Add("Удмуртская Республика", "RU-UD");
            d.Add("Чувашская Республика", "RU-CU");
            d.Add("Пермский край", "RU-PER");
            d.Add("Кировская область", "RU-KIR");
            d.Add("Нижегородская область", "RU-NIZ");
            d.Add("Оренбургская область", "RU-ORE");
            d.Add("Пензенская область", "RU-PNZ");
            d.Add("Самарская область", "RU-SAM");
            d.Add("Саратовская область", "RU-SAR");
            d.Add("Ульяновская область", "RU-ULY");
            d.Add("Курганская область", "RU-KGN");
            d.Add("Свердловская область", "RU-SVE");
            d.Add("Тюменская область", "RU-TYU");
            d.Add("Челябинская область", "RU-CHE");
            d.Add("Республика Алтай", "RU-AL");
            d.Add("Республика Бурятия", "RU-BU");
            d.Add("Республика Тыва", "RU-TY");
            d.Add("Республика Хакасия", "RU-KK");
            d.Add("Алтайский край", "RU-ALT");
            d.Add("Забайкальский край", "RU-ZAB");
            d.Add("Красноярский край", "RU-KYA");
            d.Add("Иркутская область", "RU-IRK");
            d.Add("Кемеровская область", "RU-KEM");
            d.Add("Новосибирская область", "RU-NVS");
            d.Add("Омская область", "RU-OMS");
            d.Add("Томская область", "RU-TOM");
            d.Add("Республика Саха (Якутия)", "RU-SA");
            d.Add("Камчатский край", "RU-KAM");
            d.Add("Приморский край", "RU-PRI");
            d.Add("Хабаровский край", "RU-KHA");
            d.Add("Амурская область", "RU-AMU");
            d.Add("Магаданская область", "RU-MAG");
            d.Add("Сахалинская область", "RU-SAK");
            d.Add("Еврейская автономная область", "RU-YEV");
            d.Add("Чукотский автономный округ", "RU-CHU");
            d.Add("Ханты-Мансийский автономный округ – Югра", "RU-KHM");
            d.Add("Ямало-Ненецкий \nавтономный округ", "RU-NEN");
            d.Add("Ненецкий автономный округ", "RU-NEN");
            d.Add("Ямало-Ненецкий автономный округ", "RU-NEN");
            d.Add("Ханты-Мансийский автономный округ - Югра", "RU-KHM");
            d.Add("г. Санкт-Петербург", "RU-SPE");

            return d;
        }
    }
}