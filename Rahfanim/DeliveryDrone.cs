using System;
using System.Dynamic;

namespace Rahfanim;

public class DeliveryDrone
{
    public String Id { get; }
    public double MaxWeightCapacityKg { get; }
    public double BatteryPercentage { get; private set; }
    public double CurrentAltitudeMeters { get; private set; }
    public enum DroneStatus { Grounded, InFlight, ReturningHome }
    public DroneStatus Status { get; private set; }

    public DeliveryDrone(string id, double maxWeightCapacity)
    {
        if (String.IsNullOrEmpty(id))
            throw new ArgumentNullException("there is no id");
        if (maxWeightCapacity <= 0)
            throw new ArgumentOutOfRangeException("no way...");
        this.Id = id;
        this.MaxWeightCapacityKg = maxWeightCapacity;
        this.Status = DroneStatus.Grounded;
        this.CurrentAltitudeMeters = 0;
        this.BatteryPercentage = 100;
    }

    public DeliveryResult TakeOff()
    {
        if (BatteryPercentage < 30)
            return DeliveryResult.Failure("Battery too low for takeoff.");
        if (Status != DroneStatus.Grounded)
            throw new InvalidOperationException("Drone must be grounded to take off.");
        CurrentAltitudeMeters = 50;
        Status = DroneStatus.InFlight;
        return DeliveryResult.Success("Takeoff successful.");
    }
    public DeliveryResult AssignDelivery(double packageWeight, int distanceKm) {
        if (packageWeight > MaxWeightCapacityKg)
            return DeliveryResult.Failure("It's too heavy for this drone.");
        if (distanceKm * 5 > BatteryPercentage)
            return DeliveryResult.Failure("There is not enough battery for this distance.");
        if (Status != DroneStatus.InFlight)
            throw new InvalidOperationException("The drone is not ready");
        BatteryPercentage -= 5 * distanceKm;
        Status = DroneStatus.ReturningHome;
        return DeliveryResult.Success("Assign Delivery successful.");
    }
    public void Land()
    {
        if (Status != DroneStatus.ReturningHome)
            throw new InvalidOperationException("It is not returning home now.");
        CurrentAltitudeMeters = 0;
        Status = DroneStatus.Grounded;
    }

}
