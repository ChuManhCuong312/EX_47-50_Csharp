using System;
using System.Globalization;

class Program
{
    // Hàm Generic để tìm giá trị nhỏ nhất trong mảng
    public static T FindMinValue<T>(T[] array) where T : IComparable<T>
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("Array không được rỗng.");
        }

        T minValue = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].CompareTo(minValue) < 0)
            {
                minValue = array[i];
            }
        }
        return minValue;
    }

    static void Main(string[] args)
    {
        // Đặt văn hóa hiện tại của luồng chính thành "en-US"
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        
        dynamic min_value;

        // Mảng số nguyên 4 byte
        int[] intArray = { 1, 2, 3, 4, 5 };
        min_value = FindMinValue(intArray);
        Console.WriteLine("Giá trị nhỏ nhất trong mảng số nguyên 4 byte: " + min_value.ToString());

        // Mảng số nguyên không dấu 4 byte
        uint[] uintArray = { 10, 20, 5, 30, 40 };
        min_value = FindMinValue(uintArray);
        Console.WriteLine("Giá trị nhỏ nhất trong mảng số nguyên không dấu 4 byte: " + min_value.ToString());

        // Mảng số thực 4 byte
        float[] floatArray = { 1.2f, 2.5f, -1.3f, 0.4f };
        min_value = FindMinValue(floatArray);
        Console.WriteLine("Giá trị nhỏ nhất trong mảng số thực 4 byte: " + min_value.ToString());

        // Mảng số thực 8 byte
        double[] doubleArray = { 1.23, 2.45, -1.78, 0.56 };
        min_value = FindMinValue(doubleArray);
        Console.WriteLine("Giá trị nhỏ nhất trong mảng số thực 8 byte: " + min_value.ToString());
    }
}
