using System;

namespace Rahfanim
{
    class Program
    {
        static void Main()
        {
            //new drone!
            DeliveryDrone drone = new DeliveryDrone("D901", 10);

            //takeoff??
            DeliveryResult takeOffResult = drone.TakeOff();
            Console.WriteLine("TakeOff: Success=" + takeOffResult.IsSuccess + ", Message='" + takeOffResult.Message + "'");

            //delivery
            DeliveryResult deliveryResult = drone.AssignDelivery(5, 10);
            Console.WriteLine("AssignDelivery: Success=" + deliveryResult.IsSuccess + ", Message='" + deliveryResult.Message + "'");

            //land
            try
            {
                drone.Land();
                Console.WriteLine("Landing: Status=" + drone.Status + ", Altitude=" + drone.CurrentAltitudeMeters);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Landing failed: " + ex.Message);
            }

            //battery check
            Console.WriteLine("Battery after delivery: " + drone.BatteryPercentage + "%");
        }
    }
}