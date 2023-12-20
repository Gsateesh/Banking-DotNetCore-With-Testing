using System.Text.Json.Serialization;

namespace Accounts.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountTypes
    {
        Savings = 0,
        JointSaving = 1,
        Current = 2,
        JointCurrent = 3,
        Loan = 4,
        JointLoan = 5,
    }
}
