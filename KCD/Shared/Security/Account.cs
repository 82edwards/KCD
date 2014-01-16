using KcdModel.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace KcdModel.Security
{
    public class Account
    {
        #region Properties
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }
        public string EmailAddressForSponsors { get; set; }
        public string Company { get; set; }
        public bool CanSendEmails { get; set; }
        public bool CanBeContactedBySponsors { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        #endregion

        public Account(IDataRecord dr)
        {
            CanBeContactedBySponsors = Convert.ToBoolean(dr["CanBeContactedBySponsors"]);
            CanSendEmails = Convert.ToBoolean(dr["CanSendEmails"]);
            Company = Convert.ToString(dr["Company"]);
            EmailAddress = Convert.ToString(dr["EmailAddress"]);
            EmailAddressForSponsors = Convert.ToString(dr["EmailAddressForSponsors"]);
            FirstName = Convert.ToString(dr["FirstName "]);
            LastName = Convert.ToString(dr["LastName"]);
            PhoneNumbers = new List<PhoneNumber>();
        }

        public Account()
        {
        }

        public int Create()
        {
            using (var conn = Sql.GetSqlConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    CommandText = "Security.CreateAccount",
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Parameters = {                     
                        new SqlParameter("@UserName", UserName),
                        new SqlParameter("@FirstName", FirstName),
                        new SqlParameter("@LastName", LastName),
                        new SqlParameter("@Password", Password),
                        new SqlParameter("@EmailAddress", EmailAddress),
                        new SqlParameter("@EmailAddressForSponsors", String.IsNullOrWhiteSpace(EmailAddressForSponsors) ? EmailAddress : EmailAddressForSponsors),
                        new SqlParameter("@Company", Company),
                        new SqlParameter("@CanSendEmails", CanSendEmails),
                        new SqlParameter("@CanBeContactedBySponsors", CanBeContactedBySponsors)
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
                    new SqlParameter("@UserName", UserName), 
                    new SqlParameter("@FirstName", FirstName),
                    new SqlParameter("@LastName", LastName),
                    new SqlParameter("@Password", Password),
                    new SqlParameter("@EmailAddress", EmailAddress),
                    new SqlParameter("@EmailAddressForSponsors", EmailAddressForSponsors),
                    new SqlParameter("@Company", Company),
                    new SqlParameter("@CanSendEmails", CanSendEmails),
                    new SqlParameter("@CanBeContactedBySponsors", CanBeContactedBySponsors)
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
                        results.Add(new Account(dr));
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

                    var account = new Account(dr);

                    dr.NextResult();

                    while (dr.Read())
                        account.PhoneNumbers.Add(new PhoneNumber
                        {
                            Id = Convert.ToInt32(dr["PhoneNumberId"]),
                            PhoneNumberType = Convert.ToString(dr["PhoneNumberType"]),
                            Value = Convert.ToString(dr["PhoneNumber"]),
                            PhoneNumberTypeId = Convert.ToInt32(dr["PhoneNumberTypeId"])
                        });

                    return account;
                }
            }
        }

        public static bool Authenticate(string userName, string password)
        {
            using (var conn = Sql.GetSqlConnection())
            using (var cmd = new SqlCommand
            {
                Connection = conn,
                CommandText = "Security.Authenticate",
                CommandType = CommandType.StoredProcedure,
                Parameters = { new SqlParameter("@UserName", userName)
                    , new SqlParameter("@Password", password) 
                }
            })
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    return dr.Read();
                }
            }
        }

        public static bool ResetPassword(string userName, string existingPassword, string newPassword)
        {
            using (var conn = Sql.GetSqlConnection())
            using (var cmd = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Security.ResetPassword",
                Parameters =
                {
                    new SqlParameter("@UserName", userName), 
                    new SqlParameter("@ExistingPassword", existingPassword), 
                    new SqlParameter("@NewPassword", newPassword)
                }
            })
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                    return dr.Read();
            }
        }
    }
}