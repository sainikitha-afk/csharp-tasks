using System;

public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public int Age { get; set; }

    public Student(string name, int grade, int age)
    {
        Name = name;
        Grade = grade;
        Age = age;
    }
}