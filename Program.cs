using System.Diagnostics;
using System.Security.Cryptography;

List<Product> products = new List<Product>
{
 new Product { Id = 1, Name = "Product A", Category = "Category 1", Price = 100
},
 new Product { Id = 2, Name = "Product B", Category = "Category 2", Price = 150
},
 new Product { Id = 3, Name = "Product C", Category = "Category 1", Price = 120
},
 new Product { Id = 4, Name = "Product D", Category = "Category 3", Price = 200
},
 new Product { Id = 5, Name = "Product E", Category = "Category 2", Price = 80 }
};

/*
 * 1:بازیابی تمام دستورات از دسته بندی یک
 * 2:محصول با بالاترین قیمت
 * 3:مجموع قیمت تمام محصولات
 * 4:گروه بندی بر اساس دسته بندی
 * 5:میانگین
 */

//show all , select * from products
var allResult = (from p in products select p);
Console.WriteLine("All Results");
foreach (Product i in allResult)
{
    Console.WriteLine($"id : {i.Id} ,Name : {i.Name} ,Category : {i.Category} , Price : {i.Price}");
}
var count = (from p in products select p).Count();

Console.WriteLine("*********************************");

#region Q1
//*1 = filter Category
Console.WriteLine("All products in Category 1");
var res1 = (from p in products where p.Category == "Category 1" select p);
foreach (Product i in res1)
{
    Console.WriteLine($"id : {i.Id} ,Name : {i.Name} ,Category : {i.Category} , Price : {i.Price}");
}

Console.WriteLine("*********************************");
#endregion 

#region Q2
//*2 = order price then use an array to collect all prices
// then use the ordered price to find the highest price
Console.WriteLine("Show the most expensive product");
var res2 = (from p in products orderby p.Price descending select p);
int[] price = new int[count];
int j = 0;
foreach (Product i in res2)
{
    price[j] = i.Price;
    j++;
}
var res2_1 = (from p in products where p.Price == price[0] select p);


foreach (Product i in res2_1)
{
    Console.WriteLine($"id : {i.Id} ,Name : {i.Name} ,Category : {i.Category} , Price : {i.Price}");
}
// best way :
var res2_2 = (from p in products select p).Max(i => i.Price);
Console.WriteLine(res2_2);
Console.WriteLine("*********************************");
#endregion

#region Q3
//*3 = use the array of prices and give us sum usnig a loop
Console.WriteLine("sum :");
int sum = 0;
for (int i = 0; i < 5; i++)
{
    sum += price[i];
}
Console.WriteLine("sum is {0}", sum);
Console.WriteLine("another way to show sum :" + price.Sum());
// best way :
var res3 = (from p in products select p).Sum(i => i.Price);
Console.WriteLine(res3);
Console.WriteLine("*********************************");
#endregion

#region Q4
//*4 = Order the table by their Category
Console.WriteLine("Order the table by their Category");
var res4 = (from p in products orderby p.Category ascending select p);

foreach (Product i in res4)
{
    Console.WriteLine($"id : {i.Id} ,Name : {i.Name} ,Category : {i.Category} , Price : {i.Price}");
}

Console.WriteLine("*********************************");
#endregion

#region Q5
//*5 = fact : we know there is 5 products in list so we can use the sum
// variable and number of products to find the average.
// in case we dont know how many products we have ,
// we can simply add a counter on the first foreach loop wich shows 
// every thing we have in this list and find the number of executions
// also we can use count extention metod and make it more dynamic
Console.WriteLine("Average : ");
Console.WriteLine($"Average : {sum / 5}");
Console.WriteLine("another way to show Average :" + price.Average());
// best way :
var res5 = (from p in products select p).Average(i => i.Price);
Console.WriteLine(res5);
Console.WriteLine("*********************************");
#endregion

/*
References :
https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/introduction-to-linq-queries
https://dotnettutorials.net/lesson/list-collection-csharp/#:~:text=The%20Generic%20List%20in,which%20is%20starting%20from%200.
https://vintay.medium.com/c-linq-min-max-40f80f43267c
i tryed to show you how i think :) 
hope you enjoy reading this code
*/

Console.ReadKey();