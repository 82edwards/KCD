using Model.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model.Security
{
    public class Account
    {
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Company { get; set; }
        public bool CanSendEmails { get; set; }
        public bool CanBeContactedBySponsers { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public int SelectedGender { get; set; }
        public SelectList Genders
        {
            get
            {
                var genders = Gender.Get();
                return new SelectList(genders, "Value", "Text");
            }
        }
        #endregion

        public int Create()
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    CommandText = "Security.CreateAccount",
                    Connection = conn,
                    Parameters = {                     
                        new SqlParameter("@FirstName", FirstName),
                        new SqlParameter("@LastName", LastName),
                        new SqlParameter("@EmailAddress", EmailAddress),
                        new SqlParameter("@Company", Company),
                        new SqlParameter("@CanSendEmails", CanSendEmails),
                        new SqlParameter("@CanBeContactedBySponsers", CanBeContactedBySponsers),
                        new SqlParameter("@SelectedGender",SelectedGender)
                }
                })
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Update()
        {
            using (var conn = Sql.GetSqlConnection())
            using (var cmd = new SqlCommand
            {
                CommandText = "Security.UpdateAccount",
                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                Parameters = { 
                    new SqlParameter("@AccountId", Id),
                    new SqlParameter("@FirstName", FirstName),
                    new SqlParameter("@LastName", LastName),
                    new SqlParameter("@EmailAddress", EmailAddress),
                    new SqlParameter("@Company", Company),
                    new SqlParameter("@CanSendEmails", CanSendEmails),
                    new SqlParameter("@CanBeContactedBySponsers", CanBeContactedBySponsers),
                    new SqlParameter("@SelectedGender",SelectedGender)
                }
            })
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static IEnumerable<Account> Get()
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var dr = (new SqlCommand
                {
                    Connection = conn,
                    CommandText = "Security.GetAccounts",
                    CommandType = CommandType.StoredProcedure
                }).ExecuteReader())
                {
                    var results = new List<Account>();
                    while (dr.Read())
                    {
                        results.Add(new Account
                        {
                            CanBeContactedBySponsers = Convert.ToBoolean(dr["CanBeContactedBySponsers"]),
                            CanSendEmails = Convert.ToBoolean(dr["CanSendEmails"]),
                            Company = Convert.ToString(dr["Company"]),
                            EmailAddress = Convert.ToString(dr["EmailAddress"]),
                            FirstName = Convert.ToString(dr["FirstName "]),
                            LastName = Convert.ToString(dr["LastName"]),
                            SelectedGender = Convert.ToInt32(dr["SelectedGender"])
                        });
                    }
                    return results;
                }
            }
        }

        public static Account Get(int id)
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var dr = (new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Security.GetAccount"
                }).ExecuteReader())
                {
                    if (!dr.Read())
                        return null;
                    
                        var account = new Account
                            {
                                CanBeContactedBySponsers = Convert.ToBoolean(dr["CanBeContactedBySponsers"]),
                                CanSendEmails = Convert.ToBoolean(dr["CanSendEmails"]),
                                Company = Convert.ToString(dr["Company"]),
                                EmailAddress = Convert.ToString(dr["EmailAddress"]),
                                FirstName = Convert.ToString(dr["FirstName "]),
                                LastName = Convert.ToString(dr["LastName"]),
                                SelectedGender = Convert.ToInt32(dr["SelectedGender"]),
                                PhoneNumbers = new List<PhoneNumber>()
                            };

                        dr.NextResult();

                        while(dr.Read())
                            account.PhoneNumbers.Add(new PhoneNumber{Id = Convert.ToInt32(dr["PhoneNumberId"]),
                                                                        PhoneNumberType = Convert.ToString(dr["PhoneNumberType"]),
                                                                        Value = Convert.ToString(dr["PhoneNumber"]),
                                                                        PhoneNumberTypeId = Convert.ToInt32(dr["PhoneNumberTypeId"])});

                        return account;                    
                }
            }
        }
    }
}
