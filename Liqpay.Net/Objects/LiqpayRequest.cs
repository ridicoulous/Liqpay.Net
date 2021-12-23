using Liqpay.Objects.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;


namespace Liqpay.Net.Objects
{/*	

    
subscribe	Optional	String	Регулярный платеж. Возможные значения: 1
subscribe_date_start	Optional	String	Дата первого платежа. Время необходимо указывать в следующем формате 2015-03-31 00:00:00 по UTC. Если указана прошедшая дата, то подписка будет активирована с текущей даты получения запроса
subscribe_periodicity	Optional	String	Периодичность списания средств. Возможные значения:
month - раз в месяц
year - раз в год


expired_date	Optional	String	Время до которого клиент может оплатить счет по UTC. Передается в формате 2016-04-24 00:00:00
language	Optional	String	Язык клиента ru, uk, en
paytypes	Optional	String	Параметр в котором передаются способы оплаты, которые будут отображены на чекауте. Возможные значения apay - оплата с помощью Apple Pay, gpay - оплата с помощью Google Pay, card - оплата картой, liqpay - через кабинет liqpay, privat24 - через кабинет приват24, masterpass - через кабинет masterpass, moment_part - рассрочка, cash - наличными, invoice - счет на e-mail, qr - сканирование qr-кода. Если параметр не передан, то применяются настройки магазина, вкладка Checkout.
result_url	Optional	String	URL в Вашем магазине на который покупатель будет переадресован после завершения покупки. Максимальная длина 510 символов.
server_url	Optional	String	URL API в Вашем магазине для уведомлений об изменении статуса платежа (сервер->сервер). Максимальная длина 510 символов. Подробнее
verifycode	Optional	String	Возможное значение Y. Динамический код верификации, генерируется и возвращается в Callback. Так же сгенерированный код будет передан в транзакции верификации для отображения в выписке по карте клиента. Работает для action= auth.*/
    public class LiqpayRequest
    {
        /// <summary>
        /// Required	Версия API. Текущее значение - 3
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; } = 3;
        /// <summary>
        /// Required	Публичный ключ - идентификатор магазина. Получить ключ можно в настройках магазина
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }
        /// <summary>
        /// Required	Тип операции. Возможные значения: pay - платеж, hold - блокировка средств на счету отправителя, subscribe - регулярный платеж, paydonate - пожертвование, auth - предавторизация карты
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LiqPayRequestAction? Action { get; set; }
        /// <summary>
        /// Required Сумма платежа.Например: 5, 7.34
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Required Валюта платежа. Возможные значения: USD, EUR, RUB, UAH
        /// </summary>
        [JsonProperty("currency")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LiqPayCurrency Currency { get; set; }

        /// <summary>
        /// Required Назначение платежа.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// order_id	Required	String	Уникальный ID покупки в Вашем магазине. Максимальная длина 255 символов.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; }


        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("card_token")]
        public string CardToken { get; set; }
        [JsonProperty("ip")]
        public string IP { get; set; }
        [JsonProperty("prepare")]
        public string Prepare { get; set; }
        [JsonProperty("paytypes")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LiqPayRequestPayType? PayTypes { get; set; }
    

        [JsonProperty("sandbox")]
        public string Sandbox { get; set; }
        [JsonIgnore]
        public bool IsSandbox
        {
            get
            {
                return Sandbox == "1";
            }
            set
            {
                Sandbox = value ? "1" : null;
            }
        }

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("action_payment")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LiqPayRequestActionPayment? ActionPayment { get; set; }
        [JsonProperty("expired_date")]
        public DateTime? ExpiredDate { get; set; }
        [JsonProperty("goods")]
        public List<LiqpayRequestGoods> Goods { get; set; }
        [JsonProperty("language")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LiqPayRequestLanguage? Language { get; set; }
        [JsonProperty("subscribe_periodicity")]
        public string SubscribePeriodicity { get; set; }
        public string Subscribe { get; set; }

        [JsonIgnore]
        public bool IsSubscribe
        {
            get { return Subscribe == "1"; }
            set { Subscribe = value ? "1" : null; }
        }

        [JsonProperty("subscribe_date_start")]
        public string SubscribeDateStart { get; set; }

        [JsonProperty("result_url")]
        public string ResultUrl { get; set; }
        [JsonProperty("server_url")]
        public string ServerUrl { get; set; }

        [JsonIgnore]
        public IDictionary<string, string> OtherParams { get; set; } = new Dictionary<string, string>();

    }
}
