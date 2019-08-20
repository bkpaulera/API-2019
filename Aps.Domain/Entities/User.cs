using System;

namespace Aps.Domain
{
    public class User
    {
        public User()
        {
            this.RegisterDate = DateTime.Now;
        }
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool Active { get; set; }
    }
}
