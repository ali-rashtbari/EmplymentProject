

int[] arr1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

Span<int> arr2 = arr1.AsSpan();

void ManipulateArr(Span<int> intsSpan)
{
    intsSpan[0] = 10;
}


foreach (var intValue in arr1)
{
    Console.Write(intValue);
}
Console.WriteLine("\n-----------");
ManipulateArr(arr1);
foreach (int intValue in arr1)
{
    Console.Write(intValue);
}



