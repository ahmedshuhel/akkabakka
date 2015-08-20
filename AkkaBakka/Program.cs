using System;
using System.Collections.Generic;
using Akka.Actor;

namespace AkkaBakka
{
  internal class Program
  {
    private static ActorSystem _actorSystem;

    private static void Main(string[] args)
    {
      _actorSystem = ActorSystem.Create("OrderSystem");

      var prop = Props.Create<PlaceOrderHandlerActor>();
      var aref = _actorSystem.ActorOf(prop, "OrderHandlerActor");

      aref.Tell(
        new PlaceOrderMessage(
        "Shuhel",
        "Sylhet",
        new List<string>
        {
          "Chicken Tickka",
          "Chicken Chowmeen",
          "Pepsi"
        }));


      Console.ReadLine();

      Console.WriteLine("The system shutting down..");
      _actorSystem.Shutdown();
      _actorSystem.AwaitTermination();

      Console.WriteLine("The system is dead");

      Console.ReadLine();
    }
  }
}