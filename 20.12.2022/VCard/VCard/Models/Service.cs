using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCard.Models
{
    public class Service
    {
        public static List<Vcard> CreateVcardList(UserDataModel responseItem)
        {
            List<Vcard> vCards = new List<Vcard>();
            foreach (var item in responseItem.results)
            {

                Vcard newUser = new Vcard();
                newUser.Name = item.name.first;
                newUser.Surname = item.name.last;
                newUser.Email = item.email;
                newUser.Phone = item.phone;
                newUser.Country = item.location.country;
                newUser.City = item.location.city;
                vCards.Add(newUser);
            }
            return vCards;
        }

        public static void FillVcardDataToTxt(string vCard)
        {
            string _path = @"C:\Users\User\Desktop\UserVCardData.txt";
            FileInfo isExistFile = new FileInfo(_path);
            if (!isExistFile.Exists)
            {
                using (FileStream fileStream = new FileStream(_path, FileMode.Create))
                {
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(vCard);
                    streamWriter.Close();
                }
            }
            else
            {
                File.AppendAllText(_path, vCard + Environment.NewLine);
            }

        }
        public static string ConvertToVcard(Vcard vCardData)
        {
            string newUserVCard = $"""
                    BEGIN:VCARD
                    VERSION:3.0
                    FN: {vCardData.Name} {vCardData.Surname}
                    N:{vCardData.Surname};{vCardData.Name};;;
                    EMAIL;TYPE=WORK:{vCardData.Email}
                    TEL;TPYE=WORK:{vCardData.Phone}
                    ADR:;;{vCardData.City};{vCardData.Country}
                    END:VCARD
                    """;
            
            return newUserVCard;
        }
    }
}
