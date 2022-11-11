////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project4
// File Name: Choices.cs
// Description: Possible choices to select for the menu.  
// Course: CSCI 1260 – Introduction to Computer Science II
// Author: Christian Rock
// Created: 09/02/22
// Copyright: Christian Rock, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////

using System;

/// <summary>
/// An enum containing the values for different choices for the Menu.
/// 
/// 
/// </summary>
public enum Choices
{
    CreatePlaylist = 1,
    CreateNewMP3, // 2
    EditAnMP3, // 3
    DropAnMP3, // 4 
    DisplayAll, // 5 
    DisplayBySongTitle,// 6
    DisplayByGenre, //7
    DisplayAllByArtist, // 8
    SortByTitle,// 9
    SortByReleaseDate, // 10
    SaveToFile,//11
    FillFromFile,//12
    End // 13

}