////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project3
// File Name: MPThreeDriver.cs
// Description: Demonstrates the functionality of the MP3 class by allowing for the creation and display of an MP3 object to the screen with user input.
// Allows for list of MP3's 
// Course: CSCI 1260 – Introduction to Computer Science II
// Author: Christian Rock
// Created: 10/19/2022
// Copyright: Christian Rock, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////

using Project3MP3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Demonstrates the functionality of the MP3 class by allowing for the creation and display of an MP3 object to the screen 
/// allows for a playlist to be made with these objects. Can display them and sort them with certain criteria.
/// This is done with a user friendly menu from the menu and choices classes. Implements the playlist class, mp3 class and genre enum class together. 
/// Driver along with playlist and mp3 class, allows for the user to manipulate the mp3's in the playlist several different ways.
/// </summary>
/// 





string SongTitle = ""; // variables to store values for mp3, named appropriately - i set to default values
string Artist = "";
string SongReleaseDate = "";
double PlaybackTimeMins = 0;
Genre Genre = Genre.ROCK;
decimal DownloadCost = 0;
double FileSizeMBs = 0;
string Path = "";
string file = "";
MPThree mp3ToEdit = new MPThree(); // mp3 that will be used to edit 
string End = "";
string SaveNeededFile;

string UserInput = ""; // user input for authors name 
string UserInput2 = ""; // user input for name of playlist 
string UserInput3 = ""; // user input for date playlist was made.
string Song = ""; // user input to indicate what song to look for or display 
string partToEdit = "";


Playlist playlist1 = null;

Console.ForegroundColor = ConsoleColor.Cyan; // makes text color blue where you enter name



// creating a string and asking user to store their name in it. used to say goodbye to them later. Also welcomes user to program.
string name;
Console.WriteLine("Welcome to my MP3 menu. With this program you are able to create and diplay and MP3 file. \n\n-Program written by Christian Rock. \n\nPress any key to continue");
Console.ReadKey();
Console.WriteLine("\nPease enter your name");
name = Console.ReadLine();


MPThree MP3 = new MPThree(); // default mp3 object
MPThree MP33 = new MPThree(); // second default object to compare first to, to see if values were input. 
MP3 = MP33; // ensuring values are the same of both mp3 objects.. later on this will ensure a MP3 object has been created before displaying.

//Set up the look and feel of the Console window
Console.BackgroundColor = ConsoleColor.Black;       //Change the background color of the window to white
Console.ForegroundColor = ConsoleColor.Cyan;        //Change the font color to blue
Console.Title = "MP3 Menu";   //Set the text of the title bar (top left)



Menu menu = new Menu("Menu for Project 1 - MP3"); // creates new menu and options
menu = menu + "Create a new Playlist" + "Create a new MP3 object and add it to the playlist" + "Edit an existing MP3 from the playlist" + "Drop an MP3 from the playlist" + "Display all MP3s in the playlist" + "Display an MP3 by Song Title" + "Display all MP3s on the tracker of a given genre" + "Display all MP3s by a given artist" + "Sort the MP3s by song title" + "Sort the MP3s by song release date" + "Save To File" + "Load From File" + "Exit Program";





Choices choice = (Choices)menu.GetChoice(); // recognizes what option is selected by user and displays correct siwtch staemtent base upon it.




/// <summary>
/// While loop that will give the user the option to create and display and mp3 object. This incorporates and demonstrates the menu and choice classes functionality as well.
/// User can also select to end program, menu will continue until this is selected. Loop will also check to see if mp3 object was created before displaying
/// </summary>
/// 

