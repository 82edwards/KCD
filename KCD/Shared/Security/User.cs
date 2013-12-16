using System;

namespace KcdModel.Security
{
    public class User
    {
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }
        #endregion
    }
}