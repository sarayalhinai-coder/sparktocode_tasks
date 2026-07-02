namespace _1_7_task_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter product code : ");
            int product = int.Parse(Console.ReadLine());

            Console.Write("enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("do you have a discount coupon? ");
            bool coupon = bool.Parse(Console.ReadLine());

            double unitPrice = 0;
            switch (product)
            {
                case 1:
                    unitPrice = 8.500;
                    break;
                case 2:
                    unitPrice = 12.000;
                    break;
                case 3:
                    unitPrice = 5.000;
                    break;
                default:
                    Console.WriteLine("Invalid product code");
                    break;
            }
            double subtotal = unitPrice * quantity;

            double discountAmount = 0;
            if (coupon == true && subtotal > 20)
            {
                discountAmount = subtotal * 0.10;
            }
            double amountAfterDiscount = subtotal - discountAmount;
            double taxAmount = amountAfterDiscount * 0.05;
            double finalTotal = amountAfterDiscount + taxAmount;

            Console.WriteLine("subtotal= " + subtotal);
            Console.WriteLine("discount amount= " + discountAmount);
            Console.WriteLine("tax amount= " + taxAmount);
            Console.WriteLine("final total= " + finalTotal);

        }
    }
}
