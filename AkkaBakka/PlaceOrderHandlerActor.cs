using System;
using Akka.Actor;

namespace AkkaBakka
{
  public class PlaceOrderHandlerActor : ReceiveActor
  {
    public PlaceOrderHandlerActor()
    {
      Receive<PlaceOrderMessage>(msg =>
      {
        Console.WriteLine("Customer Name " +  msg.CustomerName);
        Console.WriteLine("Address " +  msg.DeliveryAddress);
        Console.WriteLine("Menu Ordered: ");
        msg.Menus.ForEach(Console.WriteLine);
      });
    }

    protected override void PreStart()
    {
      WriteColorMessage("The handler is strating...", ConsoleColor.Green);
    }

    private static void WriteColorMessage(string message, ConsoleColor messgeColor)
    {
      var color = Console.ForegroundColor;
      Console.ForegroundColor = messgeColor;
      Console.WriteLine(message);
      Console.ForegroundColor = color;
    }

    protected override void PostStop()
    {
      WriteColorMessage("The handler is stopped...", ConsoleColor.Red);
    }

    protected override void PreRestart(Exception reason, object message)
    {
      WriteColorMessage("Re starting the hander becasuse of: " + message, ConsoleColor.Cyan );
      base.PreRestart(reason, message);
    }

    protected override void PostRestart(Exception reason)
    {
      WriteColorMessage("The hander is restarted", ConsoleColor.Green );
      base.PostRestart(reason);
    }
  }
}