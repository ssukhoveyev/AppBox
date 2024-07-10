using AppBox.JKOMachines.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.ECADMachines.Entities
{
    public class EcadConverter
    {
        public CadData ConvertToCadData(string fileContent)
        {
            CadData cadData = new CadData();

            Whip whip = null;
            Beem beem = null;

            string[] s = fileContent.Split('\n');
            foreach (string s2 in s)
            {
                if (s2.Length > 3 && s2.Substring(0, 3) == "KSN") //KSN - Начало балки
                {
                    if(whip != null)
                        cadData.whips.Add(whip);
                    whip = new Whip();

                    whip.Id = Convert.ToInt32(s2.Substring(3, 3));
                    whip.Marking = s2.Substring(13, 13);
                    whip.Lenght = Convert.ToInt32(s2.Substring(7, 5)) / 10;
                    whip.Color = s2.Substring(26, 21);
                }

                if(whip != null && s2.Length > 3)//KTN - Начало хлыста
                {
                    if(s2.Substring(0, 3) == "KTN")
                    {
                        if (beem != null)
                            whip.Beems.Add(beem);
                        beem = new Beem();

                        beem.Id = Convert.ToInt32(s2.Substring(3, 4));
                        beem.Lenght = Convert.ToInt32(s2.Substring(76, 5)) / 10;
                        beem.angle1 = Convert.ToInt32(s2.Substring(82, 4)) / 10;
                        beem.angle2 = Convert.ToInt32(s2.Substring(86, 4)) / 10;
                        beem.Barcode = s2.Substring(97, 11);
                    }
                }

                if(beem != null && !String.IsNullOrEmpty(s2))
                {
                    if (s2.Substring(0, 1) == "W")
                    {
                        Operation operation = new Operation();
 
                        string[] opSplit = s2.Split('/');

                        operation.code = opSplit[0].Trim('W');
                        operation.CoordX = double.Parse(opSplit[2]) / 10;

                        beem.operations.Add(operation);
                    }
                }

                
                
                //W - Обработка
                //S - Данные об армировании
                //KRL - Остаток
            }

            return cadData;
        }
    }
}
