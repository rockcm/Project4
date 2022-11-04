////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project3
// File Name: MPThree.cs
// Description: Class to allow for the creation of an MP3 object.  
// Course: CSCI 1260 – Introduction to Computer Science II
// Author: Christian Rock
// Created: 09/02/22
// Copyright: Christian Rock, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////

using Project3MP3;
/// <summary>
/// Class to allow for the creation of an MP3 object. Includes attributes and constructors in order to accomplish this.  
/// </summary>
public class MPThree
{
    public string SongTitle { get; set; } // listing out attributes for mp3 object.
    public string Artist { get; set; }
    public string SongReleaseDate { get; set; }
    public double PlaybackTimeMins { get; set; }
    public Genre Genre { get; set; }
    public decimal DownloadCost { get; set; }
    public double FileSizeMBs { get; set; }
    public string Path { get; set; }

    /// <summary>
    /// Defualt Constructor with default values for an MP3 object. 
    /// </summary>
    public MPThree()
    {
        string SongTitle = "";
        string Artist = "";
        string SongReleaseDate = "";
        double PlaybackTimeMins = 0;
        Genre Genre = Genre.Rock;
        decimal DownloadCost = 0;
        double FileSizeMBs = 0;
        string Path = "";
    }

    /// <summary>
    /// Parameterized constructor that will allow us to enter values for the MP3 object in the driver, and assisgns those values to the corresponding attributes. 
    /// </summary>
    /// <param SongTitle="SongTitle">the object’s SongName field value</param>
    /// <param Artist="Artist">the object’s Artist field value</param>
    /// <param SongReleaseDate="SongReleaseDate">the  object’s SongReleaseDate field value</param>
    /// <param PlaybackTimeMins="PlaybackTimeMins">the  object’s PlayBackTimeMins field value</param>
    /// <param Genre="Genre">the  object’s Genre field value</param>
    /// <param DownloadCost="DownloadCost">the  object’s DownloadCost field value</param>
    /// <param FileSizeMBs="FileSizeMBs">the  object’s FileSizeMBs field value</param>
    /// <param Path="Path">the  object’s Path field value</param>
    public MPThree(string SongTitle, string Artist, string SongReleaseDate, double PlaybackTimeMins, Genre Genre, decimal DownloadCost, double FileSizeMBs, string Path)
    {
        this.SongTitle = SongTitle;
        this.Artist = Artist;
        this.SongReleaseDate = SongReleaseDate;
        this.DownloadCost = DownloadCost;
        this.Genre = Genre;
        this.PlaybackTimeMins = PlaybackTimeMins;
        this.FileSizeMBs = FileSizeMBs;
        this.Path = Path;


    }


    /// <summary>
    /// Copy constructor that takes the values of one MP3 object and assigns them to another object. 
    /// </summary>
    /// <param Other="Other">the valuse of an MP3 object</param>
    public MPThree(MPThree other)
    {
        SongTitle = other.SongTitle;
        Artist = other.Artist;
        SongReleaseDate = other.SongReleaseDate;
        DownloadCost = other.DownloadCost;
        Genre = other.Genre;
        FileSizeMBs = other.FileSizeMBs;
        Path = other.Path;
    }

    /// <summary>
    /// To string override that allows for the MP3 object to be diplayed properly. 
    /// </summary>
    /// /// <returns>the values of the MP3 object as a string</returns>
    public override string ToString()
    {
        string msg;
        msg = $"MP3 Title:        {SongTitle}";
        msg = msg + $"\nArtist:           {Artist}";
        msg = msg + $"\nRelease Date:     {SongReleaseDate}     Genre: {Genre}";
        msg = msg + $"\nDownload Cost:    ${DownloadCost}        File size: {FileSizeMBs}";
        msg = msg + $"\nSong Playtime:    {PlaybackTimeMins}    Albulm Photo: {Path}";


        return msg;


    }






}
