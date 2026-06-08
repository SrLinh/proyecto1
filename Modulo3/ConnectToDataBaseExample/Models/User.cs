using System;
using System.ComponentModel.DataAnnotations;

namespace ConnectToDataBaseExample.Models;

public class User
{
    [Key]
    public int UserID {get; set;}
    public string? UserName {get; set;}
    public string? UserEmail {get; set;}
}