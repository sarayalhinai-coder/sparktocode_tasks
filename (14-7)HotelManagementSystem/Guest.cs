using System;
using System.Collections.Generic;
using System.Text;

namespace _14_7_HotelManagementSystem
{
    public class Guest
    {
        public int guestId {  get; set; }
        public string guestName{ get; set; }
        public string roomNumber { get; set; }
        public string checkInDate {  get; set; }
        public int totalNights { get; set; }


        public Guest(int Id, string Name, string roomNO, string Date, int Nights)
        {
            Id = guestId;
            Name = guestName;
            roomNO = roomNumber;
            Date = checkInDate;
            Nights = totalNights;

        }

        public void displayGuest()
        {
            Console.WriteLine("Guest ID: "+guestId);
            Console.WriteLine("Guest Name: " +guestName);
            Console.WriteLine("Room Number: " + roomNumber);
            Console.WriteLine("Chech in Date: " + checkInDate);
            Console.WriteLine("Total Nights: " + totalNights);
        }

        public double CalculateTotalCost(double pricePerNight)
        {
            return pricePerNight * totalNights;
        }
    }
}
