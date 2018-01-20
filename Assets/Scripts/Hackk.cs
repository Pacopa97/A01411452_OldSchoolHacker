using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackk : MonoBehaviour
{
    const string menuHint = "Type menu";
    #region Class Atrtributes
    //Class attributes
    //These arrays will hold the passwords of the different game levels
    string[] level1Passwords = { "cow", "dog", "tiger", "koala"};
    string[] level2Passwords = { "squirtle", "bulbasaur", "kakuna", "tentacool" };
    string[] level3Passwords = { "incomprehensibilities", "euouae", "uncopyrightable", "unimaginatively" };

    int level;
    string password;

    //Declaration of the different game states and a variable for the current game state
    enum GameState { MainMenu, Password, Win };
    GameState currentScreen = GameState.MainMenu;

    //Variable to receive user's input
    string input;
    #endregion

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        currentScreen = GameState.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What do you want to guess today?");
        Terminal.WriteLine("1.- Easy Animals");
        Terminal.WriteLine("2.- Best Pokemons");
        Terminal.WriteLine("3.- Impossible");
        Terminal.WriteLine("Select an option");


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnUserInput(string input)
    {
        // If user inputs "menu", then we call ShowMainMenu() method
        if (input == "menu")
        {
            ShowMainMenu();
        } //If the user types quit, close or exit, then we try to close the game
        //If the game is played on a web browser, we ask the user to close the browser's tab
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("Please, close the browser's tab");
            Application.Quit();
        }
        //If the user types anything that is not menu, quit, close or exit, we handle the input depending on the game state
        //If the game state is still MainMenu, we call RunMainMenu()
        if (currentScreen == GameState.MainMenu)
        {
            RunMainMenu(input);

            //But if the state is password, we run CheckPassword() method
        }
        else if (currentScreen == GameState.Password)
        {
            CheckPassword(input);
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            displayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    private void displayWinScreen()
    {
        Terminal.ClearScreen();
        ShowLevelReward();
       // Terminal.WriteLine(menuHint);
    }

    //  This method shows a reward based on the level of difficulty hacked.
    private void ShowLevelReward()
    {
        //  Depending on the level, this method shows a different reward.
        //  If by any chance level is not among the valid level numbers, then we show an error.
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Looking like a Taxidermist");
                Terminal.WriteLine(@"
     /╲ ︵ ╱\
    l (◉) (◉)l
     \ ︶ V /
      /↺↺↺↺\
      ↺↺↺↺↺
      \↺↺↺↺/
     ¯¯/\¯/\¯
");
                break;
            case 2:
                Terminal.WriteLine("Nice job Pokemon Trainer");
                Terminal.WriteLine(@"
           ▔╲┊┊┊┊┊┊┊┊┊╱▔▏
          ┊╲┈╲╱▔▔▔▔▔╲╱┈╱
          ┊┊╲┈╭╮┈┈┈╭╮┈╱┊
          ┊┊╱┈╰╯┈▂┈╰╯┈╲┊
          ┊┊▏╭╮▕━┻━▏╭╮▕┊
          ┊┊╲╰╯┈╲▂╱┈╰╯╱┊
");
                break;
            case 3:
               
                Terminal.WriteLine(@"
            Are you hacking?
            ┈┈┈╲┈┈┈┈╱
            ┈┈┈╱▔▔▔▔╲
            ┈┈┃┈▇┈┈▇┈┃
            ╭╮┣━━━━━━┫╭╮
            ┃┃┃┈┈┈┈┈┈┃┃┃
            ╰╯┃┈┈┈┈┈┈┃╰╯
            ┈┈╰┓┏━━┓┏╯
            ┈┈┈╰╯┈┈╰╯
");
                break;
            default:
                Debug.LogError("Invalid level reached.");
                break;
        }
    }
    private void RunMainMenu(string input)
    {
        //Check that the input is valid
        bool isValidInput = (input == "1") || (input == "2") || (input == "3") || (input == "menu");

        //If the input is valid, we convert the input to an int and call AskForPassword() method
        if (isValidInput)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        //If the user did not enter a valid input, then we validate for our Easter Eggs
        else if (input == "007")
        {
            Terminal.WriteLine("Please enter a valid level, Mr. Bond");
        }else if (input == "69")
        {
           // Terminal.WriteLine("");
            Terminal.WriteLine(@"
Don't be silly, enter a valid level plz
        ┊┊╭╮╭╮┊┊┊┊┊┊┊┊
        ┊┊┊┃┃┃┃┊┊┊┊┊┊┊
        ┊┊┊┃┃┃┃┊┊┊╭━━━
        ┊┊╭┛┗┛┗╮┊╭╯HAPPY
        ┊┊┃┈▆┈▆┃┊┃EASTER!
        ┊┊┃┈┈▅┈┃┊╰┳━━━
        ┊┊┃┈╰┻╯┃━━╯┊┊┊
");
        }
        else
        {
            Terminal.WriteLine("Enter a valid level");
        }

    }

    private void AskForPassword()
    {
        //Set current game state as Password
        currentScreen = GameState.Password;

        //Clear our terminal screen
        Terminal.ClearScreen();

        //We call SetRandomPassword() method
        SetRandomPassword();

        Terminal.WriteLine("Enter your passsword. Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
        //Depending on the selected level, we choose a random to crack
        switch (level)
        {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level. How did you manage that?");
                break;
        }
    }
}
