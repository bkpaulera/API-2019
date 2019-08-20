using System;

public class User
{
    public int ClienteID { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public DateTime RegisterDate { get; set; }

    public bool Active { get; set; }
}
