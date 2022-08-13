namespace BCP.ExchangeRate.Domain
{
    public class User
    {
        #region Properties

        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion

        #region Constructor

        public User()
        {

        }

        public User(string userName, string password, string firstName, string lastName)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion
    }
}