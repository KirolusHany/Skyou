using System;
using KikoStore.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Company.ClassLibrary1;

public class AppUser :IdentityUser
{

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Address? Adress { get; set; }
}
