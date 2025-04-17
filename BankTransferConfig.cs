using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace mod8_103022300162{
 
internal class Program
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public string[] method { get; set; }
        public Confirmation confirmation { get; set; }

        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
            
            public Transfer()
                {

                }

            public Transfer(int threshold, int low_fee, int high_fee)
            {
                this.threshold = threshold;
                this.low_fee = low_fee;
                this.high_fee = high_fee;
            }
        }

        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }

            public Confirmation(string en, string id)
            {
                this.en = en;
                this.id = id;
            }
        }
            public BankTransferConfig()
            {

            }

        public BankTransferConfig(string lang, Transfer transfer, string[] method, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.method = method;
            this.confirmation = confirmation;
        }

            public BankTransferConfig config;
            public const String filePath = @"bank_transfer_config.json";
            public BankTransferConfig ReadConfigFile(string path)
            {
                String configJsonData = File.ReadAllText(filePath);
                config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
                return config;
            }

            public void WriteNewConfigFile(string path, BankTransferConfig config)
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
                String jsonString = JsonSerializer.Serialize(config, options);
                File.WriteAllText(path, jsonString);
            }
            public void setDefault()
            {
                config = new BankTransferConfig();
                config.lang = "en";
                Transfer transfer = new Transfer(2500000, 6000, 15000);
                config.transfer = transfer;
                List<string> isi = new List<string>();
                isi.Add("RTO");
                isi.Add("(real-time)");
                isi.Add("SKN");
                isi.Add("RTGS");
                isi.Add("BI");
                isi.Add("FAST");
                config.method = method;
                Confirmation confirmation = new Confirmation("yes", "ya");
                config.confirmation = confirmation;

            }
        }

    public class UIConfig
    {
        //ublic BankTransferConfig config;
        //public const String filePath = @"bank_transfer_config.json";
        //public BankTransferConfig ReadConfigFile(string path)
        //{
        //    String configJsonData = File.ReadAllText(filePath);
        //    config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
        //    return config;
        //}

        //public void WriteNewConfigFile(string path, BankTransferConfig config)
        //{
        //    JsonSerializerOptions options = new JsonSerializerOptions()
        //    {
        //        WriteIndented = true
        //    };
        //    String jsonString = JsonSerializer.Serialize(config, options);
        //    File.WriteAllText(path, jsonString);
        //}
        //public void setDefault()
        //{
        //    config = new BankTransferConfig();
        //    config.lang = "en";
        //    Transfer transfer = new Transfer();
        //}p
    }
    

   
}

}