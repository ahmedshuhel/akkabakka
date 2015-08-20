using System.Collections.Generic;

namespace AkkaBakka
{
  public class PlaceOrderMessage
  {
    public PlaceOrderMessage(string customerName, string deliveryAddress, List<string> menus)
    {
      CustomerName = customerName;
      DeliveryAddress = deliveryAddress;
      Menus = menus;
    }

    public string CustomerName { get; private set; }
    public string DeliveryAddress { get; private set; }
    public List<string> Menus { get; private set; }
  }
}