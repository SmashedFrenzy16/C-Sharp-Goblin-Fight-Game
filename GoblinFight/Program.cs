// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

Console.ForegroundColor = ConsoleColor.DarkRed;


Random playerDie = new Random();
Random gobDie = new Random();

string[] outcomes = { "Player", "Goblin" };

Random randomName = new Random();

int r; // For deciding who gets the special attack
int p; // For probability of getting to drink Potion (for player)

double playerStrength = 100;
double playerHealth = 100;
double playerAttack;
int playerNext;
int playerDNext;
string pDrink;
string[] probDrink = { "Yes", "No" };


double gobStrength = 100;
double gobHealth = 100;
double gobAttack;
int gobNext;
int gobDNext;

string fightChoice;

int gobANext; // For determining how the goblin attacks the player if the plyaer has chosen to defend

void printPlayer()
{
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine("      _,.\r\n    ,` -.)\r\n   ( _/-\\\\-._\r\n  /,|`--._,-^|            ,\r\n  \\_| |`-._/||          ,'|\r\n    |  `-, / |         /  /\r\n    |     || |        /  /\r\n     `r-._||/   __   /  /\r\n __,-<_     )`-/  `./  /\r\n'  \\   `---'   \\   /  /\r\n    |           |./  /\r\n    /           //  /\r\n\\_/' \\         |/  /\r\n |    |   _,^-'/  /\r\n |    , ``  (\\/  /_\r\n  \\,.->._    \\X-=/^\r\n  (  /   `-._//^`\r\n   `Y-.____(__}\r\n    |     {__)\r\n          ()");

    Console.ForegroundColor = ConsoleColor.DarkRed;


}

void printGob()
{
    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine("             ,      ,\r\n            /(.-\"\"-.)\\\r\n        |\\  \\/      \\/  /|\r\n        | \\ / =.  .= \\ / |\r\n        \\( \\   o\\/o   / )/\r\n         \\_, '-/  \\-' ,_/\r\n           /   \\__/   \\\r\n           \\ \\__/\\__/ /\r\n         ___\\ \\|--|/ /___\r\n       /`    \\      /    `\\\r\n      /       '----'       \\");

    Console.ForegroundColor = ConsoleColor.DarkRed;


}

void printgOver()
{
    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀\r\n██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼\r\n██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀\r\n██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼\r\n███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄\r\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼\r\n██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼\r\n██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼\r\n██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼\r\n███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄\r\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");

    Console.ForegroundColor = ConsoleColor.DarkRed;
}

void printyWon()
{
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine("  ___    ___ ________  ___  ___          ___       __   ________  ________   ___       \r\n |\\  \\  /  /|\\   __  \\|\\  \\|\\  \\        |\\  \\     |\\  \\|\\   __  \\|\\   ___  \\|\\  \\      \r\n \\ \\  \\/  / | \\  \\|\\  \\ \\  \\\\\\  \\       \\ \\  \\    \\ \\  \\ \\  \\|\\  \\ \\  \\\\ \\  \\ \\  \\     \r\n  \\ \\    / / \\ \\  \\\\\\  \\ \\  \\\\\\  \\       \\ \\  \\  __\\ \\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\ \\  \\    \r\n   \\/  /  /   \\ \\  \\\\\\  \\ \\  \\\\\\  \\       \\ \\  \\|\\__\\_\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\ \\__\\   \r\n __/  / /      \\ \\_______\\ \\_______\\       \\ \\____________\\ \\_______\\ \\__\\\\ \\__\\|__|   \r\n|\\___/ /        \\|_______|\\|_______|        \\|____________|\\|_______|\\|__| \\|__|   ___ \r\n\\|___|/                                                                           |\\__\\\r\n                                                                                  \\|__|\r\n                                                                                       ");

    Console.ForegroundColor = ConsoleColor.DarkRed;
}

string playAgain = "y";

