namespace KcdModel.Security
{
    public class PhoneNumber
    {
        #region Properties
        public int Id { get; set; }
        public string Value { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public string PhoneNumberType { get; set; }
        #endregion
    }
}
