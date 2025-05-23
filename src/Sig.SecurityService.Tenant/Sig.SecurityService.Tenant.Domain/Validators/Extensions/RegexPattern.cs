using System.Text.RegularExpressions;

namespace Sig.SecurityServiceTenant.Domain.Validators.Extensions;

using System.Text.RegularExpressions;

public static class RegexPatterns
{
    /// <summary>
    /// Matches Brazilian phone numbers (e.g., (11) 98765-4321).
    /// </summary>
    public static readonly Regex Phone = new(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", RegexOptions.Compiled);

    public static readonly Regex Name = new(@"^[A-Za-zÀ-ÿ]{2,}(?: [A-Za-zÀ-ÿ]{2,})*$", RegexOptions.Compiled);
    /// <summary>
    /// Matches Brazilian postal codes (CEP) in format 00000-000
    /// </summary>
    public static readonly Regex PostalCode = new(@"^\d{5}-?\d{3}$", RegexOptions.Compiled);

    /// <summary>
    /// Matches valid Brazilian state (UF) codes (2 uppercase letters)
    /// </summary>
    public static readonly Regex UfCode = new(@"^[A-Z]{2}$", RegexOptions.Compiled);
}