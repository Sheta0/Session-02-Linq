using System.Collections;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using static Demo_02.ListGenerator;
namespace Demo_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Revision
            // Implicitly Typed Local Variable [var - dynamic]

            //var x = 10;

            //dynamic x = 12; // like var in JS

            // Anonymous Type

            // Extension Methods

            // LINQ : 40+ Extension Methods

            //Console.WriteLine(ListGenerator.ProductList[0]);
            //Console.WriteLine(ListGenerator.CustomerList[0]); 
            #endregion

            #region 1. Filteration Operators - Where / OfType

            //////// Fluent Syntax
            //////var Result = ProductList.Where(P => P.UnitsInStock == 0);

            //////// Query Expression
            //////Result = from P in ProductList
            //////         where P.UnitsInStock == 0
            //////         select P;


            ////var Result = ProductList.Where(P => P.UnitsInStock > 0 && P.Category == "Meat/Poultry");

            ////Result = from P in ProductList
            ////         where P.UnitsInStock > 0 && P.Category == "Meat/Poultry"
            ////         select P;

            //////// Indexed Where
            //////// Valid only in Fluent Syntax. Can't be written using Query Expression
            ////var Result = ProductList.Where((P, I) => I < 10 && P.UnitsInStock == 0);

            ////var Result = ProductList.Where(P => P.UnitsInStock > 0).Where((P, I) => I < 5);

            //////// OfType

            //ArrayList arrayList = new ArrayList() { 1, 2, 3, "Ahmed", "ALi", 1.2, .5, 2.3m, 5.9f, ProductList[0], ProductList[1] };

            //var Result = arrayList.OfType<Product>();

            //foreach (var item in Result)
            //    Console.WriteLine(item);


            #endregion

            #region 2. Transformation Operators - Select / SelectMany

            //////////var Result = ProductList.Select(P => P);
            ////////var Result = ProductList.Select(P => P.ProductName);

            ////////Result = from P in ProductList
            ////////         select P.ProductName;

            //////var Result = ProductList.Where(P => P.UnitsInStock > 0 && P.Category == "Seafood")
            //////                        .Select(P => new
            //////                        {
            //////                            Name = P.ProductName,
            //////                            P.Category,
            //////                            OldPrice = P.UnitPrice,
            //////                            NewPrice = P.UnitPrice - P.UnitPrice * 0.1m
            //////                        });

            //////Result = from P in ProductList
            //////         where P.UnitsInStock > 0 && P.Category == "Seafood"
            //////         select new
            //////         {
            //////             Name = P.ProductName,
            //////             P.Category,
            //////             OldPrice = P.UnitPrice,
            //////             NewPrice = P.UnitPrice - P.UnitPrice * 0.1m
            //////         };

            ////var Result = CustomerList.SelectMany(C => C.Orders); // If the property is a sequence

            ////Result = from C in CustomerList
            ////         from O in C.Orders
            ////         select O;


            ////////////// Indexed Select
            ////////////// Valid only in Fluent Syntax. Can't be written using Query Expression
            //var Result = ProductList.Select((P, I) => new
            //                        {
            //                            Index = I,
            //                            Name = P.ProductName
            //                        })
            //                        .Where(P => P.Index < 5);


            //foreach (var item in Result)
            //    Console.WriteLine(item);

            #endregion

            #region 3. Ordering Operators

            ////var Result = ProductList.Where(P => P.Category == "Meat/Poultry")
            ////                        .OrderByDescending(P => P.UnitsInStock)
            ////                        .ThenBy(P => P.UnitPrice)
            ////                        .ThenByDescending(P => P.ProductName)
            ////                        .Select(P => new
            ////                        {
            ////                            P.ProductName,
            ////                            P.UnitsInStock,
            ////                            P.UnitPrice
            ////                        });

            ////Result = from P in ProductList
            ////         where P.Category == "Meat/Poultry"
            ////         orderby P.UnitsInStock descending, P.UnitPrice, P.ProductName descending
            ////         select new
            ////         {
            ////             P.ProductName,
            ////             P.UnitsInStock,
            ////             P.UnitPrice
            ////         };

            //var Result = ProductList.Where(P => P.UnitsInStock == 0).Reverse();

            //foreach (var item in Result)
            //    Console.WriteLine(item);

            #endregion

            #region 4. Elements Operators - Immediate Execution
            // Valid only in Fluent Syntax

            //////var Result = ProductList.First();
            ////Result = ProductList.Last();

            //ProductList = new List<Product>();

            //////var Result = ProductList.First(); // Exception : Sequence Contains No Elements
            ////////Result = ProductList.Last(); // Exception : Sequence Contains No Elements

            //////var Result = ProductList.First(P => P.UnitsInStock == 1000); // Exception : Sequence Contains No Matching Element
            //////var Result = ProductList.Last(P => P.UnitsInStock == 0);

            ////var Result = ProductList.FirstOrDefault(P => P.UnitsInStock == 0);
            ////Result = ProductList.FirstOrDefault(new Product { ProductName = "Default Product"});
            ////Result = ProductList.FirstOrDefault();
            ////Result = ProductList.FirstOrDefault(P => P.UnitsInStock == 110, new Product { ProductName = "Default Product" });

            //var Result = ProductList.LastOrDefault(P => P.UnitsInStock == 0);
            //Result = ProductList.LastOrDefault(new Product { ProductName = "Default Product"});
            //Result = ProductList.LastOrDefault();
            //Result = ProductList.LastOrDefault(P => P.UnitsInStock == 110, new Product { ProductName = "Default Product" });


            ////var Result = ProductList.ElementAt(1000); // Throw Exception if Index is Out of Range
            //var Result = ProductList.ElementAtOrDefault(1000); // Return Default Value if Index is Out of Range

            //List<Product> Products = new List<Product>() { new Product() { ProductID = 2, ProductName = "Haerin" } };

            ////var Result = Products.Single();
            ////Result = ProductList.Single(P => P.ProductID == 1);
            ////Result = ProductList.Single();
            ///////// If Sequence Contains Only One Element, Will Return it
            ///////// Else Will throw an Exception (Sequence is Empty or Contains More than One Element)

            ////var Result = Products.SingleOrDefault();
            ////var Result = ProductList.SingleOrDefault();
            ////var Result = ProductList.SingleOrDefault(P => P.UnitsInStock == 0);
            ////var Result = ProductList.SingleOrDefault(new Product { ProductName = "Rose"});
            //var Result = ProductList.SingleOrDefault(P => P.UnitsInStock == 0, new Product { ProductName = "Rose" });
            //var Result = ProductList.SingleOrDefault(P => P.ProductID == 1, new Product { ProductName = "Rose" });
            //var Result = ProductList.SingleOrDefault(P => P.ProductID == 1000, new Product { ProductName = "Rose" });
            ///////////// If Sequence is Empty, Will Return Default Value (Null)
            ///////////// If Sequence Contains Only One Element, Will Return it
            ///////////// If Sequence Contains More Than One Element, Throw Exception

            //var result = ProductList.DefaultIfEmpty();
            //result = ProductList.DefaultIfEmpty(new Product { ProductName = "Default Product" });

            //foreach (var item in result)
            //    Console.WriteLine(item);

            ////Console.WriteLine(Result?.ProductName ?? "NA");

            #endregion

            #region 5. Aggregate Operators - Immediate Execution

            // Count - Sum - Max - Min - Avg

            //////////var Result = ProductList.Count(); // 77
            //////////Result = ProductList.Count; // 77

            ////////var Result = ProductList.Count(P => P.UnitsInStock == 0);

            //////var Result = ProductList.Sum(P => P.UnitPrice);
            //////Result = ProductList.Sum(P => P.UnitsInStock);

            ////var Result = ProductList.Average(P => P.UnitPrice);

            //var Result = ProductList.Max(); // Based on IComparable
            //Result = ProductList.Min();

            //var Result = ProductList.Max(new ProductCompareUnitsInStock()); // Based on IComparer
            //Result = ProductList.Min(new ProductCompareUnitsInStock());

            //var MinLength = ProductList.Min(P => P.ProductName.Length);
            //Console.WriteLine(MinLength);

            //var MaxLength = ProductList.Max(P => P.ProductName.Length);
            //Console.WriteLine(MaxLength);

            //var Result = ProductList.SingleOrDefault(P => P.UnitPrice == MaxLength);

            //var Result = ProductList.MaxBy(P => P.UnitPrice);
            //Result = ProductList.MinBy(P => P.UnitPrice);
            //Result = ProductList.MaxBy(P => P.ProductName, new ProductCompareNameLength());

            //// Aggregate
            //string[] Names = { "Ahmed", "Ali", "Omar", "Osama" };
            //var Result = Names.Aggregate((S01, S02) => $"{S01} {S02}");

            //Console.WriteLine(Result);

            #endregion

            #region 6. Casting Operator - Immediate Execution

            //List<Product> result = ProductList.Where(P => P.UnitsInStock == 0).ToList();

            //Product[] result = ProductList.Where(P => P.UnitsInStock == 0).ToArray();

            //Dictionary<long, Product> result = ProductList.Where(P => P.UnitsInStock == 0)
            //                                             .ToDictionary(P => P.ProductID);

            //Dictionary<long, string> result = ProductList.Where(P => P.UnitsInStock == 0)
            //                                             .ToDictionary(P => P.ProductID, P => P.ProductName);

            //HashSet<Product> result = ProductList.Where(P => P.UnitsInStock == 0).ToHashSet();

            //foreach (var item in result)
            //    Console.WriteLine(item);

            #endregion

            #region 7. Generation Operators
            ////////// The only way to call them is as class member methods of the Enumerable class
            ////////// Range - Repeat - Empty

            ////////var Result = Enumerable.Range(1, 100); // 1 => 100

            //////Result = Enumerable.Repeat(1, 100); // 1 , 1 , 1 , 1 , ..... 100 times

            ////var Result = Enumerable.Empty<Product>().ToList(); // Empty Sequence
            ////Result.Add(new Product() { ProductName = "Product01"});
            ////Result.Add(new Product() { ProductName = "Product02"});

            //var Result = Enumerable.Repeat(ProductList[0], 10); // 10 products

            //foreach (var item in Result)
            //    Console.WriteLine(item);
            #endregion

            #region 8. Set Operators - Union Family

            //var Seq01 = Enumerable.Range(1, 100); // 1 => 100
            //var Seq02 = Enumerable.Range(50, 100); // 50 => 149

            //var Result = Seq01.Union(Seq02); // 1 => 149 Without Duplicates
            //Result = Seq01.Concat(Seq02); // 1 => 10 , 50 => 149 With Duplicates
            //Result = Result.Distinct(); // 1 => 149 Remove Duplicates
            //Result = Seq01.Intersect(Seq02); // 50 => 100
            //Result = Seq01.Except(Seq02); // 1 => 50
            //Result = Seq02.Except(Seq01); // 101 => 149

            //foreach (var item in Result)
            //    Console.Write($"{item} ");

            #endregion

            #region 9. Quantifier Operator - Return Boolean

            // Any - All - SequenceEqual - Contains

            //var Seq01 = Enumerable.Range(1, 100); // 1 => 100
            //var Seq02 = Enumerable.Range(1, 100); // 50 => 149

            //ProductList = new List<Product>();

            //// Any() => Return True if At least one element in the sequence matches the condition

            //var result = Seq01.Any();
            //result = ProductList.Any();
            //result = Seq01.Any(N => N > 100);
            //result = ProductList.Any(P => P.UnitsInStock == 0);

            //// All() => Return True if All elements in the sequence matches the condition or the sequence is empty

            //var result = Seq01.All(N => N > 0);
            //result = ProductList.All(P => P.UnitsInStock == 0);

            //// SequenceEqual() => Return True if Two Sequences are Equal

            //var result = Seq01.SequenceEqual(Seq02);

            //var result = Seq01.Contains(50);

            //Console.WriteLine(result);

            #endregion

            #region 10. Zipping Opertator - Zip

            //List<string> Words = new List<string> { "Ten", "Twenty", "Thirty", "Fourty" };
            //List<int> Numbers = new List<int> { 10, 20, 30, 40, 50 };

            ////var Result = Words.Zip(Numbers, (W, N) => $"{N} => {W}");
            //var Result = Words.Zip(Numbers, (W, N) => new { Num = N, Word = W});

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 11. Grouping Operators

            ////var result = ProductList.GroupBy(P => P.Category);

            ////result = from P in ProductList
            ////         group P by P.Category;


            ////foreach (var category in result)
            ////{
            ////    Console.WriteLine(category.Key);
            ////    foreach (var product in category)
            ////        Console.WriteLine($"..............{product.ProductName}");
            ////}

            //var Result = from P in ProductList
            //             where P.UnitsInStock > 0
            //             group P by P.Category
            //             into C
            //             where C.Count() > 10
            //             select new { CategoryName = C.Key, Count = C.Count() };

            //Result = ProductList.Where(p => p.UnitsInStock > 0)
            //                    .GroupBy(p => p.Category)
            //                    .OrderByDescending(c => c.Count())
            //                    .Where(c => c.Count() > 10)
            //                    .Select(c => new { CategoryName = c.Key, Count = c.Count() });

            //foreach (var item in Result)
            //    Console.WriteLine(item);


            #endregion

            #region 12. Partitioning Operators - Take, TakeLast, Skip, SkipLast, TakeWhile, SkipWhile

            ////////var Result = ProductList.Where(P => P.UnitsInStock == 0).Take(2); 
            ////////Result = ProductList.TakeLast(5); 

            //////var Result = ProductList.Skip(2).Take(5);
            //////Result = ProductList.SkipLast(count: 20);

            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            ////var Result = numbers.TakeWhile(N => N % 3 != 0);
            ////Result = numbers.SkipWhile(N => N % 3 != 0);

            //var Result = numbers.TakeWhile((N, I) => N > I);
            //Result = numbers.SkipWhile((N, I) => N > I);

            //foreach (var item in Result)
            //    Console.WriteLine(item);

            #endregion

            #region Let / Into
            //// Query Syntax
            ////// aeiouAEIOU

            //List<string> Names = new List<string>() { "Ahmed", "Ali", "Haerin", "Rana", "Omar", "Mohamed" };

            //var Result = from N in Names
            //             select Regex.Replace(N, "[aeiouAEIOU]", string.Empty)
            //             // into : Restart Query with introducing new range variable : NoVolName
            //             into NoVolName
            //             where NoVolName.Length >= 3
            //             select NoVolName;

            //Result = from N in Names
            //         let NoVolName = Regex.Replace(N, "[aeiouAEIOU]", string.Empty)
            //         // Let : Continue Query with Adding new range variable : NoVolName
            //         where NoVolName.Length >= 3
            //         select NoVolName;

            //foreach (var item in Result)
            //    Console.WriteLine(item);

            #endregion
        }
    }
}
