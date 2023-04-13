using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ClassLibrary
{
    public abstract class Stage
    {
        protected uint dueTime;
        protected uint finance;
        protected string name;
        protected List<Worker> team = new List<Worker>();

        public Stage(uint dueTime, uint finance, uint number, bool salary)
        {
            this.dueTime = dueTime;
            this.finance = finance;
            if (salary)
                for (int i = 0; i < number; i++)
                {
                    WriteLine($"Введите зарплату {i + 1}-го человека");
                    string helper = ReadLine(); Worker worker = new Worker();
                    if (uint.TryParse(helper, out var result))
                    {
                        worker.Salary = result;
                        team.Add(worker);
                    }
                    else
                    {
                        WriteLine("Введите допустимое значение");
                        i--;
                    }
                }
            else
                team = Worker.SetTeam(number);
        }
        public uint DueTime
        {
            get { return dueTime; }
            set { dueTime = value; }
        }
        public uint Team
        {
            get
            {
                int i = 0;
                do
                {
                    i++;
                    return team[i].Salary;
                }
                while (i < team.Count());
            }
            set
            {
                for (int i = 0; i < team.Count(); i++)
                {
                    WriteLine($"Введите зарплату {i + 1}-го человека");
                    string helper = ReadLine();
                    if (uint.TryParse(helper, out var result))
                        team[i].Salary = result;
                    else
                    {
                        WriteLine("Введите допустимое значение");
                        i--;
                    }
                }


            }
        }
        public uint Finance
        {
            get { return finance; }
            set { finance = value; }
        }
        public uint ExpensesForProject(List<Stage> project)
        {
            uint sum = 0;
            foreach (var item in project)
                sum += ExpensesForStsge(item);
            return sum;
        }
        public uint ExpensesForStsge(Stage stage)
        {
            uint sum = stage.finance;
            for (int i = 0; i < stage.team.Count(); i++)
                sum += team[i].Salary;
            return sum;
        }
        public override string ToString()
        {
            return $"Название стадии:{name}\nСрок сдачи: {dueTime}\nФинансы: {finance}\nЧисло сотрудников: {team.Count()}";
        }

    }

    public class Analizing : Stage
    {
        private string nameOfSphere;
        public string NameOfSphere
        {
            get { return nameOfSphere; }
            set { nameOfSphere = value; }
        }
        public Analizing(uint dueTime, uint finance, uint number, bool salary, string nameOfSphere) : base(dueTime, finance, number, salary)
        {
            name = "Analizing";
            this.nameOfSphere = nameOfSphere;
        }
        public Analizing(uint dueTime, uint finance, uint number) : this(dueTime, finance, number, false, "Айти") { }
        public override string ToString()
        {
            return base.ToString() + $"\nСфера проекта:{nameOfSphere}";
        }
    }

    public class Projecting : Stage
    {
        private uint numberOfFiles;
        public uint NumberOfFiles
        {
            get { return numberOfFiles; }
            set { numberOfFiles = value; }
        }
        public Projecting(uint dueTime, uint finance, uint number, bool salary, uint numberOfFiles) : base(dueTime, finance, number, salary)
        {
            name = "Projecting";
            this.numberOfFiles = numberOfFiles;
        }
        public Projecting(uint dueTime, uint finance, uint number) : this(dueTime, finance, number, false, 10) { }
        public override string ToString()
        {
            return base.ToString() + $"\nЧисло файлов в проекте:{numberOfFiles}";
        }
    }

    public class Coding : Stage
    {
        private uint numberOfLines;
        public uint NumberOfLines
        {
            get { return numberOfLines; }
            set { numberOfLines = value; }
        }
        public Coding(uint dueTime, uint finance, uint number, bool salary, uint numberOfLines) : base(dueTime, finance, number, salary)
        {
            name = "Coding";
            this.numberOfLines = numberOfLines;
        }
        public Coding(uint dueTime, uint finance, uint number) : this(dueTime, finance, number, false, 5000) { }
        public override string ToString()
        {
            return base.ToString() + $"\nЧисло строк в проекте:{numberOfLines}";
        }
    }

    public class Testing : Stage
    {
        private uint numberOfBugs;
        public uint NumberOfBugs
        {
            get { return numberOfBugs; }
            set { numberOfBugs = value; }
        }
        public Testing(uint dueTime, uint finance, uint number, bool salary, uint numberOfBugs) : base(dueTime, finance, number, salary)
        {
            name = "Testing";
            this.numberOfBugs = numberOfBugs;
        }
        public Testing(uint dueTime, uint finance, uint number) : this(dueTime, finance, number, false, 0) { }
        public override string ToString()
        {
            return base.ToString() + $"\nЧисло найденных багов:{numberOfBugs}";
        }
    }

    public class Expluatation : Stage
    {
        private DateTime supportPeriod;
        public DateTime SupportPeriod
        {
            get { return supportPeriod; }
            set {; }
        }

        public Expluatation(uint dueTime, uint finance, uint number, bool salary, int year) : base(dueTime, finance, number, salary)
        {
            name = "Expluatation";
            supportPeriod = new DateTime(year, 1, 1);
        }
        public Expluatation(uint dueTime, uint finance, uint number) : this(dueTime, finance, number, false, 2030) { }

        public override string ToString()
        {
            return base.ToString() + $"\nДата заврешения эксплуатации:{supportPeriod}";
        }
    }

    public class Worker
    {
        public uint Salary { get; set; }
        public static List<Worker> SetTeam(uint number)
        {
            List<Worker> team = new List<Worker>((int)number);
            Random rand = new Random();
            for (int i = 0; i < number; i++)
            {
                Worker worker = new Worker();
                worker.Salary = (uint)rand.Next(1000, 10000);
                team.Add(worker);
            }
            return team;
        }
    }
}