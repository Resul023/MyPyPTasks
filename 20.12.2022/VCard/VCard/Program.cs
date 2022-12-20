using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using VCard.Models;

namespace VCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                var endpoint = new Uri("https://randomuser.me/api?results=5");
                var result = client.GetAsync(endpoint).Result;
                if (result !=null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseBody = result.Content.ReadAsStringAsync().Result;
                    UserDataModel responseItem = JsonConvert.DeserializeObject<UserDataModel>(responseBody);
                    
                    List<Vcard> vCardList = Service.CreateVcardList(responseItem);

                    foreach (var item in vCardList)
                    {
                       var stringVCard = Service.ConvertToVcard(item);
                       Service.FillVcardDataToTxt(stringVCard);
                    }

                }
            }

            //var request = (HttpWebRequest)WebRequest.Create(endPoint);

            //var response = (HttpWebResponse)request.GetResponse();

            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

        }
        

    }
}