do
{

    playerStrength = 100;
    playerHealth = 100;
    playerAttack = 0;
    playerNext = 0;
    playerDNext = 0;


    gobStrength = 100;
    gobHealth = 100;
    gobAttack = 0;
    gobNext = 0;
    gobDNext = 0;

    do
    {

        Console.WriteLine("Let the fight begin! Press `Enter` to start: ");

        Console.ReadLine();

        printPlayer();

        printGob();

        if (playerStrength <= 0)
        {
            Console.WriteLine("Your health has decreased by 50 as you have no strength left!");

            playerHealth = playerHealth - 50;

        }
        else if (gobStrength <= 0)
        {
            Console.WriteLine("The goblin's health has decreased by 55 as it as no strength left!");

            gobHealth = gobHealth - 50;

        }
        else if (playerStrength <= 0 && gobStrength <= 0)
        {
            Console.WriteLine("You both have no strength left! You both can no longer fight any rounds! The winner of the fight will now be announced!");

            playerHealth = 0;

            gobHealth = 0;
        }

        if (playerHealth <= 30 && playerStrength <= 30)
        {
            Console.Write("Do you want to drink some Magic Mania Potion (y/n)?: ");

            pDrink = Console.ReadLine();

            if (pDrink == "Y" || pDrink == "y")
            {
                p = randomName.Next(0, probDrink.Length);
                if (probDrink[p] == "Yes")
                {
                    Console.WriteLine("You have drank some Magic Mania Potion! You gained 30 health and 20 strength!");

                    playerHealth += 30;

                    playerStrength += 20;
                }
                else if (probDrink[p] == "No")
                {
                    Console.WriteLine("You dropped the potion! The glass bottle shattered on your feet! You lost 17 health and 7 strength!");

                    playerHealth -= 17;

                    playerStrength -= 7;
                }
            }
        }

        playerNext = playerDie.Next(7);

        gobNext = gobDie.Next(7);

        Console.Write("Do you want to attack (a) or defend (d)?: ");

        fightChoice = Console.ReadLine();

        if (fightChoice == "a" || fightChoice == "A")
        {
            if ((playerNext == 4 || playerNext == 2) || (gobNext == 1 || gobNext == 6))
            {
                Console.WriteLine("The goblin drank some Magic Mania potion! It has gained 30 points of health and 10 points of strength!");

                gobHealth = gobHealth + 30;

                gobStrength = gobStrength + 10;

                gobDNext = gobDie.Next(51);

                Console.WriteLine($"The goblin dealt {gobDNext} damage to you!");

                playerHealth = playerHealth - gobDNext;

                playerStrength = playerHealth - (gobDNext + 10);

            }
            else if ((playerNext == 1 || playerNext == 6) || (gobNext == 4 || gobNext == 2))
            {
                Console.WriteLine("You gathered all of your strength to help you fight the goblin. Some energy of your sword has been transferred to you. You have gained 20 points of health and 5 points of strength!");

                playerHealth = playerHealth + 20;

                playerStrength = playerStrength + 5;

                playerAttack = playerHealth + playerStrength;

                gobAttack = gobHealth + gobStrength;

                if (gobAttack > playerAttack)
                {
                    gobDNext = gobDie.Next(51);

                    Console.WriteLine($"The goblin dealt {gobDNext} damage to you!");

                    playerHealth = playerHealth - gobDNext;

                    playerStrength = playerStrength - (gobDNext + 13);

                }
                else if (playerAttack > gobAttack)
                {
                    playerDNext = playerDie.Next(48);

                    Console.WriteLine($"You dealt {playerDNext} damage to the goblin!");

                    gobHealth = gobHealth - playerDNext;

                    gobStrength = gobStrength - (playerDNext + 8);
                }
            }
            else
            {
                Console.WriteLine("A random name picker will decide who deals damage to who!");

                r = randomName.Next(0, outcomes.Length);

                if (outcomes[r] == "Player")
                {
                    Console.WriteLine("You have been awarded the special attack! You dealt 35 damage to the goblin!");

                    gobHealth = gobHealth - 18;

                    gobStrength = gobStrength - 28;

                }
                else if (outcomes[r] == "Goblin")
                {
                    Console.WriteLine("The goblin has been awarded the special attack! It dealt 30 damage to you!");

                    playerHealth = playerHealth - 28;

                    playerStrength = playerStrength - 38;

                }
            }

            Console.WriteLine("Round results: ");
            Console.WriteLine($"Player Health: {playerHealth}");
            Console.WriteLine($"Player Strength: {playerStrength}");
            Console.WriteLine($"\nGoblin Health: {gobHealth}");
            Console.WriteLine($"Goblin Strength: {gobStrength}");

        } else if (fightChoice == "d" || fightChoice == "D")
        {
            gobANext = gobDie.Next(7);

            if (gobANext == 5 || gobANext == 6 || gobANext == 3)
            {
                Console.WriteLine("The goblin dealt 25 damage to you!");

                playerHealth = playerHealth - 25;

                playerStrength = playerStrength - 27;
            } else
            {
                Console.WriteLine("You blocked the goblin's attack!");
            }

            Console.WriteLine("Round results: ");
            Console.WriteLine($"Player Health: {playerHealth}");
            Console.WriteLine($"Player Strength: {playerStrength}");
            Console.WriteLine($"\nGoblin Health: {gobHealth}");
            Console.WriteLine($"Goblin Strength: {gobStrength}");

        }


    } while (playerHealth >= 0 && gobHealth >= 0);

    if (playerHealth < gobHealth)
    {
        printgOver();

        Console.WriteLine("You have been defeated by the goblin!");

        Console.Write("Do you want to play again (y/n)?: ");

        playAgain = Console.ReadLine();

    }
    else if (gobHealth < playerHealth)
    {
        printyWon();

        Console.WriteLine("You have defeated the goblin!");

        Console.Write("Do you want to play again (y/n)?: ");

        playAgain = Console.ReadLine();

    }

} while (playAgain == "Y" || playAgain == "y");
