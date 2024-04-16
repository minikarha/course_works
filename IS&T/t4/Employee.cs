using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t4
{
    public class Employee
    {
        public string FullName { get; set; } // ФИО
        public string INN { get; set; } // ИНН
        public string InsuranceNumber { get; set; } // Страховой номер
        public double Income { get; set; } // Доход
        public double TaxDeduction { get; set; } // Налоговый вычет
        public bool Disability { get; set; } // Инвалидность

        public Employee(string fullName, string inn, string insuranceNumber, double income, double taxDeduction, bool disability)
        {
            FullName = fullName;
            INN = inn;
            InsuranceNumber = insuranceNumber;
            Income = income;
            TaxDeduction = taxDeduction;
            Disability = disability;
        }

        public double CalculateESN()
        {
            double taxableIncome = Income - TaxDeduction;
            double pensionFund = taxableIncome * 0.22; // ПФР
            double socialInsuranceFund = taxableIncome * 0.029; // ФСС
            double medicalInsuranceFund = taxableIncome * 0.051; // ФФОМС
            double accidentInsuranceFund = taxableIncome * 0.002; // ФСС несчастный случай

            // Учет инвалидности
            if (Disability)
            {
                pensionFund *= 0.6;
                socialInsuranceFund *= 0.6;
            }

            return pensionFund + socialInsuranceFund + medicalInsuranceFund + accidentInsuranceFund;
        }
    }
}
