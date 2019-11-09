using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_string_Deal
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "ips.txt";
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            var listIps = new List<String>();
            Int32 last=0;
            Boolean flag = false;
            var ipstart = "";
            while ((line = sr.ReadLine()) != null)
            {
                var newline = line.ToString();
                var newlast = Convert.ToInt32(line.Split('.')[3]);
                
                if (newlast == last +1)
                {
                    last = newlast;
                    flag = true;
                }
                else
                {
                    if (flag)
                    {
                        var iprange = ipstart + "-" + last;
                        Console.WriteLine(iprange);
                        listIps.Add(iprange);
                        last = newlast;
                        ipstart = newline;
                        flag = false;
                    }
                    else
                    {

                        var iprange = ipstart;
                        Console.WriteLine(iprange);
                        listIps.Add(iprange);
                        last = newlast;
                        ipstart = newline;
                    }


                }
                
            }


            Console.ReadLine();
        }
    }
}
