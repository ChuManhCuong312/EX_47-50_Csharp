using System;
using System.Collections.Generic;
using System.Globalization;

class Student
{
    public string ID { get; set; }
    public float GPA { get; set; }
}

class Program
{
    static void Main()
    {
        // Đặt văn hóa hiện tại của luồng chính thành "en-US"
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        // Tạo danh sách để lưu trữ các đối tượng Student
        List<Student> students = new List<Student>();

        // Nhập thông tin sinh viên từ bàn phím
        while (true)
        {
            Console.Write("Nhập ID sinh viên (hoặc '#' để dừng): ");
            string id = Console.ReadLine();
            if (id == "#") break;

            float gpa;
            while (true)
            {
                Console.Write("Nhập điểm trung bình (GPA từ 0 đến 4): ");
                if (float.TryParse(Console.ReadLine(), out gpa) && gpa >= 0 && gpa <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Điểm trung bình không hợp lệ, vui lòng nhập lại (GPA phải từ 0 đến 4).");
                }
            }

            students.Add(new Student { ID = id, GPA = gpa });
        }

        // Tạo từ điển với khóa là ID và giá trị là GPA
        Dictionary<string, float> dict1 = new Dictionary<string, float>();
        foreach (var student in students)
        {
            dict1[student.ID] = student.GPA;
        }

        // Xác định điểm trung bình của sinh viên có ID là "123456"
        string targetID = "123456";
        if (dict1.TryGetValue(targetID, out float targetGPA))
        {
            Console.WriteLine($"Điểm trung bình của sinh viên có ID {targetID} là: {targetGPA}");
        }
        else
        {
            Console.WriteLine($"Không tìm thấy sinh viên có ID {targetID}.");
        }
    }
}
