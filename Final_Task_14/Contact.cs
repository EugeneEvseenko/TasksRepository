namespace Final_Task_14
{
    public class Contact
    {
        /// <param name="name">Имя контакта</param>
        /// <param name="lastName">Фамилия контакта</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="email">Адрес электронной почты</param>
        public Contact(string name, string lastName, long phoneNumber, string email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        /// <summary>
        /// Имя контакта
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Фамилия контакта
        /// </summary>
        public string LastName { get; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public long PhoneNumber { get; }
        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; }
    }
}
