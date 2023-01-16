using DataAccess.Models;
using Pluralize.NET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Services
{
    public  class GenericPersonService<T> where T: new()
    {
        private const string _CONNECTION_STRING = @"Server=DESKTOP-0UDOH5O;Database=PhoneBook;Trusted_Connection=True;";
        //public static List<T> GetAllPerson()
        //{
        //    SqlConnection connection = new SqlConnection(_CONNECTION_STRING);
        //    SqlCommand command = new SqlCommand("", connection);
        //    if (connection.State == ConnectionState.Closed) connection.Open();
        //    Pluralizer pl = new Pluralizer();
        //    string tableName = pl.Pluralize(typeof(Person).Name);
        //    command.CommandText = "SELECT [Id],[FirstName],[LastName],[Phone],[Email] FROM @TableName";
        //    command.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = tableName;
        //    SqlDataReader dr = command.ExecuteReader();
        //    List<T> list = new List<T>();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            T person = new T();
        //            person.Id = Convert.ToInt32(dr[0]);
        //            person.FirstName = dr["FirstName"].ToString();
        //            person.LastName = dr["LastName"].ToString();
        //            person.Phone = dr["Phone"].ToString();
        //            person.Email = dr["Email"].ToString();
        //            list.Add(person);
        //        }
        //    }
        //    dr.Close();
        //    connection.Close();
        //    return list;

        //}
    }
}
