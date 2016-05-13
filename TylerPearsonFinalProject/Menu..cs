//Tyler Pearson 9:00am Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylerPearsonFinalProject
{
    class Program
    {
        static void Main(string[] args)

        {
            Member[] members = new Member[15];
            Play[] plays = new Play[20];
            uint tempID = 0;
            string tempCode = "";
            bool runApp = true;
            int selectedPlay = 0;
            int selectedMember = 0;
            int input = 0;
            bool valid = true;
            bool notOldEnough = false;
            bool guest = false;
            string answer = "";
            int numberOfTickets = 0;
            double subTotal = 0;
            double serviceCharge = 0;
            double totalCost = 0;

            //Construct plays
            Play play1 = new Play("Happy", 0950, "All Ages", 15, 25.00, false);
            Play play2 = new Play("Othello", 1130, "Adults Only", 0, 25.00, false);
            Play play3 = new Play("The Persians**", 1415, "All Ages", 30, 49.99, true);
            Play play4 = new Play("NutCracker", 1730, "All Ages", 1, 49.99, false);
            Play play5 = new Play("Hamlet", 1920, "Adults Only", 5, 49.99, false);
            Play.SetPlayCount(5);
            plays[0] = play1;
            plays[1] = play2;
            plays[2] = play3;
            plays[3] = play4;
            plays[4] = play5;

            //Construct members
            Member member1 = new Member("Tyler Pearson", 26, 1234, "asd", 46.00);
            Member.SetMemberCount();
            Member member2 = new Member("Spongebob Squarepants", 68, 6868, "one", 250.00);
            Member.SetMemberCount();
            Member member3 = new Member("Patrick Star", 38, 2121, "two", 1000000.00);
            Member.SetMemberCount();
            Member member4 = new Member("Mr Krabs", 7, 9779, "six", 0.00);
            Member.SetMemberCount();
            Member Guest = new Member();
            Member.SetMemberCount();
            members[0] = member1;
            members[1] = member2;
            members[2] = member3;
            members[3] = member4;
            members[4] = Guest;








            while (runApp == true)
            {

                do
                {

                    do
                    {
                        //Display Menu
                        Console.Clear();
                        Console.WriteLine("\n\t\t\tWelcome to the Tyler Theatre!\n\n");
                        Console.WriteLine("    Please make your selection from the following plays or press \"E\" to Exit.\n");

                        //List Plays
                        Play.ListPlays(plays);
                        Console.WriteLine();
                        Console.Write("Select: ");
                        ConsoleKeyInfo key = Console.ReadKey();
                        Console.WriteLine();

                        //Select Play                
                        switch (key.Key)
                        {
                            case ConsoleKey.NumPad1:
                            case ConsoleKey.D1:
                                selectedPlay = 0;
                                if (!play1.HasPlayStarted() || !play1.AreSeatsLeft())
                                {
                                    valid = false;
                                }
                                else
                                    valid = true;
                                break;
                            case ConsoleKey.NumPad2:
                            case ConsoleKey.D2:
                                selectedPlay = 1;
                                if (!play2.HasPlayStarted() || !play2.AreSeatsLeft())
                                {
                                    valid = false;
                                }
                                else
                                    valid = true;
                                break;
                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:
                                selectedPlay = 2;
                                if (!play3.HasPlayStarted() || !play3.AreSeatsLeft())
                                {
                                    valid = false;
                                }
                                else
                                    valid = true;
                                break;
                            case ConsoleKey.NumPad4:
                            case ConsoleKey.D4:
                                selectedPlay = 3;
                                if (!play4.HasPlayStarted() || !play4.AreSeatsLeft())
                                {
                                    valid = false;
                                }
                                else
                                    valid = true;
                                break;
                            case ConsoleKey.NumPad5:
                            case ConsoleKey.D5:
                                selectedPlay = 4;
                                if (!play5.HasPlayStarted() || !play5.AreSeatsLeft())
                                {
                                    valid = false;
                                }
                                else
                                    valid = true;
                                break;
                            case ConsoleKey.E:
                                notOldEnough = false;
                                runApp = false;
                                valid = true;
                                break;
                            default:
                                Console.WriteLine("Invalid menu selection, press enter and try again.");
                                Console.ReadLine();
                                valid = false;
                                break;
                        }

                    } while (valid == false);




                    while (runApp == true)
                    {

                        do
                        {
                            //Ask if member or guest
                            Console.Clear();                          
                            Console.Write("Press 1 if you are a theatre member.\n");
                            Console.Write("Press 2 if you are a guest.\n");
                            Console.Write("Press 3 if you would like to sign up as a member.\nSelect: ");
                            ConsoleKeyInfo key2 = Console.ReadKey();
                            Console.WriteLine();
                            switch (key2.Key)
                            {
                                case ConsoleKey.NumPad1:
                                case ConsoleKey.D1:
                                    int tries = 1;
                                    while (tries <= 2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter your Member ID");
                                        uint.TryParse(Console.ReadLine(), out tempID);
                                        Console.WriteLine("Please enter your secret code");
                                        tempCode = Console.ReadLine();

                                        for (int i = 0; i < (Member.GetMemberCount() - 1); i++)
                                        {

                                            if (members[i].GetMemberCode() == tempCode && members[i].GetMemberID() == tempID)
                                            {
                                                Console.WriteLine("Member logged in successfully!\nPress Enter to continue...");
                                                selectedMember = i;
                                                Console.ReadLine();
                                                guest = false;
                                                valid = true;
                                                notOldEnough = false;
                                                tries = 3;
                                                break;
                                            }
                                            if (tries == 2)
                                            {
                                                Console.WriteLine("You have made too many attempts to login, continuing as guest.\nPress Enter to continue...");
                                                Console.ReadLine();
                                                valid = true;
                                                guest = true;
                                                Guest.SetMemberAge();
                                                notOldEnough = false;
                                                Console.ReadLine();
                                                selectedMember = 4;
                                                break;
                                            }
                                        }
                                        tries += 1;
                                    }
                                    break;
                                case ConsoleKey.NumPad2:
                                case ConsoleKey.D2:
                                    Console.WriteLine("\nContinuing as guest.\nPress Enter to continue...");
                                    Console.ReadLine();
                                    guest = true;
                                    valid = true;
                                    Guest.SetMemberAge();
                                    notOldEnough = false;
                                    selectedMember = 4;
                                    break;
                                case ConsoleKey.NumPad3:
                                case ConsoleKey.D3:
                                    Member nextMember = new Member();
                                    nextMember.MemberSignUp();
                                    members[Member.GetMemberCount() - 1] = nextMember;
                                    selectedMember = Member.GetMemberCount() - 1;
                                    notOldEnough = false;
                                    guest = false;
                                    valid = true;
                                    break;
                                default:
                                    Console.WriteLine("Try again, please press enter and make a valid selection.");
                                    Console.ReadLine();
                                    valid = false;
                                    break;
                            }

                            //Check if play is Adults Only
                            if (plays[selectedPlay].GetPlayRating() == "Adults Only")
                            {
                                if (!members[selectedMember].VerifyOver18())
                                {
                                    Console.WriteLine("You must be 18 years or older to attend this play, \nplease press Enter and select another play.");
                                    Console.ReadLine();
                                    notOldEnough = true;

                                }
                                else
                                    notOldEnough = false;
 ;
                            }
                        } while (valid == false);
                        break;
                    }

                } while (notOldEnough == true || valid == false);

                //Prompt to purchase tickets
                while (runApp == true)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(members[selectedMember].GetMemberName());
                        Console.Write("Please select how many tickets you would like to \npurchase for the play \"{0}\": ", plays[selectedPlay].GetPlayTitle());

                        if (!int.TryParse(Console.ReadLine(), out input))
                        {
                            Console.WriteLine("Try again, please press Enter and input a valid number");
                            Console.ReadLine();
                        }
                        else if (plays[selectedPlay].GetAvailableSeats() < input)
                        {
                            Console.WriteLine("There are only {0} tickets available, " +
                                "please press Enter and select another quantity.", plays[selectedPlay].GetAvailableSeats());
                            Console.ReadLine();
                            input = 0;
                        }
                    } while (input == 0);
                    numberOfTickets = input;

                    //Display Total Purchase Price
                    Console.Clear();
                    Console.WriteLine("Total purchase price comes to {0:C}", (plays[selectedPlay].CalculateTicketPrice(members[selectedMember].GetMemberAge())) * input);
                    Console.WriteLine("Press Enter to confirm purchase or Q to quit.");                   
                    answer = Console.ReadLine().ToLower();
                    //Display Receipt
                    if (answer == "q")
                    {
                        runApp = true;
                    }
                    else if (guest == true)
                    {   
                        subTotal = (plays[selectedPlay].CalculateTicketPrice(members[selectedMember].GetMemberAge()) * numberOfTickets);                  
                        serviceCharge = subTotal * .02;
                        totalCost = serviceCharge + subTotal;                       
                        Console.Clear();
                        Console.WriteLine("\n\tPlay: {0}\t Start Time: {1}\n********************************************************\n", plays[selectedPlay].GetPlayTitle()
                            , plays[selectedPlay].GetPlayTime());
                        Console.WriteLine("Ticket Price: {0,11:C}\t Number of Tickets: {1,-10}\n", plays[selectedPlay].CalculateTicketPrice(Guest.GetMemberAge()), numberOfTickets);
                        Console.WriteLine("Current balance:   $0.00");
                        Console.WriteLine("Subtotal:          {0,-10:C}", subTotal);
                        Console.WriteLine("Service Charge:    {0,-10:C}", serviceCharge);
                        Console.WriteLine("Total Cost:        {0,-10:C}\n________________________________________________________\n", totalCost);
                        Console.WriteLine("Remaining Balance: $0.00\n\n Press enter to return to the main menu...");
                        plays[selectedPlay].SetAvailableSeats(input);
                        Console.ReadLine();
                        runApp = true;
                    }
                    else if (!members[selectedMember].VerifyBalance((plays[selectedPlay].CalculateTicketPrice(members[selectedMember].GetMemberAge())) * input))
                    {
                        runApp = true;
                    }
                    else
                    {
                        subTotal = (plays[selectedPlay].CalculateTicketPrice(members[selectedMember].GetMemberAge()) * numberOfTickets);
                        serviceCharge = subTotal * .02;
                        totalCost = serviceCharge + subTotal;                                    
                        Console.Clear();
                        Console.WriteLine("\n\tPlay: {0}\t Start Time: {1}\n********************************************************\n", plays[selectedPlay].GetPlayTitle()
                            , plays[selectedPlay].GetPlayTime());
                        Console.WriteLine("Ticket Price: {0,11:C}\t Number of Tickets: {1,-10}\n", plays[selectedPlay].CalculateTicketPrice(members[selectedMember].GetMemberAge()), numberOfTickets);
                        Console.WriteLine("Current balance:   {0,-10:C}", members[selectedMember].RetrieveBalance());
                        Console.WriteLine("Subtotal:          {0,-10:C}", subTotal);
                        Console.WriteLine("Service Charge:    {0,-10:C}", serviceCharge);
                        Console.WriteLine("Total Cost:        {0,-10:C}\n________________________________________________________\n", totalCost);
                        Console.WriteLine("Remaining Balance: {0:C}\n\nPress enter to return to the main menu...", (members[selectedMember].RetrieveBalance()) - totalCost);
                        members[selectedMember].UpdateBalance(totalCost);
                        plays[selectedPlay].SetAvailableSeats(input);
                        Console.ReadLine();
                        runApp = true;
                    }
                    break;
                }
            }             
            


            
        }

}




}
    

