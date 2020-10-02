using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3_LinqTask_
{
    /// <summary>
    /// Business logic class for data processing. 
    /// </summary>
    public class BusinessLogic
    {
        private List<User> users = new List<User>();
        private List<Record> records = new List<Record>();

        /// <summary>
        /// Filling collections with test data.
        /// </summary>
        public BusinessLogic()
        {
            users.Add(new User(235, "Victor", "Ivanov"));
            records.Add(new Record(users[0], $"My name is {users[0].Name} {users[0].Surname}"));
            users.Add(new User(567, "Ivan", "Wertov"));
            records.Add(new Record(users[1], $"My name is {users[1].Name} {users[1].Surname}"));
            users.Add(new User(3456, "Filipp", "Strazov"));
            records.Add(new Record(users[2], $"My name is {users[2].Name} {users[2].Surname}"));
            users.Add(new User(777, "Anna", "Sergeeva"));
            records.Add(new Record(users[3], $"My name is {users[3].Name} {users[3].Surname}"));
            users.Add(new User(987, "Lika", "Petrova"));
            records.Add(new Record(users[4], null));
            Console.WriteLine($"{records[0].Author}\nMessage: {records[0].Message}\n");
            Console.WriteLine($"{records[1].Author}\nMessage: {records[1].Message}\n");
            Console.WriteLine($"{records[2].Author}\nMessage: {records[2].Message}\n");
            Console.WriteLine($"{records[3].Author}\nMessage: {records[3].Message}\n");
            Console.WriteLine($"{records[4].Author}\nMessage: {records[4].Message}\n");
        }

        /// <summary>
        /// Get user.
        /// </summary>
        /// <param name="i">Index of user.</param>
        /// <returns>Used.</returns>
        public User GetUser(int i)
        {
            return users[i];
        }

        /// <summary>
        /// Get users by surname.
        /// </summary>
        /// <param name="surname">User's surname.</param>
        /// <returns>List of users.</returns>
        public List<User> GetUsersBySurname(string surname)
        {
            var usersBySurname = (from user in users
                           where user.Surname == surname
                           select user).ToList();
            return usersBySurname;
        }

        /// <summary>
        /// Get user by ID.
        /// </summary>
        /// <param name="id">USer's ID.</param>
        /// <returns>User.</returns>
        public User GetUserByID(int id)
        {
            try
            {
                var userByID = (from user in users
                                where user.ID == id
                                select user).ToList();
                return userByID[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                Single();
                return null;
            }
        }

        /// <summary>
        /// Throw NotImplementedException.
        /// </summary>
        private void Single()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get user by substring.
        /// </summary>
        /// <param name="substring">the contained string.</param>
        /// <returns>List of users.</returns>
        public List<User> GetUsersBySubstring(string substring)
        {
            var usersBySubstring = (from user in users
                                    where user.Surname.Contains(substring)
                                    select user).ToList();
            return usersBySubstring;
        }

        /// <summary>
        /// Get all unique names.
        /// </summary>
        /// <returns>List of uniques user's names.</returns>
        public List<string> GetAllUniqueNames()
        {
            List<string> listOfAllNames = (from user in users
                                     select user.Name).ToList();
            IEnumerable<string> unique = listOfAllNames.Distinct();
            return unique.ToList();
        }

        /// <summary>
        /// Get all authors who has massage.
        /// </summary>
        /// <returns>List of all authors with message.</returns>
        public List<User> GetAllAuthor()
        {
            var listOfAllAuthors = (from record in records
                                    where record.Message != null
                                    select record.Author).ToList();
            return listOfAllAuthors;
        }

        /// <summary>
        /// Get users dictionary.
        /// </summary>
        /// <returns>Dictionary of users.</returns>
        /*public Dictionary<int, User> GetUsersDictionary()
        {
            Dictionary<string, Users>
        }*/
        
        /// <summary>
        /// Get max user's ID.
        /// </summary>
        /// <returns>Max ID value.</returns>
        public int GetMaxID()
        {
            int maxValue = users[0].ID;
            foreach (var user in users.Where(user => maxValue < user.ID))
            {
                maxValue = user.ID;
            }
            return maxValue;
        }

        /// <summary>
        /// Get ordered users.
        /// </summary>
        /// <returns>List of ordered users.</returns>
        public List<User> GetOrderedUsers()
        {
            var sortedUsers = (from id in users
                               orderby id.ID
                               select id).ToList();
            return sortedUsers;
        }

        /// <summary>
        ///  Get descending ordered users.
        /// </summary>
        /// <returns>List of descending ordered users.</returns>
        public List<User> GetDescendingOrderedUsers()
        {
            var sortedUsers = (from id in users
                               orderby id.ID descending
                               select id).ToList();
            return sortedUsers;
        }

        /// <summary>
        /// Get reversed users.
        /// </summary>
        /// <returns>Reversed list of users.</returns>
        public List<User> GetReversedUsers()
        {
            users.Reverse();
            return users;
        }

        /// <summary>
        /// Get users page.
        /// </summary>
        /// <param name="pageSize">The max possible numbers of elements on the page.</param>
        /// <param name="pageIndex">Number of items to skip</param>
        /// <returns>List of selected users.</returns>
        public List<User> GetUsersPage(int pageSize, int pageIndex)
        {
            var result = (users.Skip(pageIndex).Take(pageSize)).ToList();
            return result;
        }
    }
}