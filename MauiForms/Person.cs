using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiForms;

public class Person
{
    public string GivenName { get; set; }
    public string Surname { get; set; }

    public DateTimeOffset DateOfBirth { get; set; }
}
