//Tyler Pearson 9:00am Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylerPearsonFinalProject
{
    class Member
    {
        private static int memberCount = 0;

        private double memberBalance;
        private int memberAge;
        private int memberID;
        private string memberCode;
        private string memberName;


        public Member()
        {
            memberName = "Guest";
        }

        public Member(string name, int age, int id, string code, double balance)
        {
            memberName = name;
            memberAge = age;
            memberCode = code;
            memberID = id;
            memberBalance = balance;
        }

        //Set member count
        public static void SetMemberCount()
        {
            memberCount = memberCount + 1;
        }
        //Get member count
        public static int GetMemberCount()
        {
            return memberCount;
        }

        //Member sign up
        public void MemberSignUp()
        {
            SetMemberName();
            SetMemberAge();
            SetMemberID();
            SetMemberCode();
            SetMemberCount();
            SetBalance();
        }

        //Retreive member name
        public string GetMemberName()
        {
            return memberName;
        }
        //Set member name default
        public void SetMemberName()
        {
            string name;
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter your first and last name.");
                name = Console.ReadLine();
                if (!ValidateMemberName(name))
                {
                    Console.WriteLine("Try again, Please press Enter and input both your first and last names...");
                    Console.ReadLine();
                }
                else
                {
                    memberName = name;
                }
            } while (!ValidateMemberName(name));
        }
        //Validate member name
        public bool ValidateMemberName(string name)
        {
            int spaceCount = 0;

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                {
                    spaceCount += 1;
                }
                else if (!char.IsLetter(name[i]) || spaceCount > 1)
                {
                    return false;
                }
            }

            if (spaceCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //Retrieve member secret code
        public string GetMemberCode()
        {
            return memberCode;
        }
        //Set member secret code
        public void SetMemberCode()
        {
            string code;
            do
            {
                Console.Clear();
                Console.Write("Please enter a 3 letter secret word: ");
                code = Console.ReadLine();
                if (!ValidateCode(code))
                {
                    Console.WriteLine("Try again, please press Enter and input a valid 3 letter code.");
                    Console.ReadLine();
                }
                else
                {
                    memberCode = code;
                }
            } while (!ValidateCode(code));
        }
        //Validate member secret code
        public bool ValidateCode(string code)
        {
            for (int i = 0; i < code.Length; i++)
            {
                if (!char.IsLetter(code[i]) || code.Length != 3)
                {
                    return false;
                }
            }
            return true;
        }


        //Retrieve member age
        public int GetMemberAge()
        {
            return memberAge;
        }
        //Set member age
        public void SetMemberAge()
        {
            string input;
            int age = 0;
            do
            {
                Console.Clear();
                Console.Write("Please enter your age: ");
                input = Console.ReadLine();
                age = ValidateMemberAge(input);
                if (age == 999)
                {
                    Console.WriteLine("Try again, please press Enter and input a valid age...");
                    Console.ReadLine();
                }
                else
                    memberAge = age;
            } while (age == 999);
        }
        //Validate member age
        public int ValidateMemberAge(string age)
        {
            int newAge;

            if (int.TryParse(age, out newAge))
            {
                return newAge;
            }
            else
            {
                return 999;
            }
        }
        //Verify member is 18 or older
        public bool VerifyOver18()
        {
            if (memberAge >= 18)
                return true;
            else
                return false;
        }


        //Retrieve member ID
        public int GetMemberID()
        {
            return memberID;
        }
        //Set member ID
        public void SetMemberID()
        {
            string id;
            do
            {
                Console.Clear();
                Console.Write("Please enter a 4 digit member ID: ");
                id = Console.ReadLine();
                if (ValidateId(id) == 1)
                {
                    Console.WriteLine("Try again, pelase press enter and input a valid 4 digit number...");
                    Console.ReadLine();
                }
                else
                {
                    memberID = ValidateId(id);
                }
            } while (ValidateId(id) == 1);

        }
        //Validate member ID
        public int ValidateId(string id)
        {
            int newId;

            if (int.TryParse(id, out newId) && id.Length == 4)
            {
                return newId;
            }
            else
            {
                return 1;
            }
        }

        //Retrieve member balance
        public double RetrieveBalance()
        {
            return memberBalance;
        }
        //Verify member balance
        public bool VerifyBalance(double cost)
        {
            if (memberBalance < cost)
            {
                Console.WriteLine("Sorry, you do not have enough funds in your account.\n Press Enter to return to the main menu...");
                Console.ReadLine();
                return false;
            }
            return true;
        }
        //Set a new member's balance
        public void SetBalance()
        {

            
            double balance = 0;
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter the amount of money you would like to add to your account.");
                input = Console.ReadLine();
                balance = ValidateBalance(input);
                if (balance == -1)
                {
                    Console.WriteLine("Try again, please press Enter and input a valid dollar amount");
                    Console.ReadLine();
                }
            } while (balance == -1);
            Console.WriteLine("Please deposit {0:C} using cash or credit.", balance);
            Console.WriteLine("Thank You!");
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
            memberBalance = balance;

        }
        //Update member balance
        public void UpdateBalance(double cost)
        {
            memberBalance = memberBalance - cost;
        }
        //Validate member balance
        public double ValidateBalance(string input)
        {
            double temp = 0;

            if (!double.TryParse(input, out temp))
            {
                return -1;
            }
            else
                return temp;
        }
    
            
        }

    }

