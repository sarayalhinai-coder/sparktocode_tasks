namespace _14_7_HotelManagementSystem
{
    internal class Program
    {

        public static List<Room> rooms = new List<Room>();
        public static List<Guest> guests = new List<Guest>();
        public static void Main(string[] args)
        {

            rooms.Add(new Room("101", "Single", 25.00,true));
            rooms.Add(new Room("102", "Single", 25.00, true));
            rooms.Add(new Room("201", "Double", 40.00, true));
            rooms.Add(new Room("202", "Double", 40.00, true));
            rooms.Add(new Room("301", "Suite", 75.00, true));
            rooms.Add(new Room("302", "Suite", 80.00, true));



            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine("GRAND VISTA HOTEL — MANAGEMENT SYSTEM");
                Console.WriteLine("================================================");
                Console.WriteLine(" 1. Add New Room");
                Console.WriteLine(" 2. Register New Guest");
                Console.WriteLine(" 3. Book a Room for a Guest");
                Console.WriteLine(" 4. View All Rooms");
                Console.WriteLine(" 5. View All Guests");
                Console.WriteLine(" 6. Search & Filter Rooms");
                Console.WriteLine(" 7. Guest & Booking Statistics");
                Console.WriteLine(" 8. Update Room Price");
                Console.WriteLine(" 9. Guest Lookup by Name");
                Console.WriteLine("10. Room Type Breakdown Report");
                Console.WriteLine("11. Check Out a Guest");
                Console.WriteLine("12. Remove Unavailable Rooms");
                Console.WriteLine("13. Extend Guest Stay");
                Console.WriteLine("14. Highest Revenue Booking");
                Console.WriteLine("15. Guest Pagination Viewer");
                Console.WriteLine(" 0. Exit");
                Console.WriteLine("================================================");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine()??"0");
                switch (choice) 
                {
                    case 0:
                        running = false;
                        break;
                    case 1:
                        NewRoom();
                        break;
                    case 2:
                        NewGuest();
                        break;
                    case 3:
                        RoomGuest();
                        break;
                    case 4:
                        ViewRooms();
                        break;
                    case 5:
                        ViewGuests();
                        break;
                    case 6:
                        FilterRooms();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again."); 
                        break;

                }


            }

        }

        public static void NewRoom()
        {
            Console.WriteLine("Enter room number: ");
            string roomN = Console.ReadLine() ?? "0";
            if (!int.TryParse(roomN, out int roomNumInt) || roomNumInt <= 0)
            {
                Console.WriteLine("Invalid room number. Must be a positive number.");
                return;
            }
            if (rooms.Any(r => r.roomNumber == roomN))
            {
                Console.WriteLine($"Error: Room {roomN} already exists.");
                return;
            }
            Console.WriteLine("Enter room type(Single / Double / Suite): ");
            string type = Console.ReadLine()??"";

            Console.WriteLine("Enter price per night: ");
            if (!double.TryParse(Console.ReadLine(), out double price) || price <= 0)
            {
                Console.WriteLine("Invalid price. Must be a positive number.");
                return;
            }
            rooms.Add(new Room(roomN, type, price , true));
            Console.WriteLine("Room added successfully!");
            Console.WriteLine($"Room {roomN} | {type} | Price; {price}");
            Console.WriteLine("Total rooms: "+ rooms.Count);
        }

        public static void NewGuest()
        {
            Console.WriteLine("Enter guest name: ");
            string name = Console.ReadLine() ??"";
            Console.WriteLine("Enter check in date: ");
            string date = Console.ReadLine() ?? "";
            Console.WriteLine("Enter number of nights: ");
            if (!int.TryParse(Console.ReadLine(), out int nights) || nights <= 0)
            {
                Console.WriteLine("Invalid number of nights. Must be a positive integer.");
                return;
            }
            string newguestId = $"G{(guests.Count + 1):D3}";

            Guest new_guest = new Guest(newguestId, name, "Not Assigned", date, nights);
            guests.Add(new_guest);
            Console.WriteLine("Guest registered successfully!");
            Console.WriteLine($"Guest ID: {newguestId} | Name: {name} | Check-in: {date} | Nights: {nights}");
        }

        public static void RoomGuest()
        {
            Console.WriteLine("Enter guest ID: ");
            string user_id = Console.ReadLine() ?? "";
            Console.WriteLine("Enter room number: ");
            string user_room = Console.ReadLine() ?? "";

            Guest guest = guests.FirstOrDefault(g => g.guestId == user_id);
            if (guest == null)
            {
                Console.WriteLine("Guest not fount");
                return;
            }

            Room room = rooms.FirstOrDefault(r=> r.roomNumber == user_room);
            if (room == null)
            {
                Console.WriteLine("Room not fount");
                return;
            }

            if (!room.IsAvailable)
            {
                Console.WriteLine("Room already booked");
                return;
            }

            guest.roomNumber = room.roomNumber;
            room.IsAvailable = false;
            double cost = guest.CalculateTotalCost(room.PricePerNight);

            Console.WriteLine("Booking confirmed");
            Console.WriteLine($"Guest: {guest.guestName} | Room: {room.roomNumber} ({room.roomType}) | Price: {room.PricePerNight}");
            Console.WriteLine($"Total nights: {guest.totalNights} | Total cost: {cost}");
        }

        public static void ViewRooms()
        {
            List<Room> ordered_rooms = rooms.OrderBy(r => int.Parse(r.roomNumber)).ToList();

            if (ordered_rooms.Count == 0)
            {
                Console.WriteLine("No rooms have been added yet.");
                return;
            }

            Console.WriteLine("Total rooms: " + rooms.Count());
            foreach (Room room in ordered_rooms)
            {
                room.displayRoom();
            }
        }

        public static void ViewGuests()
        {
            List<Guest> ordered_guests = guests.OrderBy(g => g.guestName).ToList();
            if (ordered_guests.Count == 0)
            {
                Console.WriteLine("No guests have been registered yet.");
                return;
            }
            Console.WriteLine("Total guests: " + guests.Count);
            foreach (Guest guest in ordered_guests)
            {
                guest.displayGuest();
            }
        }

        public static void FilterRooms()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("--- Search & Filter Rooms ---");
                Console.WriteLine("1. Show all available rooms");
                Console.WriteLine("2. Filter by room type");
                Console.WriteLine("3. Filter by max price");
                Console.WriteLine("4. Room price statistics");
                Console.WriteLine("0. Back");
                Console.Write("Enter your choice: ");
                string subChoice = Console.ReadLine() ?? "";

                switch (subChoice)
                {
                    case "1":
                        List<Room> available_rooms = rooms.Where(r => r.IsAvailable == true).OrderBy(r => r.PricePerNight).ToList();
                        Console.WriteLine("Available rooms: " + available_rooms.Count);
                        if (available_rooms.Count == 0)
                        {
                            Console.WriteLine("No rooms found for the selected criteria. ");
                        }
                        foreach(Room room in available_rooms)
                        {
                            room.displayRoom();
                        }
                        break;
                    case "2":
                        Console.Write("Enter room type: ");
                        string type = Console.ReadLine() ?? "";
                        List<Room> type_rooms = rooms.Where(r => r.roomType == type).ToList();
                        Console.WriteLine($"Rooms of type {type}: {type_rooms.Count}");
                        if (type_rooms.Count == 0)
                        {
                            Console.WriteLine("No rooms found for the selected criteria.");
                        }
                        foreach (Room room in type_rooms)
                        {
                            room.displayRoom();
                        }
                        break;

                    case "3":
                        Console.Write("Enter max price: ");
                        double max_price= double.Parse(Console.ReadLine()??"0");
                        List <Room> price_rooms = rooms.Where(r => r.PricePerNight <= max_price).OrderBy(r => r.PricePerNight).ToList();
                        Console.WriteLine($"Available rooms at or below {max_price}: {price_rooms.Count}");
                        if (price_rooms.Count == 0)
                        {
                            Console.WriteLine("No rooms found for the selected criteria.");
                        }
                        foreach (Room room in price_rooms)
                        {
                            room.displayRoom();
                        }
                        break;

                    case "4":
                        Console.WriteLine("Total rooms: "+rooms.Count);
                        Console.WriteLine("Available rooms: " + rooms.Count(r => r.IsAvailable));
                        Console.WriteLine("Average price: " + rooms.Average(r => r.PricePerNight));
                        Console.WriteLine("Cheapest  price: " + rooms.Min(r => r.PricePerNight));
                        Console.WriteLine("Most expensive price: " + rooms.Max(r => r.PricePerNight));
                        break;

                    case "0":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
