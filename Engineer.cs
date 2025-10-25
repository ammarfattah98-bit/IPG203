using System;
using System.Collections.Generic;
using System.Text;

namespace IPG_203.Classes
{
   public abstract class Engineer : IReportable
    {

        private string name;
        
        private  double baseSalary;
        private  readonly int birthyear;
        static int id = 0;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double BaseSalary
        {
            get { return baseSalary; }
            set { baseSalary = value; }
        }
        public int Birthyear
        {
            get { return birthyear; }

        }
        public Engineer(string name, double baseSalary,int birthyear)
        {
            id++;
            this.name = name;
            this.baseSalary =baseSalary ;
            this.birthyear = birthyear;
        }
        // تعريف التفويض (Delegate)
        public delegate void SalaryChangedHandler(object sender, double newSalary);

        // تعريف الحدث (Event)
        public event SalaryChangedHandler OnSalaryIncreased;
        // دالة مجردة — يجب أن تنفذها الصفوف الفرعية
        public abstract double CalculateSalary();

        // دالة افتراضية — يمكن إعادة تعريفها
        public virtual void ShowInfo()
        {
            
            Console.WriteLine("Engineer:"+name);
            Console.WriteLine("Base Salary:"+baseSalary);
        }
        //دالة ستاتيكية تعيد عدد المهندسين
        public static int getID()
        {
            return id;
        }

        // تنفيذ من الواجهة
        public abstract void GenerateReport();
        // دالة لتعديل الراتب وإطلاق الحدث
        public void IncreaseSalary(double amount)
        {
            baseSalary += amount;
            // إطلاق الحدث
            OnSalaryIncreased?.Invoke(this, BaseSalary);
        }
    }
}
