using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            IEnumerable<object> mvArtist = from match in Artists where match.Hometown == "Mount Vernon" select new {match.RealName, match.Age};
            System.Console.WriteLine(mvArtist.First());
            
            //Who is the youngest artist in our collection of artists?
            IEnumerable<object> artistList = from match in Artists orderby match.Age ascending select new {match.ArtistName, match.Age};
            System.Console.WriteLine(artistList.First());

            //Display all artists with 'William' somewhere in their real name
            IEnumerable<object> isWill = from match in Artists where match.RealName.Contains("William") select new {match.RealName};
            foreach (object item in isWill){
                System.Console.WriteLine(item);
            }
            
            //Display the 3 oldest artist from Atlanta
            // IEnumerable<object> sortAge = from match in Artists where match.Hometown == "Atlanta" select new {match.RealName, match.Age};
            IEnumerable<object> oldATL = Artists.Where(str => str.Hometown == "Atlanta").OrderByDescending(str => str.Age).Select(str => str.RealName);
            IEnumerable<object> oldest =  oldATL.Take(3);
            foreach (object item in oldest){
                System.Console.WriteLine(item);
            }
            

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
