using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using System.Text.Json;

namespace sem2_lab2
{
   
    class Worker
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int rate { get; set; }
        public int days_count { get; set; }


        public Worker()
        {
            this.name = "Unknown";
            this.surname = "Unknown";
            this.rate = 0;
            this.days_count = 0;

        }
        public Worker(string name, string surname, int rate, int days_count)
        {
            this.name = name;
            this.surname = surname;
            this.rate = rate;
            this.days_count = days_count;

        } 
    public void Salary()
        {
            Console.Write(this.name + "\t");
            Console.Write(this.surname + "\n");
            Console.WriteLine($"Salary = {this.rate*this.days_count}");
        }
    }



    class Program
    {
        static void Serialize(ref string json)
        {
            try
            {
                string path = "lab2.json";
                File.WriteAllText(path, json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        static Worker Deserialize(ref string json)
        {
            var De_vr1 = new Worker();
            try
            {
                string path = "lab2.json";
                string des = File.ReadAllText(path, Encoding.UTF8);
                 De_vr1 = JsonConvert.DeserializeObject<Worker>(des);
               // Console.WriteLine(De_vr1.name);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

            }
            return De_vr1;

        }
        static void Main(string[] args)
        {
            var wr1 = new Worker("name","surname",3,5);

            wr1.Salary();
            string json = JsonConvert.SerializeObject(wr1);
           Console.WriteLine(json);
            Console.WriteLine("");

            // Serialize(ref json);
            Worker worker = Deserialize(ref json);
            Console.WriteLine(worker.name);
        }

    }
}
