using System.Runtime.Serialization;

namespace Liqpay.Objects.Enums
{
    /// <summary>
    /// USD, EUR, RUB, UAH
    /// </summary>
    public enum LiqPayCurrency
    {
        [EnumMember(Value = "USD")]
        USD,
        [EnumMember(Value = "EUR")]
        EUR,
        [EnumMember(Value = "RUB")]
        RUB,
        [EnumMember(Value = "UAH")]
        UAH   
    }
}