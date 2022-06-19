using NUnit.Framework;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class UsersTests
    {
        UserService _userService;
        List<string> emails = new();

        [Test, Order(1)]
        public void InitializationTest()
        {
            _userService = new UserService();
            Assert.IsNotNull(_userService);
        }

        [Test, Order(2)]
        public void CreateUsers()
        {
            foreach(var number in Enumerable.Range(0, 10))
            {
                string generatedEmail = $"test{new Random().Next(0, 99999999)}@mail.com";
                _userService.Register(new BLL.Models.UserRegistrationData
                {
                    FirstName = "Test",
                    LastName = "User",
                    Password = "123456789",
                    Email = generatedEmail
                });
                emails.Add(generatedEmail);
            }

            bool success = false;
            foreach(var email in emails)
            {
                try
                {
                    _userService.FindByEmail(email);
                    success = true;
                }
                catch (UserNotFoundException)
                {
                    success = false;
                }
            }
            
            Assert.True(success);
        }

        [Test, Order(3)]
        public void AddFriends()
        {
            Dictionary<string, int> friends = new();
            while (emails.Count != 0)
            {
                var firstUser = _userService.FindByEmail(emails[new Random().Next(0, emails.Count)]);
                emails.Remove(firstUser.Email);
                var secondUser = _userService.FindByEmail(emails[new Random().Next(0, emails.Count)]);
                emails.Remove(secondUser.Email);
                _userService.AddFriend(new BLL.Models.UserAddingFriendData
                {
                    FriendEmail = firstUser.Email,
                    UserId = secondUser.Id
                });
                friends.Add(firstUser.Email, secondUser.Id);
            }

            var success = true;

            foreach (var friend in friends)
            {
                var userFriends = _userService.GetFriendsByUserId(friend.Value);
                if (userFriends.FirstOrDefault(x => x.Email == friend.Key) == null)
                    success = false;
            }

            Assert.True(success);
        }
    }
}