while (choice != Choices.End)
{

    switch (choice)
    {
        // menu option for creating a playlist, store values in variables defined above and creates playlist from them.

        case Choices.CreatePlaylist:
            playlist1 = new Playlist();
            try
            {
                Console.WriteLine("What is your name? ");
                UserInput = Console.ReadLine();
                Console.WriteLine("What do you want to name the playlist? ");
                UserInput2 = Console.ReadLine();
                Console.WriteLine("What is todays date?");
                UserInput3 = Console.ReadLine();
                playlist1 = new Playlist(UserInput2, UserInput, UserInput3);
                Console.WriteLine($"Your current playlist:\n{playlist1}");
                Console.ReadKey();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format Exceptiion, program will continue");
            }
            catch (SystemException e)
            {
                Console.WriteLine($"System Exception: {e.Message}.  Please try again" );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                playlist1.SaveNeeded = true;
            }
            break;

        // menu option for creating a new mp3 object.
        case Choices.CreateNewMP3: // option for creating and mp3 object / asks questions to create MP3 object and store values in variables with related namme.  
            try
            {

                Console.WriteLine("You selected Create a new MP3 file");
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.WriteLine("\nPlease enter Song Title");
                SongTitle = Console.ReadLine();
                Console.WriteLine("\nEnter Artist Name");
                Artist = Console.ReadLine();
                Console.WriteLine("\nEnter Song Release Date");
                SongReleaseDate = Console.ReadLine();
                try
                {
                    Console.WriteLine("\nEnter Song playback time");
                    PlaybackTimeMins = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " Can edit file's playback time later if you would like.");
                }
                try
                {
                    Console.WriteLine("\nEnter Song Download Cost");
                    DownloadCost = Convert.ToDecimal(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " Can edit file's download cost later if you would like.");
                }
                try
                {
                    Console.WriteLine("\nEnter File Size");
                    FileSizeMBs = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " Can edit file's file size later if you would like.");
                }

                Console.WriteLine("\nEnter Song Path");
                Path = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Can edit file's later if you would like.");
            }


            try // try catch statment to make sure that genre input does not crash the program. 
            {
                Console.WriteLine("\nEnter Song Genre. (Rock, Pop, Jazz, Country, Classical, or Other)");
                string input = Console.ReadLine().ToUpper();
                Genre = (Genre)Enum.Parse(typeof(Genre), input);
            }
            catch (Exception e) // catch for all possible exceptions
            {
                Console.WriteLine($"Error: {e.Message}. Genre was not valid, value will be set to on of the available Genre's. You can edit this later if you would like. ");
            }
            finally
            { // continues with creation of mp3 from the user input values above. 
                MP3 = new MPThree(SongTitle, Artist, SongReleaseDate, PlaybackTimeMins, Genre, DownloadCost, FileSizeMBs, Path);
                playlist1.AddToList(MP3);
                Console.WriteLine($"\n{MP3}");
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.WriteLine($"\nThank you, {name} for using my program. Press any key to go back to main menu.");
                Console.ReadKey();
                playlist1.SaveNeeded = true;
            }
            break;





        // menu option for dropping an Mp3 object from the list, uses the find by title method to indicate which song to drop. 
        case Choices.DropAnMP3:
            MPThree MP3ToDrop;

            try
            {
                Console.Write("MP3's in playlist will be displayed below. \n");
                foreach (MPThree mp3 in playlist1.GetPlaylist())
                {
                    Console.WriteLine($"\n{mp3}");
                }

                Console.WriteLine("What is the name of the Song you would like to remove from the playlist? ");
                Song = Console.ReadLine();
                MP3ToDrop = playlist1.FindByTitle(playlist1, Song); // takes in the user input for song to drop and the playlist its in. 
                playlist1.RemoveSong(MP3ToDrop); // drops the mp3 with that song name
                Console.WriteLine($"{Song} has been dropped from the playlsit.");
                Console.ReadKey();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format Exceptiion, program will continue.  Could not locate MP3 file. Please try again");
            }
            catch (SystemException e)
            {
                Console.WriteLine($"System Exception: {e.Message}. Could not locate MP3 file. Please try again");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + ". Could not locate MP3 file. Please try again");
            }
            finally
            {
                playlist1.SaveNeeded = true;
            }

            break;

        // menu option for Diplaying a song from the Playlist, using the find by title method. 
        case Choices.DisplayBySongTitle:
            try
            {
                if (playlist1.PlaylistSize() == 0)
                {
                    Console.WriteLine("There are no songs to display, please make a playlist and add an MP3 first");
                }
                else
                {
                    Console.WriteLine("What song are you looking for?");

                    Song = Console.ReadLine();

                    Console.WriteLine(playlist1.FindByTitle(playlist1, Song));
                }
                Console.ReadKey();
              
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "Song not found");
                Console.ReadKey();
            }
            break;


        // menu option for showing all the mp3 objects in the playlist
        case Choices.DisplayAll:
            try
            {
                if (playlist1.PlaylistSize() == 0)
                {
                    Console.WriteLine("There are no songs to display, please make a playlist and add an MP3 first");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Here is your current playlist: \n");
                    Console.WriteLine($"\n{playlist1.ToString()} ");
                    foreach (MPThree mp3 in playlist1.GetPlaylist())
                    {
                        Console.WriteLine($"\n{mp3}");
                    }
                    Console.ReadKey();
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " Please create a playlist and add an mp3 file to it");
                Console.ReadKey();
            }


            break;

        // menu option for editing a part of an MP3 object.
        case Choices.EditAnMP3:
            if (playlist1 == null)
            {
                Console.WriteLine("Please create a Playlist and add an MP3.");
                Console.ReadKey();
            }
            else
            {
                try
                {

                    Console.Write("MP3's in playlist will be displayed below. \n");
                    foreach (MPThree mp3 in playlist1.GetPlaylist())
                    {
                        Console.WriteLine($"\n{mp3}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Please create a Playlist and add an MP3.");
                }

                try
                {
                    Console.Write($"\nWhat is the song title of the MP3 you would like to edit?");
                    Song = Console.ReadLine();
                    mp3ToEdit = playlist1.FindByTitle(playlist1, Song); // finding the mp3 with findbytitle method.
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + ". Unable to find MP3 file. Please try again. (Search by song title.");
                    Console.ReadKey();
                }
                try
                {
                    Console.Write("\nWhat part of the MP3 would you like to edit? Enter one of the following ( Song Title, Artist, Playback Time, Genre, Path, Download Cost, File Size, or Release Date) ");
                    partToEdit = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + ". Please try again");
                    Console.ReadKey();
                }
                finally
                {
                    playlist1.SaveNeeded = true;
                }  
            }
            switch (partToEdit) // switch statment depending on which part user wants to edit. 
            {

                case "Artist":  // option if the user want to edit the Artist
                   
                        Console.WriteLine($"\nWhat would you like the new artist name to be? ");
                        mp3ToEdit.Artist = Console.ReadLine();
                        Console.WriteLine($"\nHere is mp3 after edit: ");
                        Console.WriteLine();
                        Console.WriteLine(mp3ToEdit);
                        Console.ReadKey();
                    
                    break;

                    
                case "Release Date": // option if the user want to edit the Release Date

                    try
                    {
                        Console.WriteLine($"\nWhat would you like the new Release Date to be? ");
                        mp3ToEdit.SongReleaseDate = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine(mp3ToEdit);
                        Console.ReadKey();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;

                case "Genre": // option if the user want to edit the Genre
                    string Genreinput = "";
                    try // try catch to make sure genre does not crash program
                    {
                        Console.WriteLine($"\nWhat would you like the new Genre to be? Enter one of the following (Rock, Pop, Jazz, Country, Classical, or Other). ");
                        Genreinput = Console.ReadLine();
                        mp3ToEdit.Genre = (Genre)Enum.Parse(typeof(Genre), Genreinput);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"\nError: {e.Message}. Genre was not valid, value will be set to 'Rock'. ");
                    }
                    finally
                    {
                        Console.WriteLine();
                        Console.WriteLine(mp3ToEdit);
                        Console.ReadKey();

                    }
                    break;

                case "Download Cost": // option if the user want to edit the Download Cost
                    try
                    {
                        Console.WriteLine($"\nWhat would you like the new Download Cost to be? ");
                        mp3ToEdit.DownloadCost = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine(mp3ToEdit);
                        Console.ReadKey();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message + " Please try again, enter a number");
                    }

                    break;

                case "Song Title": // option if the user want to edit the Song Title
                    Console.WriteLine($"\nWhat would you like the new Song Title to be? ");
                    mp3ToEdit.SongTitle = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine(mp3ToEdit);
                    Console.ReadKey();

                    break;

                case "File Size": // option if the user want to edit the File Size
                    try
                    {
                        Console.WriteLine($"\nWhat would you like the new File Size in MBs to be? ");
                        mp3ToEdit.FileSizeMBs = Double.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine(mp3ToEdit);
                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + " Please try again, enter an number");
                    }

                    break;


                case "Playback Time": // option if the user want to edit the Playback Time
                    try
                    {
                        Console.WriteLine($"\nWhat would you like the new Playback time to be? ");
                        mp3ToEdit.PlaybackTimeMins = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine(mp3ToEdit);
                        Console.ReadKey();
                    }
                     catch(Exception e)
                    {
                        Console.WriteLine(e.Message + " Please try again, enter a number");
                    }

                    break;

                case "Path": // option if the user want to edit the Path
                    Console.WriteLine($"\nWhat would you like the new Path to be? ");
                    mp3ToEdit.Path = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine(mp3ToEdit);
                    Console.ReadKey();

                    break;
            } // allows for the editing of the mp3 with this method


            break;


        // menu option for sorting the playlist by release date. 
        case Choices.SortByReleaseDate:

            try
            {

                if (playlist1 == null)
                {
                    Console.WriteLine("Please create a playlist and add an MP3 first");
                }
                else
                {
                    Console.WriteLine($"\nPlaylist will be sorted by release date.\n");
                    playlist1.SortByReleaseDates(playlist1.GetPlaylist(), playlist1.PlaylistSize()); // calls sort by release date method
                    foreach (MPThree mp3 in playlist1.GetPlaylist())
                    {
                        Console.WriteLine($"\n{mp3}");
                    }
                    Console.ReadKey();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                playlist1.SaveNeeded = true;
            }
            break;



        // menu option for displaying all mp3's of a certain genre. 
        case Choices.DisplayByGenre:
            try
            {
                Genre Genre1;
                string GenreString = "";
                Console.Write("What Genre would you like to display? (Rock, Pop, Jazz, Country, Classical, or Other) ");
                GenreString = Console.ReadLine().ToUpper();
                Genre1 = (Genre)Enum.Parse(typeof(Genre), GenreString); // variable to pass to indicate what genre user wants to display. 
                Console.WriteLine($"\n{playlist1.DisplayByGenre(Genre1)}"); // calling displaybyGenre method. 
                Console.ReadKey();
            }catch(Exception e)
            {
                Console.WriteLine("Invalin genre option entered.");
            }
            break;

        // menu option for diplaying all songs by a given artist. 
        case Choices.DisplayAllByArtist:
            try
            {
                string ArtistToDisplay;
                Console.WriteLine("What artist would you like to display? ");
                ArtistToDisplay = Console.ReadLine();
                Console.WriteLine(playlist1.DisplayByArtist(ArtistToDisplay)); // passes user input to display all mp3's with that input
                Console.ReadKey();
            }catch(Exception e)
            {
                Console.WriteLine("Artist not found in MP3 playlist");
            }
            break;

        // menu option for diplaying mp3 songs alpabetically
        case Choices.SortByTitle:
            try
            {


                playlist1.DisplayBySong(playlist1.PlaylistSize()); // call display by song method and displays array 
                foreach (MPThree mp3 in playlist1.GetPlaylist())
                {
                    Console.WriteLine($"\n{mp3}\n");
                }
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                playlist1.SaveNeeded = true;
            }

            break;



        // option to end the program
        case Choices.End:

            Console.WriteLine("You selected End the Program.");
            Console.WriteLine($"\nThank you, {name} for using my program. Press any key to end.");
            Console.ReadKey();
            break;


        case Choices.FillFromFile:
            playlist1 = new Playlist();
            try
            {
                Console.WriteLine("What is the file you would like to load from");
                file = Console.ReadLine();
                playlist1.FillFromFile(file);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + " Please try again, unable to read from file location. No playlist created");
                Console.ReadKey();
            }
            break;





        case Choices.SaveToFile:
            try
            {
                Console.WriteLine("Please type in the file you would like to save to");
                file = Console.ReadLine();
                playlist1.SaveToFile(file);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + ". Please try again, unable to save to file location");
            }
            break;





    }

    choice = (Choices)menu.GetChoice();
}

