using System;
using System.Collections.Generic;

namespace NameLibrary
{
    public class Employee : User
    {
        private int roleId;

        private static readonly Dictionary<int, string> RoleLookup = new Dictionary<int, string>
        {
            { 1, "Trainer" },
            { 2, "HR" },
            { 3, "Nutritionist" }
        };

        public Employee(int id, string firstName, string lastName, string username, string password, string email, int roleId)
            : base(id, firstName, lastName, username, password, email)
        {
            this.roleId = roleId;
        }

        public Employee(string firstName, string lastName, string username, string password, string email, int roleId)
            : base(firstName, lastName, username, password, email)
        {
            this.roleId = roleId;
        }

        public int RoleId()
        {
            return roleId;
        }

        public string Role()
        {
            return RoleLookup.ContainsKey(roleId) ? RoleLookup[roleId] : "Unknown";
        }

        public override string ToString()
        {
            return base.ToString() + " Role: " + Role();
        }
    }
}
