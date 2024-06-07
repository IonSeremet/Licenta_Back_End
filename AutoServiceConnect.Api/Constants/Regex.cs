namespace AutoServiceConnect.Api.Constants;

public static class Regex
{
    /// <summary>
    /// got it from here: https://www.w3resource.com/javascript/form/email-validation.php
    /// </summary>
    public const string Email = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";

    /// <summary>
    /// Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.
    /// </summary>
    public const string Password = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$";
}