using ClassLibrary;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

class Program
{
    static void Main()
    {
        List<Stage> project = new List<Stage>();
        WriteLine("выберети форму ввода:\n1 - ручной ввод\n2 - автоматический ввод");
        //ConsoleKeyInfo key = ReadKey();
        //Clear();
        //switch (key.KeyChar)
        //{
        //    case '1':

        //        WriteLine("Стадия Анализирования:\nВведите число сотрудников:");
                
        //        Analizing analizing1 = new Analizing(0, 0, 0);
        //        WriteLine("Введите финансы на стадию:");
        //        break;
        //    default:
        //        WriteLine("Введен некорректный символ, заполнено автоматически");
        //        break;
        //    case '2':
                Analizing analizing = new Analizing(10,5000,5);
                Projecting projecting = new Projecting(10,5000,5);
                Coding coding = new Coding(10,5000,5);
                Testing testing = new Testing(10,5000,5);
                Expluatation expluatation = new Expluatation(10,5000,5);
                project.Add(analizing); project.Add(projecting); project.Add(coding); project.Add(testing); project.Add(expluatation);
                foreach (var item in project)
                    WriteLine(item);
                WriteLine($"Итого затрачено на проект:{project[0].ExpensesForProject(project)}");
                //break;

        //}


    }
}
