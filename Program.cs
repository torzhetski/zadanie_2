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
        ConsoleKeyInfo key = ReadKey();
        Clear();
        switch (key.KeyChar)
        {
            case '1':

                WriteLine("Стадия Анализирования:\nВведите число сотрудников:");
                uint number = Convert.ToUInt32(ReadLine());
                Analizing analizing1 = new Analizing(0, 0, number);
                analizing1 = (Analizing)Fill(analizing1);
                WriteLine("Введите сферу проекта:");
                analizing1.NameOfSphere = ReadLine();
                WriteLine("Стадия Проектирования:\nВведите число сотрудников:");
                 number = Convert.ToUInt32(ReadLine());
                Projecting projecting1 = new Projecting(0, 0, number);
                projecting1 = (Projecting)Fill(projecting1);
                WriteLine("Введите количество файлов проекта:");
                projecting1.NumberOfFiles = Convert.ToUInt32(ReadLine());
                WriteLine("Стадия Кодирования:\nВведите число сотрудников:");
                 number = Convert.ToUInt32(ReadLine());
                Coding coding1 = new Coding(0, 0, number);
                coding1 = (Coding)Fill(coding1);
                WriteLine("Введите количество строк кода:");
                coding1.NumberOfLines = Convert.ToUInt32(ReadLine());
                WriteLine("Стадия Тестирования:\nВведите число сотрудников:");
                 number = Convert.ToUInt32(ReadLine());
                Testing testing1 = new Testing(0, 0, number);
                testing1 = (Testing)Fill(testing1);
                WriteLine("Введите количество найденных багов:");
                testing1.NumberOfBugs = Convert.ToUInt32(ReadLine());
                WriteLine("Стадия экспулатации:\nВведите число сотрудников:");
                 number = Convert.ToUInt32(ReadLine());
                Expluatation expluatation1 = new Expluatation(0, 0, number);
                expluatation1 = (Expluatation)Fill(expluatation1);
                WriteLine("Введите год до которого будет осуществляться поддержка:");
                expluatation1.SupportPeriod = new DateTime(Convert.ToInt32(ReadLine()),1,1);
                break;
            default:
                WriteLine("Введен некорректный символ, заполнено автоматически");
                break;
            case '2':
                Analizing analizing = new Analizing(10,5000,5);
                Projecting projecting = new Projecting(10,5000,5);
                Coding coding = new Coding(10,5000,5);
                Testing testing = new Testing(10,5000,5);
                Expluatation expluatation = new Expluatation(10,5000,5);
                project.Add(analizing); project.Add(projecting); project.Add(coding); project.Add(testing); project.Add(expluatation);
                foreach (var item in project)
                    WriteLine(item);
                WriteLine($"Итого затрачено на проект:{project[0].ExpensesForProject(project)}");
                break;

        }
    }

    public static Stage Fill(Stage stage)
    {
        WriteLine("Введите срок выполнения стадии:");
        stage.DueTime = Convert.ToUInt32(ReadLine());
        WriteLine("Введите финансы на стадию:");
        stage.Finance = Convert.ToUInt32(ReadLine());
        stage.Team = 0;
        return stage;
    }
}
