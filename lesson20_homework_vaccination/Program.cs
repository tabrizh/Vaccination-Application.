using System;

namespace Vaccination
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient[] patients = { };
            byte choice = 255;
            do
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine();
                Console.WriteLine("Please choose which operation you would like to do");
                Console.WriteLine();
                Console.WriteLine("1. Register a new patient for vaccination");
                Console.WriteLine("2. Returning patient for the second dose of vaccination");
                Console.WriteLine("3. Search for a patient");
                Console.WriteLine("4. Show the list of vaccinated patients");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                if (!byte.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("You can only type a number!");
                    choice = 255;
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Welcome to your vaccination procedure!");
                        Console.WriteLine();
                        Console.WriteLine("Please enter your ID (serial code and number)");
                        string newIdentification = Console.ReadLine();
                        bool idIsEqual = false;
                        if (patients.Length>0)
                        {
                            foreach (var item in patients)
                            {
                                if (String.Equals(newIdentification.Replace(" ", "", StringComparison.OrdinalIgnoreCase), item.Identification.Replace(" ", "", StringComparison.OrdinalIgnoreCase), StringComparison.OrdinalIgnoreCase))
                                {
                                    idIsEqual = true;
                                }  
                            }
                            if (idIsEqual==true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("This patient has already been vaccianted! Go to Update a patient!");
                                Console.WriteLine();
                                Console.WriteLine("********************************************************");
                                Console.WriteLine();
                                continue;
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Please enter your name");
                        string newName = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Please enter your surname");
                        string newSurname = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Please enter your age");
                        byte newAge = 0;
                        if (!byte.TryParse(Console.ReadLine(), out newAge))
                        {
                            Console.WriteLine("Enter a correct age!");
                            Console.WriteLine();
                            Console.WriteLine("********************************************************");
                            Console.WriteLine();
                            continue;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Please enter your Phone Number");
                        string newPhoneNumber = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Please enter your email");
                        string newEmail = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Please enter your address");
                        string newAddress = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Please enter your Company name");
                        string newCompany = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Please select which vaccine you would like to get");
                        string newFirstdoseName = Console.ReadLine();
                        string newFirstDoseDate = DateTime.Now.ToString("dd/MMMM/yyyy HH:mm:tt");
                        Array.Resize(ref patients, patients.Length + 1);
                        Patient newPatient = new Patient(newIdentification, newName, newSurname, newAge, newPhoneNumber, newEmail, newAddress, newCompany, true, newFirstDoseDate, newFirstdoseName)
                        {
                            ID = patients.Length
                        };
                        patients[patients.Length - 1] = newPatient;
                        Console.WriteLine();
                        Console.WriteLine("New patient has been successfully vaccinated!");
                        Console.WriteLine();
                        Console.WriteLine($"Name: {newName}, Surname: {newSurname}, Age: {newAge}, Phone Number: {newPhoneNumber}, Email: {newEmail}, Address: {newAddress}, Company: {newCompany}, First Dose Date: {newFirstDoseDate}, First Dose Name: {newFirstdoseName}, Second Dose Date: {newPatient.SecondDoseDate}, Second Dose Name: {newPatient.SecondDoseName}.");
                        Console.WriteLine();
                        Console.WriteLine("Congratulations with your first dose of vaccine! Please come back in 28 days for your second dose!");
                        Console.WriteLine();
                        Console.WriteLine("********************************************************");
                        Console.WriteLine();
                        break;

                    case 2:
                        if (patients.Length>0)
                        {
                            Console.WriteLine("Welcome back!");
                            Console.WriteLine("Select a number of a patient for the second dose");
                            Console.WriteLine();
                            foreach (var item in patients)
                            {
                                Console.WriteLine(item.ID + ". " + item.Name + " " + item.Surname + ", " + item.Age + ", " + item.Identification + ", " + item.PhoneNumber + ", " + item.Email + ", " + item.Address + ", " + item.Company);
                            }
                            byte updPtnt;
                            if (!byte.TryParse(Console.ReadLine(), out updPtnt))
                            {
                                Console.WriteLine("Please enter a correct number!");
                                continue;
                            }
                            if (updPtnt > patients.Length)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter a number that's in the list!");
                                Console.WriteLine();
                                Console.WriteLine("********************************************************");
                                Console.WriteLine();
                                continue;
                            }
                            else
                            {
                                if (patients[updPtnt - 1].SecondDose == false && patients[updPtnt - 1].FirstDose == true)
                                {
                                    patients[updPtnt - 1].SecondDoseName = patients[updPtnt - 1].FirstDoseName;
                                    patients[updPtnt - 1].SecondDoseDate = DateTime.Now.ToString("dd/MMMM/yyyy HH:mm:tt");
                                    Console.WriteLine();
                                    Console.WriteLine("You're all set! Congratulations!");
                                    patients[updPtnt - 1].SecondDose = true;
                                    Console.WriteLine();
                                    Console.WriteLine("Here is your full information with you second dose included!");
                                    Console.WriteLine($"Name: {patients[updPtnt - 1].Name}, Surname: {patients[updPtnt - 1].Surname}, Age: {patients[updPtnt - 1].Age}, Phone Number: {patients[updPtnt - 1].PhoneNumber}, Email: {patients[updPtnt - 1].Email}, Address: {patients[updPtnt - 1].Address}, Company: {patients[updPtnt - 1].Company}, First Dose Name: {patients[updPtnt - 1].FirstDoseName}, First Dose Date: {patients[updPtnt - 1].FirstDoseDate}, Second Dose Name: {patients[updPtnt - 1].SecondDoseName}, Second Dose Date: {patients[updPtnt - 1].SecondDoseDate}");
                                    Console.WriteLine();
                                    Console.WriteLine("********************************************************");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("You have already been fully vaccinated!");
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("The list is empty!");
                            Console.WriteLine();
                            Console.WriteLine("********************************************************");
                            Console.WriteLine();
                        }
                        break;

                    case 3:
                        if (patients.Length>0)
                        {
                            Console.WriteLine("Please enter a name of a patient you want to find");
                            string searchName = Console.ReadLine();
                            Patient[] foundPatients = Array.FindAll(patients, c => string.Equals(c.Name, searchName, StringComparison.OrdinalIgnoreCase));
                            Console.WriteLine();
                            if (foundPatients.Length > 0)
                            {
                                Console.WriteLine($"Patients found: {foundPatients.Length}");
                                Console.WriteLine();
                                foreach (var item in foundPatients)
                                {

                                    Console.WriteLine($"Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}, ID:  {item.Identification}, Phone Number: {item.PhoneNumber}, Email: {item.Email}, Address: {item.Address}, Company: {item.Company}, First Dose Name: {item.FirstDoseName}, First Dose Date: {item.FirstDoseDate}, Second Dose Name: {item.SecondDoseName}, Second Dose Date: {item.SecondDoseDate}");

                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nothing found!");
                                Console.WriteLine();
                            }
                            Console.WriteLine("********************************************************");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("The list is empty!");
                            Console.WriteLine();
                            Console.WriteLine("********************************************************");
                            Console.WriteLine();
                        }
                        break;

                    case 4:
                        if (patients.Length>0)
                        {
                            foreach (var item in patients)
                            {   
                                Console.WriteLine($"{item.ID}. Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}, ID:  {item.Identification}, Phone Number: {item.PhoneNumber}, Email: {item.Email}, Address: {item.Address}, Company: {item.Company}, First Dose Name: {item.FirstDoseName}, First Dose Date: {item.FirstDoseDate}, Second Dose Name: {item.SecondDoseName}, Second Dose Date: {item.SecondDoseDate}");  
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("The list is empty!");
                            Console.WriteLine();
                        }
                        Console.WriteLine("********************************************************");
                        Console.WriteLine();
                        break;

                    case 0:
                        Console.WriteLine("See you later!");
                        Console.WriteLine("********************************************************");
                        break;

                    default:
                        Console.WriteLine("You can only type a number that's in the list!");
                        break;
                }
            } while (choice != 0);
        }
    }
}
