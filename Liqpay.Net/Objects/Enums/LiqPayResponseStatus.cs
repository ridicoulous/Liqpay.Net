using System.Runtime.Serialization;

namespace Liqpay.Objects.Enums
{
    public enum LiqPayResponseStatus
    {
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "failure")]
        Failure,
        [EnumMember(Value = "sandbox")]
        Sandbox,
        [EnumMember(Value = "success")]
        Success,
        [EnumMember(Value = "subscribed")]
        Subscribed,
        [EnumMember(Value = "unsubscribed")]
        Unsubscribed,
        [EnumMember(Value = "invoice_wait")]
        InvoiceWait,
        [EnumMember(Value = "try_again")]
        TryAgain,
        [EnumMember(Value = "reversed")]
        Reversed,
        [EnumMember(Value = "cash_wait")]
        CashWait,
    }
}