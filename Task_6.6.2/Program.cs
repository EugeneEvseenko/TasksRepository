using System;

namespace Task_6._6._2
{
    internal class Program
    {
		class User
		{
			private int age;
			private string email;
			private string login;

			public int Age
			{
				get
				{
					return age;
				}

				set
				{
					if (value < 18)
					{
						Console.WriteLine("Возраст должен быть не меньше 18");
					}
					else
					{
						age = value;
					}
				}
			}
			public string Email
            {
				get { return email; }
				set {
					if (!value.Contains("@"))
						Console.WriteLine("Поле почты должно содержать знак \"@\".");
					else
						email = value;
				}
            }
			public string Login
            {
				get { return login; }
                set
                {
					if (value.Length < 3)
						Console.WriteLine("Поле логина должно быть не менее 3 символов длиной.");
					else
						login = value;
				}
            }
		}
		static void Main(string[] args)
        {
			Console.ReadKey();
        }
    }
}
