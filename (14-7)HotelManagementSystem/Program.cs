namespace _14_7_HotelManagementSystem
{
    internal class Program
    {

        public static List<Room> rooms = new List<Room>();
        public static List<Guest> guests = new List<Guest>();
        public static void Main(string[] args)
        {

            rooms.Add(new Room(101, "Single", 25.00,true));
            rooms.Add(new Room(102, "Single", 25.00, true));
            rooms.Add(new Room(201, "Double", 40.00, true));
            rooms.Add(new Room(202, "Double", 40.00, true));
            rooms.Add(new Room(301, "Suite", 75.00, true));
            rooms.Add(new Room(302, "Suite", 80.00, true));



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

                    default:
                        Console.WriteLine("Invalid choice. Try again."); 
                        break;

                }


            }

        }

        public static void NewRoom()
        {
            Console.WriteLine("Enter room number: ");
            int roomN = int.Parse(Console.ReadLine() ?? "0");
            if (roomN <= 0)
            {
                Console.WriteLine("Room number must be positive ");
                return;
            }
            if (rooms.Any(r => r.roomNumber == roomN))
            {
                Console.WriteLine($"Error: Room {roomN} already exists.");
                return;
            }
            Console.WriteLine("Enter room type(Single / Double / Suite): ");
            string type = Console.ReadLine();

            Console.WriteLine("Enter price per night: ");
            int price = int.Parse(Console.ReadLine() ?? "0");
            if (price <= 0)
            {
                Console.WriteLine("price per night must be positive ");
                return;
            }
            rooms.Add(new Room(roomN, type, price , true));
            Console.WriteLine("Room added successfully!");
            Console.WriteLine($"Room {roomN} | {type} | Price; {price}");
            Console.WriteLine("Total rooms: "+ rooms.Count);
        }
    }
}
