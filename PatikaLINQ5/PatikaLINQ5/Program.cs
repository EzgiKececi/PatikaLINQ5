using PatikaLINQ5;
using System.ComponentModel.DataAnnotations.Schema;

public class Program
{
    public static void Main()
    {
        //Student sınıfından nesnelerle liste oluşturma
        var students = new List<Student>()
        {
            new Student {StudentId = 1, Name ="Ali", ClassId =1},
            new Student {StudentId = 2, Name ="Ayşe", ClassId =2},
            new Student {StudentId = 3, Name ="Mehmet", ClassId =1},
            new Student {StudentId = 4, Name ="Fatma", ClassId =3},
            new Student {StudentId = 5, Name = "Ahmet", ClassId=2},
        };


        //Class sınıfından nesnelerle liste oluşturma
        var classes = new List<Class>()
        {
            new Class {ClassId= 1, ClassName = "Matematik"},
            new Class {ClassId= 2, ClassName ="Türkçe" },
            new Class {ClassId= 3, ClassName= "Kimya" },
        };


        //Oluşturulan iki listeyi birleştirme

        var groupedStudents = classes.GroupJoin(students,
                                                c => c.ClassId,
                                                s => s.ClassId,
                                                (c, studentGroup) => new
                                                {
                                                    ClassName = c.ClassName,
                                                    Students = studentGroup
                                                });


        //Derslere göre gruplandırılan öğrencileri ekrana yazdırma

        foreach (var student in groupedStudents)
        {
            Console.WriteLine();
            Console.WriteLine(student.ClassName);
            Console.WriteLine("----------------");
            

            foreach (var item in student.Students)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}

      



    
