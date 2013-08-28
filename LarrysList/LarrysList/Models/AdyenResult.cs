public class AdyenResult
{
    public string merchantReference {
        get { return cartId; }

   }
    public string skinCode { get; set; }

    public string shopperLocale { get; set; }

    public string paymentMethod { get; set; }

    public string authResult { get { return rawAuthCode; } }

    public string pspReference { get { return instId; } }    
  

    public string merchantSig { get; set; }

    public string cartId { get; set; }

    public string rawAuthCode { get; set; }

    public string instId { get; set; }



    


    


}