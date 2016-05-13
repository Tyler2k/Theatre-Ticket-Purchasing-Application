//Tyler Pearson 9:00am Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylerPearsonFinalProject
{
    class Play
    {
        private static int playCount = 0;
        private static int currentTime = 1045;

        
        private string playTitle;
        private int playTime;
        private string playRating;
        private int availableSeats;
        private double playPrice;
        private bool specialEngagement;
        

        public Play(string title, int time, string rating, int seats, double price, bool special)
        {
            playTitle = title;
            playTime = time;
            playRating = rating;
            availableSeats = seats;
            playPrice = price;
            specialEngagement = special;
        }

        //List plays
        public static void ListPlays(Play[] playList)
        {
            Console.WriteLine(" ******************************************************************************\n *{0,77}", "*");
            Console.WriteLine(" *    {0,-16}{1,-12}{2,-14}{3,-12}{4,-12} *\n *{5,77}", "~PLAY~", "~TIME~", "~RATING~", "~PRICE~", "~SEATS AVAILABLE~", "*");
            for (int i = 0; i <= playCount-1; i++)
            {
                
                Console.WriteLine(" *  ({0}) {1,-15}{2,-12}{3,-14}{4,-12:C}{5,-13}{6,5}\n *{6,77}", i + 1, playList[i].playTitle,
                                   playList[i].playTime, playList[i].playRating, playList[i].playPrice, playList[i].availableSeats, "*");
            }
            Console.WriteLine(" ******************************************************************************\n\n\t** = Special Engagement");
        }

        //Get play Count
        public static int GetPlayCount()
        {
            return playCount;
        }
        //Set play count
        public static void SetPlayCount(int newPlayCount)
        {
            playCount = newPlayCount;
        }

        //Retrieve Play Rating
        public string GetPlayRating()
        {
            return playRating;
        }

        //Retrieve play title
        public string GetPlayTitle()
        {
            return playTitle;
        }

        //Retrieve available seats
        public int GetAvailableSeats()
        {
            return availableSeats;
        }
        //Set available seats        
        public void SetAvailableSeats(int boughtSeats)
        {
            availableSeats = availableSeats - boughtSeats;
        }

        //Retrieve Play time
        public int GetPlayTime()
        {
            return playTime;
        }

        //Determine Ticket Price
        public double CalculateTicketPrice(int age)
        {
            if(specialEngagement)
            {
                return 49.99;
            }           
            else if (age < 12 || playTime < 1500)
            {
                return 25.00;
            }
            else if ((age > 65) || (age >= 12 && age <= 21))
            {
                return 44.99;
            }
            return 49.99;
        }

        //Check if play hasn't started
        public bool HasPlayStarted()
        {                      
                if (currentTime > playTime)
                {
                    Console.WriteLine("Sorry, this play has already started.  Press enter and please select a different play.");
                    Console.ReadLine();
                    return false;
                }
                else
                    return true;
        }
        //Check if play still has available seats
        public bool AreSeatsLeft()
        {
            if (availableSeats == 0)
            {
                Console.WriteLine("Sorry, there are no more available seats for this play"
                    + " please press enter and select another play.");
                Console.ReadLine();
                return false;
            }
            else
                return true;
        }
        


}

}
