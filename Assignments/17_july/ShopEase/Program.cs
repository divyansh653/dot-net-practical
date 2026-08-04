using System;
using ShopEase.Data;
using ShopEase.Services;

namespace ShopEase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load Sample Categories and Products
            SeedData.Initialize();

            // Create Service Objects
            AuthenticationService authService = new AuthenticationService();
            ProductService productService = new ProductService();
            CategoryService categoryService = new CategoryService();
            CartService cartService = new CartService();
            OrderService orderService = new OrderService(authService);
            PaymentService paymentService = new PaymentService();
            ReportService reportService = new ReportService();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("==============================================");
                Console.WriteLine("        SHOP EASE MANAGEMENT SYSTEM");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. Customer Registration");
                Console.WriteLine("3. Customer Login");
                Console.WriteLine("4. Exit");
                Console.WriteLine("==============================================");
                Console.Write("Enter Your Choice : ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("\nInvalid Input.");
                    Pause();
                    continue;
                }

                switch (choice)
                {
                    case 1:

                        if (authService.AdminLogin())
                        {
                            AdminMenu(
                                productService,
                                categoryService,
                                reportService);
                        }

                        Pause();
                        break;

                    case 2:

                        authService.Register();
                        Pause();
                        break;

                    case 3:

                        if (authService.CustomerLogin())
                        {
                            CustomerMenu(
                                authService,
                                productService,
                                cartService,
                                orderService,
                                paymentService);
                        }

                        Pause();
                        break;

                    case 4:

                        Console.Clear();
                        Console.WriteLine("==============================================");
                        Console.WriteLine(" Thank You For Using ShopEase");
                        Console.WriteLine("==============================================");
                        return;

                    default:

                        Console.WriteLine("\nInvalid Choice.");
                        Pause();
                        break;
                }
            }
        }

        //================ ADMIN MENU ===================

        static void AdminMenu(
            ProductService productService,
            CategoryService categoryService,
            ReportService reportService)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==============================================");
                Console.WriteLine("               ADMIN PANEL");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Category Management");
                Console.WriteLine("3. Reports");
                Console.WriteLine("4. Logout");
                Console.WriteLine("==============================================");

                Console.Write("Enter Choice : ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid Input.");
                    Pause();
                    continue;
                }

                switch (choice)
                {
                    case 1:

                        ProductMenu(productService);
                        break;

                    case 2:

                        CategoryMenu(categoryService);
                        break;

                    case 3:

                        reportService.ShowReport();
                        Pause();
                        break;

                    case 4:

                        Console.WriteLine("\nAdmin Logged Out Successfully.");
                        Pause();
                        return;

                    default:

                        Console.WriteLine("\nInvalid Choice.");
                        Pause();
                        break;
                }
            }
        }
                //================ PRODUCT MENU ===================

        static void ProductMenu(ProductService productService)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==============================================");
                Console.WriteLine("           PRODUCT MANAGEMENT");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Search By Category");
                Console.WriteLine("7. Search By Brand");
                Console.WriteLine("8. Sort By Price");
                Console.WriteLine("9. Sort By Rating");
                Console.WriteLine("10. Low Stock Products");
                Console.WriteLine("11. Back");
                Console.WriteLine("==============================================");

                Console.Write("Enter Choice : ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid Input.");
                    Pause();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        productService.AddProduct();
                        Pause();
                        break;

                    case 2:
                        productService.ViewAllProducts();
                        Pause();
                        break;

                    case 3:
                        productService.SearchProduct();
                        Pause();
                        break;

                    case 4:
                        productService.UpdateProduct();
                        Pause();
                        break;

                    case 5:
                        productService.DeleteProduct();
                        Pause();
                        break;

                    case 6:
                        productService.SearchByCategory();
                        Pause();
                        break;

                    case 7:
                        productService.SearchByBrand();
                        Pause();
                        break;

                    case 8:
                        productService.SortByPrice();
                        Pause();
                        break;

                    case 9:
                        productService.SortByRating();
                        Pause();
                        break;

                    case 10:
                        productService.LowStockProducts();
                        Pause();
                        break;

                    case 11:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Pause();
                        break;
                }
            }
        }

        //================ CATEGORY MENU ===================

        static void CategoryMenu(CategoryService categoryService)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==============================================");
                Console.WriteLine("          CATEGORY MANAGEMENT");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. View Categories");
                Console.WriteLine("3. Update Category");
                Console.WriteLine("4. Delete Category");
                Console.WriteLine("5. Back");
                Console.WriteLine("==============================================");

                Console.Write("Enter Choice : ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid Input.");
                    Pause();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        categoryService.AddCategory();
                        Pause();
                        break;

                    case 2:
                        categoryService.ViewCategories();
                        Pause();
                        break;

                    case 3:
                        categoryService.UpdateCategory();
                        Pause();
                        break;

                    case 4:
                        categoryService.DeleteCategory();
                        Pause();
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Pause();
                        break;
                }
            }
        }

         //================ CUSTOMER MENU ===================

                 static void CustomerMenu(
            AuthenticationService authService,
            ProductService productService,
            CartService cartService,
            OrderService orderService,
            PaymentService paymentService)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==============================================");
                Console.WriteLine($"      WELCOME {authService.LoggedInCustomer?.Name?.ToUpper()}");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Search Product");
                Console.WriteLine("3. Search By Category");
                Console.WriteLine("4. Search By Brand");
                Console.WriteLine("5. Sort By Price");
                Console.WriteLine("6. Sort By Rating");
                Console.WriteLine("7. Add To Cart");
                Console.WriteLine("8. View Cart");
                Console.WriteLine("9. Update Cart Quantity");
                Console.WriteLine("10. Remove From Cart");
                Console.WriteLine("11. Apply Coupon");
                Console.WriteLine("12. Checkout");
                Console.WriteLine("13. Place Order");
                Console.WriteLine("14. Make Payment");
                Console.WriteLine("15. View Orders");
                Console.WriteLine("16. Generate Invoice");
                Console.WriteLine("17. Logout");
                Console.WriteLine("==============================================");

                Console.Write("Enter Choice : ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid Input.");
                    Pause();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        productService.ViewAllProducts();
                        Pause();
                        break;

                    case 2:
                        productService.SearchProduct();
                        Pause();
                        break;

                    case 3:
                        productService.SearchByCategory();
                        Pause();
                        break;

                    case 4:
                        productService.SearchByBrand();
                        Pause();
                        break;

                    case 5:
                        productService.SortByPrice();
                        Pause();
                        break;

                    case 6:
                        productService.SortByRating();
                        Pause();
                        break;

                    case 7:
                        cartService.AddToCart();
                        Pause();
                        break;

                    case 8:
                        cartService.ViewCart();
                        Pause();
                        break;

                    case 9:
                        cartService.UpdateQuantity();
                        Pause();
                        break;

                    case 10:
                        cartService.RemoveFromCart();
                        Pause();
                        break;

                    case 11:
                        cartService.ApplyCoupon();
                        Pause();
                        break;

                    case 12:
                        orderService.Checkout();
                        Pause();
                        break;

                    case 13:
                        orderService.PlaceOrder();
                        Pause();
                        break;

                    case 14:
                        paymentService.MakePayment();
                        Pause();
                        break;

                    case 15:
                        orderService.ViewOrders();
                        Pause();
                        break;

                    case 16:
                        orderService.GenerateInvoice();
                        Pause();
                        break;

                    case 17:
                        authService.Logout();
                        Pause();
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Pause();
                        break;
                }
            }
        }
                //================ COMMON METHODS ===================

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("Press Any Key To Continue...");
            Console.WriteLine("==============================================");
            Console.ReadKey();
        }
    }
}