using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientdatamanagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Patient ID: ");
            string id = Console.ReadLine();

            Console.Write("Patient Name: ");
            string name = Console.ReadLine();


            Console.WriteLine("Patient Type: [General-1, Emergency-2, ICU-3, OPD-4]");
            patientType type = (patientType)int.Parse(Console.ReadLine());


            Console.WriteLine("Date of Birth:");
            DateTime DOB = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Admission date:");
            DateTime AdmissionDate = DateTime.Parse(Console.ReadLine());

            Patient patient = new Patient
            {
                ID = id,
                Name = name,
                PatientType = type,
                DateofBirth = DOB,
                AdmissionDate = AdmissionDate
            };
            string treatment = "";
            while (treatment.ToLower() !="0")
            {
                Console.Write("Enter Treatment (0 to stop): ");
                treatment = Console.ReadLine();
                patient.AddTreatment(treatment);
            }
            Console.WriteLine();
            Console.WriteLine($"ID: {patient.ID}");
            Console.WriteLine($"Name: {patient.Name}");
            Console.WriteLine($"Patient Type: {patient.PatientType}");
            Console.WriteLine($"Date of Birth: {patient.DateofBirth}");
            Console.WriteLine($"Admission Date: {patient.AdmissionDate}");
            Console.WriteLine($"Treatments: {patient.GetTreatment()}");



        }
       
    }
    public enum patientType
    {
        General=1,
        Emergency,
        ICU,
        OPD
    }
    public interface Itreatment
    {
        void AddTreatment(string treatment);
        string GetTreatment();
    }
    public abstract class Person
    {
        public string Name { get; set; }
        public  DateTime DateofBirth { get; set; }
    }
    public sealed class Patient : Person, Itreatment
    {
        public string ID { get; set; }
        public patientType PatientType { get; set; }
        public DateTime AdmissionDate { get; set; }

        List<string> treatments=new List<string>();
        public void AddTreatment(string treatment)
        {
            treatments.Add(treatment);
        }

        public string GetTreatment()
        {
            return string.Join(",", treatments.ToArray());
        }
    }

}
