using System;
using System.Collections.Generic;
using System.Text;

namespace _14_7_HotelManagementSystem
{
    public class Room
    {
        public string roomNumber { get; set; }
        public string roomType { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        public Room(string roomNO , string type, double price , bool avilable)
        {
            roomNumber=roomNO;
            roomType=type;
            PricePerNight=price;
            IsAvailable = avilable;

        }

        public void displayRoom()
        {
            Console.WriteLine("Room Number: " + roomNumber);
            Console.WriteLine("Room Type: " + roomType);
            Console.WriteLine("Price per Night: "+PricePerNight);
            Console.WriteLine("Room Availability : " + (IsAvailable ? "Available" : "Booked"));

        }

    }
}
