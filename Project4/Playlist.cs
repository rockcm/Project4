////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project3
// File Name:Playlist.cs
// Description: Demonstrates the functionality of the MP3 class by allowing for the creation of a list of mp3 objects and
// the manipulation of those objects by editing, sorting and displaying them
// Course: CSCI 1260 – Introduction to Computer Science II
// Author: Christian Rock
// Created: 10/19/22
// Copyright: Christian Rock, 2022
//
//////////////////////////////////////////////////////////////////////////////////////


using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project3MP3
{
    /// <summary>
    /// Playlist class that allows for the creation and management of an MP3 list through various methods.
    /// </summary>
    /// 
    public class Playlist
    {
        private List<MPThree> MP3Playlist { get; set; } // list of mp3 objects

        public string PlaylistName { get; set; } // name of the playlsit

        public string PlaylistAuthor { get; set; } // creator of playlists name

        public string PlaylistDate { get; set; } // date playlist was created

        public bool SaveNeeded { get; set; } // indicated if changes have been made to playlist since last save 



        /// <summary>
        /// default constructor, sets defualt values.
        /// </summary>
        public Playlist()
        {
            MP3Playlist = new List<MPThree>();
            this.PlaylistName = "";
            this.PlaylistAuthor = "";
            this.PlaylistDate = "";
        }

        /// <summary>
        /// Parameterized constructor, that allows for creation of playlist with user input.
        /// </summary>
        /// <param name="PlaylistName"> the playlists name field value</param>
        /// <param name="PlaylistAuthor">The Playlists Author field value</param>
        /// <param name="PlaylistDate">The Playlists Date field value</param>
        public Playlist(string PlaylistName, string PlaylistAuthor, string PlaylistDate)
        {
            MP3Playlist = new List<MPThree>();
            this.PlaylistName = PlaylistName;
            this.PlaylistAuthor = PlaylistAuthor;
            this.PlaylistDate = PlaylistDate;

        }

        /// <summary>
        /// copy constructor that copies the values of one playlist to another playlist
        /// </summary>
        /// <param name="other"> the value of a playlist object</param>
        public Playlist(Playlist other)
        {
            this.PlaylistName = other.PlaylistName;
            this.PlaylistAuthor = other.PlaylistAuthor;
            this.PlaylistDate = other.PlaylistDate;
            this.MP3Playlist = other.MP3Playlist;
        }


        /// <summary>
        /// returns the value of the playlist
        /// </summary>
        /// <returns>The playlist with its current values</returns>
        public List<MPThree> GetPlaylist()
        {
            return MP3Playlist;
        }


        /// <summary>
        /// Adds an mp3 file to the list
        /// </summary>
        /// <param name="MP3">The value of the object being passed</param>
        public void AddToList(MPThree MP3)
        {
            MP3Playlist.Add(MP3);
           
        }


        /// <summary>
        /// removes a file from the list, that can be indicated by user. 
        /// </summary>
        /// <param name="i">the value for i being passed</param>
        public void RemovePlaylistAt(int i)
        {
            MP3Playlist.RemoveAt(i);
        }



        /// <summary>
        /// Removes the indicated mp3 file
        /// </summary>
        /// <param name="mp3">The value of the object being passed for removal</param>
        public void RemoveSong(MPThree mp3)
        {
            MP3Playlist.Remove(mp3);
          
        }



        /// <summary>
        ///finds the size of the playlist 
        /// </summary>
        /// <returns>the value for the size of the list</returns>
        public int PlaylistSize()
        {
            return MP3Playlist.Count;
        }



        /// <summary>
        /// Finds an mp3 object by searaching for the song name
        /// </summary>
        /// <param name="mp3">the value of the mp3 object being passed</param>
        /// <param name="itemToFind"> the value of itemToFind that is being passed</param>
        /// <returns>the mp3 at a given position</returns>
        public MPThree FindByTitle(Playlist mp3, string itemToFind)
        {
            int index = 0;
            int foundPos = -1;
            bool found = false;
            while (index < MP3Playlist.Count && !found) // loop to go through the list while the mp3 were looking for has not been found
            {
                if (MP3Playlist[index].SongTitle == itemToFind) // if the title of the mp3 matches one we are searching for.. 
                {
                    found = true;   // then we update found to true 
                    foundPos = index;// and update foundpos to the index position it was found at. 

                }

                index++;
            }

            return MP3Playlist[foundPos];
        }


       


        /// <summary>
        /// Method to sort an mp3 by date, sorts with find largest date method
        /// </summary>
        public void SortByReleaseDates(List<MPThree> playlist, int size)
        {

            for (int i = size; i > 1; i--) // for loop that goes through the length of the list and moves the largest item to the end, effectively sorting the list.
            {
                int largestPos = FindLargestDate(MP3Playlist, i); // calls method to find the largest

                // if it is not last item, then we swap.

                if (largestPos != i - 1)
                {
                    // swapping mp3 postitions
                    MPThree temp = MP3Playlist[largestPos];
                    MP3Playlist[largestPos] = MP3Playlist[i - 1];
                    MP3Playlist[i - 1] = temp;

                }


            }
        }


        /// <summary>
        /// method that allows for all the mp3's with a given genre value to be diplayed
        /// </summary>
        /// <param name="Genre">The value of the Genre field</param>
        /// <returns>all the mp3's containing the value for genre being passed in</returns>
        public string DisplayByGenre(Genre Genre)
        {
            string msg = ""; // new empty string
            for (int i = 0; i < MP3Playlist.Count; i++) // loop that checks if the genre of the MP3 at postition 'i' is the same as the user input for genre and displays it in a list if so.
            {
                if (MP3Playlist[i].Genre == Genre) // checks to see if the MP3 has the same genre as the genre passed.
                {
                    msg += $"\n\n{MP3Playlist[i].ToString()}"; // adds the mp3 to the string
                }
                else
                {
                    msg = "No MP3's found with that genre";
                }
            }
            

            return msg;
        }

        /// <summary>
        /// method that allows for all the MP3's with a given artist value to be displayed. 
        /// </summary>
        /// <param name="artist"> the name of an artist</param>
        /// <returns>all the mp3's containing the value for artist being passed in</returns>
        public string DisplayByArtist(string artist)
        {
            string msg = ""; // new empty string 
            for (int i = 0; i < MP3Playlist.Count; i++) // loop that checks if the artist of the MP3 at postition 'i' is the same as the user input for genre and displays it in a list if so.
            {
                if (MP3Playlist[i].Artist == artist)  // checks to see if the MP3 has the same genre as the artist passed.
                {
                    msg += $"\n\n{MP3Playlist[i].ToString()}"; // adds mp3 to list
                }
                else
                {
                    msg = "No MP3's found with that Artist";
                }
            }

            return msg;
        }





        /// <summary>
        ///Displays MP3's alpabetically by song title. 
        /// </summary>
        /// <param name="size"> the size of the contents of the list</param>
        public void DisplayBySong(int size)
        {

            //
            for (int i = size; i > 1; i--) // for loop that allows for the moving of the largest item to the end, effectively sorting the list.
            {
                int largestPos = FindLargest(MP3Playlist, i); // finds the largest value 

                if (largestPos != i - 1) // if largest is not the same as the last
                {
                    // swapping
                    MPThree temp = MP3Playlist[largestPos];
                    MP3Playlist[largestPos] = MP3Playlist[i - 1];
                    MP3Playlist[i - 1] = temp;

                }

            }



        }






        /// <summary>
        /// Finds the largest value and returns it an an integer by comparing song titles
        /// </summary>
        /// <param name="playlist">the value of the playlist being passed</param>
        /// <param name="size">the value for the size of the list</param>
        /// <returns>an integer specifing whihch postion the largest value is at</returns>
        public int FindLargest(List<MPThree> playlist, int size)
        {
            int posOfLargest = 0;

            for (int i = 1; i < size; i++) // loop to check if the value of one variable against the value of another variable
            {
                if (playlist[i].SongTitle.CompareTo(playlist[posOfLargest].SongTitle) > 0) // compares the objects next to each other and updates posOfLargest with the item that is bigger. 
                {
                    posOfLargest = i;
                }


            }

            return posOfLargest;
        }


        /// <summary>
        /// Finds the largest value and returns it an an integer by splitting and comparing dates
        /// </summary>
        /// <param name="playlist"> the value of a list of mp3's</param>
        /// <param name="size"> the size of the array being passsed in</param>
        /// <returns> the postition of the largest value</returns>
        public int FindLargestDate(List<MPThree> playlist, int size)
        {
            int posOfLargest = 0;




            for (int i = 1; i < size; i++) // loop to check if the value of one variable against the value of another variable, goes through all items in list.
            {

                string[] strarr = playlist[i].SongReleaseDate.Split("/"); // splits the song release date at the "i" position into 3 strings based off the delimiter "/"
                string[] strarr2 = playlist[posOfLargest].SongReleaseDate.Split("/"); //  splits the song release date at the "posOfLargest" position into 3 strings based off the delimiter "/"
                if (strarr[2].CompareTo(strarr2[2]) > 0) // compares the year first 
                {
                    posOfLargest = i;

                }
                else if (strarr[2].CompareTo(strarr2[2]) == 0 && strarr[0].CompareTo(strarr2[0]) > 0) // compares the month next
                {
                    posOfLargest = i;
                }
                else if (strarr[0].CompareTo(strarr2[0]) == 0 && strarr[1].CompareTo(strarr2[1]) > 0) // compares the day next
                {
                    posOfLargest = i;
                }


            }
            return posOfLargest;
        }


        /// <summary>
        /// Fills playlist information from a file on the computer. 
        /// </summary>
        /// <param name="FileName">the name of the file location to populate the playlist from</param>
        public void FillFromFile(string FileName)
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(FileName);
                try
                {
                    string authorinfo = sr.ReadLine();
                    string[] authorFields = authorinfo.Split("|");
                    PlaylistName = authorFields[0];
                    PlaylistAuthor = authorFields[1];
                    PlaylistDate = authorFields[2];
                }
                catch(Exception e)
                {

                }
                
                while (sr.Peek() != -1)
                {
                    try
                    {
                        string str = "";
                        string textLine = sr.ReadLine();
                        string[] fields = textLine.Split("|");
                        str = fields[4];

                        MPThree mp3 = new MPThree(fields[0], fields[1], fields[2], Convert.ToDouble(fields[3]), Enum.Parse<Genre>(fields[4]), Convert.ToDecimal(fields[5]), Convert.ToDouble(fields[6]), fields[7]);
                        MP3Playlist.Add(mp3);
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }


        }


        /// <summary>
        /// Saves the plalist info in a file with a delimeter seperaator "|"
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveToFile(string fileName)
        {
            StreamWriter writer = null; // initialized writer to null 

            try // try cathch to make sure program does not crash during save to file. 
            {


              
                
                writer = new StreamWriter(fileName); // passing the filed name to the writer
                writer.WriteLine(PlaylistName + "|" + PlaylistAuthor + "|" + PlaylistDate);
                for (int i = 0; i < MP3Playlist.Count; i++) // for loop to print out a line for each mp3 to the file with a delimeter. 
                {
                    writer.WriteLine(MP3Playlist[i].SongTitle + "|" + MP3Playlist[i].Artist + "|" + MP3Playlist[i].SongReleaseDate + "|" + MP3Playlist[i].PlaybackTimeMins + "|" + MP3Playlist[i].Genre + "|" + MP3Playlist[i].DownloadCost + "|" + MP3Playlist[i].FileSizeMBs + "|" + MP3Playlist[i].Path);
                }
            }
            catch (Exception e) // catch for all exceptions
            {
                Console.WriteLine(e.Message);
            }
            finally // finally to close the writer 
            {
                if (writer != null)
                    writer.Close();
            }


        }

        /// <summary>
        /// To string method that allows for the playlist info to be diplayed nicely.
        /// </summary>
        /// <returns>the playlists values in a nice format</returns>
        public override string ToString()
        {
            string msg;
            msg = $"The Playlist Name is : {PlaylistName}" +
                  $"\nThe Author of the Playlist is : {PlaylistAuthor}" +
                  $"\nThe Date the playlist was created is : {PlaylistDate}" +
                  $"\nThe number of songs in the playlist is : {MP3Playlist.Count}.";
            return msg;

        }
    }
}