using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using static Assignment_02.ListGenerators;
namespace Assignment_02
{
    class StringInsensitiveComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (x is null || y is null)
                return 0;
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
            

    }

    class SameCharactersComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x == null || y == null) return false;

            return string.Concat(x.OrderBy(c => c)) == String.Concat(y.OrderBy(c => c));
        }

        public int GetHashCode(string obj)
        {
            if (obj == null) return 0;

            return string.Concat(obj.OrderBy(c => c)).GetHashCode();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "dictionary_english.txt");
            string[] dictionaryWords = File.ReadAllLines(filePath);

            #region LINQ - Restriction Operators

            #region 1
            //var result = ProductList.Where(P => P.UnitsInStock == 0); 
            #endregion

            #region 2
            //var result = ProductList.Where(P => P.UnitsInStock > 0 && P.UnitPrice > 3.0m); 
            #endregion

            #region 3
            //String[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var result = Arr.Where((N, I) => N.Length < I); 
            #endregion

            //foreach (var item in result)
            //    Console.WriteLine(item);

            #endregion

            #region LINQ - Element Operators
            #region 1
            //var result = ProductList.First(P => P.UnitsInStock == 0); 
            #endregion

            #region 2
            //var result = ProductList.FirstOrDefault(P => P.UnitPrice > 1000); 
            #endregion

            #region 3
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var result = Arr.Where(N => N > 5).Skip(1).First(); 
            #endregion

            //Console.WriteLine(result); 
            #endregion

            #region LINQ - Aggregate Operators
            #region 1
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var result = Arr.Count(N => N % 2 != 0);

            //Console.WriteLine(result);
            #endregion

            #region 2
            //var result = CustomerList.Select(C => new { C.CustomerName, OrderCount = C.Orders.Count() });

            //foreach (var item in result)
            //    Console.WriteLine(item); 
            #endregion

            #region 3
            //var result = ProductList.GroupBy(P => P.Category).Select(C => new { Category = C.Key, ProductCount = C.Count() });

            //foreach(var item in result)
            //    Console.WriteLine(item); 
            #endregion

            #region 4
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var result = Arr.Sum();

            //Console.WriteLine(result); 
            #endregion

            #region 5

            //int result = dictionaryWords.Sum(word => word.Count());

            //Console.WriteLine(result); 
            #endregion

            #region 6

            //var result = dictionaryWords.Min(word => word.Count());

            //Console.WriteLine(result);

            #endregion

            #region 7
            //var result = dictionaryWords.Max(word => word.Length);

            //Console.WriteLine(result); 
            #endregion

            #region 8
            //var result = dictionaryWords.Average(word => word.Count());

            //Console.WriteLine(result);  
            #endregion

            #region 9
            //var result = ProductList.GroupBy(P => P.Category)
            //                        .Select(C => new { Category = C.Key, UnitsInStock = C.Sum(P => P.UnitsInStock) });

            //foreach (var item in result)
            //    Console.WriteLine(item); 
            #endregion

            #region 10
            //var result = ProductList.GroupBy(P => P.Category)
            //                        .Select(C => new { Category = C.Key, MinPrice = C.Min(P => P.UnitPrice) });

            //foreach (var item in result)
            //    Console.WriteLine(item); 
            #endregion

            #region 11
            //var result = from P in ProductList
            //             group P by P.Category into C
            //             let MinPrice = C.Min(P => P.UnitPrice)
            //             select new { Category = C.Key, CheapestProduct = C.First(P => P.UnitPrice == MinPrice) };

            //foreach (var item in result)
            //    Console.WriteLine(item); 
            #endregion

            #region 12
            //var result = ProductList.GroupBy(P => P.Category)
            //                        .Select(C => new { Category = C.Key, MaxPrice = C.Max(P => P.UnitPrice) });

            //foreach (var item in result)
            //    Console.WriteLine(item); 
            #endregion

            #region 13
            //var result = ProductList.GroupBy(P => P.Category)
            //                        .Select(C => new { Category = C.Key, MostExpensiveProduct = C.MaxBy(P => P.UnitPrice) });

            //foreach (var item in result)
            //    Console.WriteLine(item); 
            #endregion

            #region 14
            //var result = ProductList.GroupBy(P => P.Category)
            //                        .Select(C => new { Category = C.Key, MaxPrice = C.Average(P => P.UnitPrice) });

            //foreach (var item in result)
            //    Console.WriteLine(item);  
            #endregion

            #endregion

            #region LINQ - Ordering Operators

            #region 1
            //var result = ProductList.OrderBy(P => P.ProductName); 
            #endregion

            #region 2
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var result = Arr.OrderBy(W => W, new StringInsensitiveComparer());
            #endregion

            #region 3
            //var result = ProductList.OrderByDescending(P => P.UnitsInStock); 
            #endregion

            #region 4
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var result = Arr.OrderBy(N => N.Length).ThenBy(N => N);
            #endregion

            #region 5
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var result = Arr.OrderBy(W => W.Length).ThenBy(W => W, new StringInsensitiveComparer()); 
            #endregion

            #region 6
            //var result = ProductList.OrderBy(P => P.Category).ThenByDescending(P => P.UnitPrice); 
            #endregion

            #region 7
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var result = Arr.OrderBy(W => W.Length).ThenByDescending(W => W, new StringInsensitiveComparer()); 
            #endregion

            #region 8
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var result = Arr.Where(word => word.Length > 1 && word[1] == 'i').Reverse().ToList();
            #endregion

            //foreach (var item in result)
            //    Console.WriteLine(item);
            #endregion

            #region LINQ – Transformation Operators

            #region 1
            //var result = ProductList.Select(P => P.ProductName); 
            #endregion

            #region 2
            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //var result = words.Select(W => new { uppercase = W.ToUpper(), lowercase = W.ToLower() }); 
            #endregion

            #region 3
            //var result = ProductList.Select(P => new { P.ProductID, P.ProductName, Price = P.UnitPrice }); 
            #endregion

            #region 4
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var result = Arr.Select((N, I) => $"{N}: {(N == I)}");

            //Console.WriteLine("Number: In-place?"); 
            #endregion

            #region 5
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var result = numbersA.SelectMany(A => numbersB, (A, B) => new { A, B }).Where(N => N.A < N.B);

            //Console.WriteLine("Pairs where a < b");

            //foreach (var item in result)
            //    Console.WriteLine($"{item.A} is less than {item.B}"); 
            #endregion

            #region 6
            //var result = CustomerList.SelectMany(C => C.Orders).Where(O => O.Total < 500); 
            #endregion

            #region 7
            //var result = CustomerList.SelectMany(C => C.Orders).Where(O => O.OrderDate >= new DateTime(1998,1,1)); 
            #endregion

            //foreach (var item in result)
            //    Console.WriteLine(item);

            #endregion

            #region LINQ - Set Operators

            #region 1
            //var result = ProductList.Select(P => P.Category).Distinct(); 
            #endregion

            #region 2
            //var result = ProductList.Select(P => P.ProductName[0])
            //                        .Union(CustomerList.Select(C => C.CustomerName[0])); 
            #endregion

            #region 3
            //var result = ProductList.Select(P => P.ProductName[0])
            //                        .Intersect(CustomerList.Select(C => C.CustomerName[0]));  
            #endregion

            #region 4
            //var result = ProductList.Select(P => P.ProductName[0])
            //                        .Except(CustomerList.Select(C => C.CustomerName[0]));  
            #endregion

            #region 5
            //var result = ProductList.Select(P => P.ProductName.Substring(Math.Max(0, P.ProductName.Length - 3)))
            //            .Concat(CustomerList.Select(C => C.CustomerName.Substring(Math.Max(0, C.CustomerName.Length - 3)))); 
            #endregion

            //foreach (var item in result)
            //    Console.WriteLine(item);

            #endregion

            #region LINQ - Partitioning Operators

            #region 1
            //var result = CustomerList.Where(C => C.City == "Washington").SelectMany(C => C.Orders).Take(3); 
            #endregion

            #region 2
            //var result = CustomerList.Where(C => C.City == "Washington").SelectMany(C => C.Orders).Skip(3); 
            #endregion

            #region 3
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = numbers.TakeWhile((N, I) => N >= I); 
            #endregion

            #region 4
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = numbers.SkipWhile(N => N % 3 != 0); 
            #endregion

            #region 5
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = numbers.SkipWhile((N, I) => N > I); 
            #endregion


            //foreach (var item in result)
            //    Console.WriteLine(item);

            #endregion

            #region LINQ - Quantifiers

            #region 1
            //var result = dictionaryWords.Any(word => word.Contains("ei")); 

            //Console.WriteLine(result);
            #endregion

            #region 2
            //var result = ProductList.GroupBy(P => P.Category)
            //                        .Where(C => C.Any(P => P.UnitsInStock == 0));

            //foreach( var group in result ) 
            //{
            //    Console.WriteLine(group.Key);
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine(product);
            //    }
            //}
            #endregion

            #region 3
            //var result = ProductList.GroupBy(P => P.Category)
            //                        .Where(C => C.All(P => P.UnitsInStock > 0));

            //foreach (var group in result)
            //{
            //    Console.WriteLine(group.Key);
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine(product);
            //    }
            //}

            #endregion

            #endregion

            #region Grouping Operators

            #region 1
            //List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            //var result = numbers.GroupBy(N => N % 5);

            //foreach (var group in result)
            //{
            //    Console.WriteLine($"Numbers with a remainder of {group.Key} when divided by 5:");
            //    foreach (var number in group)
            //        Console.WriteLine(number);
            //} 
            #endregion

            #region 2
            //var result = dictionaryWords.GroupBy(word => word[0]);

            //foreach (var group in result)
            //{
            //    Console.WriteLine($"Words that start with the letter '{group.Key}':");
            //    foreach (var word in group)
            //        Console.WriteLine(word);
            //} 
            #endregion

            #region 3
            //string[] Arr = { "from", "salt", "earn", "last", "near", "form" };

            //var result = Arr.GroupBy(word => word, new SameCharactersComparer());

            //foreach (var group in result)
            //{
            //    foreach (var word in group)
            //        Console.WriteLine(word);

            //    Console.WriteLine("....");
            //} 
            #endregion

            #endregion
        }
    }
}
