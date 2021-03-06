﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Task1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //var websiteUrl = args.Length > 0 ? args[0] : throw new ArgumentNullException();
            string websiteUrl = "https://www.pja.edu.pl/rekrutacja-na-studia";

            var x = websiteUrl ?? throw new ArgumentException("url cannot be null");

            if (websiteUrl == null)
            {
                throw new ArgumentException("url cannot be null");
            }

            try
            {
                var httpClient = new HttpClient();
                //fetch data from website
                var responce = await httpClient.GetAsync(websiteUrl); // keyword which shows if wee need to 
                if (responce.IsSuccessStatusCode)
                {
                    var htmlContent = await responce.Content.ReadAsStringAsync();


                    var regex = new Regex("ul.\\s[a-zA-Z]+\\s[0-9]+", RegexOptions.IgnoreCase);

                    var emailAddresses = regex.Matches(htmlContent);

                    foreach (var match in emailAddresses)
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("");
            }

        }
    }
}
