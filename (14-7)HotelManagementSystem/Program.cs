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
    }
}