if (choice == Choices.End) // statement for if the user selects "end" to say goodbye to them.
{
    try
    {
        if (playlist1.SaveNeeded == true)
        {
            try
            {
                do
                {
                    Console.WriteLine("It looks like you have made changes to the Playlist since the last save. Would you like to save before you exit? (Enter Yes or No)");
                    End = Console.ReadLine().ToUpper();
                    if (End == "Y" || End == "YES")
                    {
                        Console.Write($"\nWhat is the file location you would like to save to? ");
                        SaveNeededFile = Console.ReadLine();

                        playlist1.SaveToFile(SaveNeededFile);
                    }
                    else if (End == "N" || End == "NO")
                    {
                        Console.WriteLine("You selected End the Program.");
                        Console.WriteLine($"\nThank you, {name} for using my program. Press any key to end.");
                        Console.ReadKey();
                    }
                } while (End != "YES" && End != "Y" && End != "N" && End != "NO");

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Please try again");
            }


            Console.WriteLine("Changes have been saved,");
            Console.WriteLine($"\nThank you, {name} for using my program. Press any key to end.");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("You selected End the Program.");
            Console.WriteLine($"\nThank you, {name} for using my program. Press any key to end.");
            Console.ReadKey();
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("No playlist created. Program will continue to end");
    }
}


