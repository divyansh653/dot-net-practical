// customer Registration and login system
// Allows Customer to Login anf REgister

using System;
using System.Collections.Generic;
class Program{

static void Main(string[] args){
                        
               // Object create to call Customer Class
               Customer customer=new Customer();

               Console.WriteLine("=======Cutomer Registartion=======");         
               
               Console.WriteLine("Enter the customer ID:");
               customer.CustomerID=Convert.ToInt32(Console.ReadLine());

               Console.WriteLine("Enter the customer Name:");
               customer.Name=Console.ReadLine() ?? "";

               Console.WriteLine("Enter the Email Address:");
               customer.Email=Console.ReadLine() ?? "";

               Console.WriteLine("Enter the Passward:");
               customer.Password=Console.ReadLine() ?? "";

               Console.WriteLine("\n=======Registration Complete========");
               Console.WriteLine("\n=======Customer login=======");

               int attempts=0;
               bool loginSuccess=false;

               while(attempts<3){
                                 Console.Write("Enter the Email Address");
                                 string email=Console.ReadLine() ?? "";

                                 Console.Write("Enter the passward");
                                 string password=Console.ReadLine() ?? "";
                if(email==customer.Email && password==customer.Password){
                                   Console.WriteLine("\nWelcome"+customer.Name);
                                   loginSuccess=true;
                                   break;
                }
                 else{
                       attempts++;
                       Console.WriteLine("Invalid Email or Password");

                if (attempts < 3)
                {
                    Console.WriteLine("Attempts Left : " + (3 - attempts));
                }
            }
        }

if (loginSuccess){

    List<Product> products = new List<Product>();

    Console.Write("How many products do you want to add? ");
    int count = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < count; i++)
    {
        Product product = new Product();

        Console.Write("Enter Product ID : ");
        product.ProductId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Product Name : ");
        product.ProductName = Console.ReadLine() ?? "";

        Console.Write("Enter Price : ");
        product.Price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Stock : ");
        product.Stock = Convert.ToInt32(Console.ReadLine());

        products.Add(product);
    }

    Console.WriteLine("\n===== PRODUCT LIST =====");

    foreach (Product product in products)
    {
        Console.WriteLine($"ID    : {product.ProductId}");
        Console.WriteLine($"Name  : {product.ProductName}");
        Console.WriteLine($"Price : {product.Price}");
        Console.WriteLine($"Stock : {product.Stock}");
        Console.WriteLine();
    }
    // ---------------- SEARCH PRODUCT ----------------

Console.WriteLine("\n========== SEARCH PRODUCT ==========");

Console.Write("Enter Product Name to Search: ");
string searchName = Console.ReadLine() ?? "";

bool found = false;

foreach (Product product in products)
{
    if (product.ProductName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("\nProduct Found");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Product ID   : " + product.ProductId);
        Console.WriteLine("Product Name : " + product.ProductName);
        Console.WriteLine("Price        : " + product.Price);
        Console.WriteLine("Stock        : " + product.Stock);

        found = true;
        break;
    }
}

if (!found)
{
    Console.WriteLine("\nProduct Not Found");
}
// ---------------- SHOPPING CART ----------------

List<CartItem> cart = new List<CartItem>();

int choice;

do
{
    Console.WriteLine("\n========== PRODUCT LIST ==========");

    foreach (Product product in products)
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Product ID   : " + product.ProductId);
        Console.WriteLine("Product Name : " + product.ProductName);
        Console.WriteLine("Price        : " + product.Price);
        Console.WriteLine("Stock        : " + product.Stock);
    }

    Console.Write("\nEnter Product ID: ");
    int productId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter Quantity: ");
    int quantity = Convert.ToInt32(Console.ReadLine());

    bool productFound = false;

    foreach (Product product in products)
    {
        if (product.ProductId == productId)
        {
            productFound = true;

            if (quantity <= product.Stock)
            {
                CartItem item = new CartItem();

                item.ProductName = product.ProductName;
                item.Quantity = quantity;
                item.Price = product.Price;

                cart.Add(item);

                product.Stock -= quantity;

                Console.WriteLine("Product Added to Cart Successfully.");
            }
            else
            {
                Console.WriteLine("Insufficient Stock.");
            }

            break;
        }
    }

    if (!productFound)
    {
        Console.WriteLine("Invalid Product ID.");
    }

    Console.WriteLine("\nDo you want to add another product?");
    Console.WriteLine("1. Yes");
    Console.WriteLine("2. No");
    choice = Convert.ToInt32(Console.ReadLine());

} while (choice == 1);
Console.WriteLine("\n========== YOUR CART ==========");

double totalAmount = 0;

foreach (CartItem item in cart)
{
    double amount = item.Price * item.Quantity;

    Console.WriteLine(item.ProductName + " x" + item.Quantity +
                      " = ₹" + amount);

    totalAmount += amount;
}

Console.WriteLine("------------------------------");
Console.WriteLine("Total Amount = ₹" + totalAmount);


// ---------------- DISCOUNT ----------------

double discountPercentage = 0;
double discountAmount = 0;
double finalAmount = 0;

if (totalAmount < 1000)
{
    discountPercentage = 0;
}
else if (totalAmount >= 1000 && totalAmount <= 4999)
{
    discountPercentage = 10;
}
else if (totalAmount >= 5000 && totalAmount <= 9999)
{
    discountPercentage = 20;
}
else
{
    discountPercentage = 30;
}

discountAmount = totalAmount * discountPercentage / 100;
finalAmount = totalAmount - discountAmount;

Console.WriteLine("\n========== BILL DETAILS ==========");
Console.WriteLine("Total Amount    : ₹" + totalAmount);
Console.WriteLine("Discount (" + discountPercentage + "%) : ₹" + discountAmount);
Console.WriteLine("Final Amount    : ₹" + finalAmount);

// ---------------- PAYMENT ----------------

Console.WriteLine("\n========== PAYMENT ==========");

Console.WriteLine("Choose Payment Method");
Console.WriteLine("1. UPI");
Console.WriteLine("2. Credit Card");
Console.WriteLine("3. Debit Card");
Console.WriteLine("4. Cash on Delivery");

Console.Write("Enter Your Choice: ");
int paymentChoice = Convert.ToInt32(Console.ReadLine());

switch (paymentChoice)
{
    case 1:
        Console.WriteLine("\nPayment Successful");
        Console.WriteLine("Payment Mode : UPI");
        break;

    case 2:
        Console.WriteLine("\nPayment Successful");
        Console.WriteLine("Payment Mode : Credit Card");
        break;

    case 3:
        Console.WriteLine("\nPayment Successful");
        Console.WriteLine("Payment Mode : Debit Card");
        break;

    case 4:
        Console.WriteLine("\nPayment Successful");
        Console.WriteLine("Payment Mode : Cash on Delivery");
        break;

    default:
        Console.WriteLine("\nInvalid Option");
        break;
}

}

else
{
    Console.WriteLine("Account Locked");
}
    }
}


