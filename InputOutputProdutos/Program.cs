using System;
using System.Collections.Generic;
using System.IO;
using InputOutputProdutos.Entities;
using System.Globalization;

namespace InputOutputProdutos {
    class Program {
        static void Main(string[] args) {

            string SourcePath = @"C:\Temp\arquivo.csv";

            List<TotalProduct> list = new List<TotalProduct>();
            try {
                using (StreamReader sr = File.OpenText(SourcePath)) { //leitura do arquivo
                    while (!sr.EndOfStream) {
                        string [] line = sr.ReadLine().Split(',');
                        string NameProduct = line[0];
                        double Price = double.Parse(line[1],CultureInfo.InvariantCulture);
                        int Quant = int.Parse(line[2]);
                        list.Add(new TotalProduct(NameProduct, (Price * Quant)));
                    }
                }

                Directory.CreateDirectory(Path.GetDirectoryName(SourcePath)+@"\out"); //criacao da pasta
                string TargetPath = @"C:\Temp\out\summary.csv";

                using (StreamWriter sw = File.AppendText(TargetPath)) { // gravacao do arquivo
                    foreach(TotalProduct obj in list) {
                        sw.WriteLine(obj.Product + "," + obj.TotalPrice.ToString("F2",CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e) {
                Console.WriteLine("An error Ocurred: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
