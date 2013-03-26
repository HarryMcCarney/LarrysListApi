public class AdyenResult
{
    public string merchantReference { get; set; }
    public string skinCode { get; set; }
    public string shopperLocale { get; set; }
    public string paymentMethod { get; set; }
    public string authResult { get; set; }
    public string pspReference { get; set; }
    public string merchantSig { get; set; }
}