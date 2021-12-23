using System.Runtime.Serialization;

namespace Liqpay.Objects.Enums
{
    /// <summary>
    /// Required	String	Тип операции. Возможные значения: pay - платеж, hold - блокировка средств на счету отправителя, subscribe - регулярный платеж, paydonate - пожертвование, auth - предавторизация карты
    /// </summary>
    public enum LiqPayRequestAction
    {
        [EnumMember(Value = "pay")]
        Pay,
        [EnumMember(Value = "hold")]
        Hold,
        [EnumMember(Value = "subscribe")]
        Subscribe,
        [EnumMember(Value = "paydonate")]
        Paydonate,
        [EnumMember(Value = "auth")]
        Auth
    }
}