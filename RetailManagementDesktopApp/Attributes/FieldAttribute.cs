using System;
using System.Collections.Generic;
using System.Text;

namespace RetailManagementDesktopApp.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public class FieldAttribute(string errorMessage, bool check, string? reference = null) : Attribute
{
    public string ErrorMessage => errorMessage;
    public bool Check => check;
    public string? Reference => reference;

}
