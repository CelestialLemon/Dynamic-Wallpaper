using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Drawing;

namespace Dynamic_Wallpaper
{
    class Program
    {
        static List<String> queries = new List<string>();
        const String IMAGAE_DOWNLOAD_FOLDER = @"C:\Users\Ashutosh\Pictures\Dynamic Wallpaper\";
        static void Main(string[] args)
        {
            Console.WriteLine("Making API Call...");
            
            String randomQuery = ReadQueries();
            String imageData = GetRandomImage(randomQuery);
            String imageURL = GetURLFromJson(imageData);
            DownloadImage(imageURL, IMAGAE_DOWNLOAD_FOLDER, randomQuery);
            Console.WriteLine("Finished");
            Console.ReadLine();   
        }

        static String ReadQueries()
        {
            queries.Add("Summer");
            queries.Add("Winter");
            queries.Add("Nautre");
            queries.Add("Valley");
            queries.Add("Landscape");

            Random random = new Random();
            return queries[random.Next(0, queries.Count)];
        }

        static String GetRandomImage(String query)
        {
            Random random = new Random();
            string result;
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("https://api.unsplash.com/");
                HttpResponseMessage response = client.GetAsync("photos/random?query=" + query + "&orientation=landscape&client_id=i380ZsULOmCsRW_vUzscZ9lXmv8Qxe5EC3dLuiOJKlg&orientation=landscape").Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }

        static String GetURLFromJson(String json)
        {
            int startIndex = json.IndexOf("\"raw\"");
            int endIndex = json.IndexOf("\"full\"");

            if(startIndex == -1 || endIndex == -1) return String.Empty ;
            else
            {
                startIndex += 7;
                endIndex -= 2;
                string link = json.Substring(startIndex, endIndex - startIndex);
                return link;
            }
        }

        static void DownloadImage(string imageURL, String filepath, String filename)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageURL);
            Bitmap image = new Bitmap(stream);

            if(image != null)
            {
                image.Save(filepath + filename + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }                        
            stream.Flush();
            stream.Close();
            client.Dispose();
        }
    }
}
