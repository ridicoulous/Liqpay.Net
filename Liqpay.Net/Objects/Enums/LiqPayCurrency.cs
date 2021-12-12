﻿using System.Runtime.Serialization;

namespace Liqpay.Objects.Enums
{
    public enum LiqPayCurrency
    {
        [EnumMember(Value = "USD")]
        USD,
        [EnumMember(Value = "EUR")]
        EUR,
        [EnumMember(Value = "RUB")]
        RUB,
        [EnumMember(Value = "UAH")]
        UAH,
        [EnumMember(Value = "BYN")]
        BYN,
        [EnumMember(Value = "KZT")]
        KZT,
        [EnumMember(Value = "GBP")]
        GBP
    }
}