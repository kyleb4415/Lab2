using Lab2;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;



string projectRootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
string filePath = $"{projectRootFolder}{Path.DirectorySeparatorChar}videogames.csv";
var videoGames = new List<VideoGame>();

//reading a list of video games 
using (var sr = new StreamReader(filePath))
{
    sr.ReadLine();

    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        string[] lineData = line.Split(',');
        VideoGame vg = new VideoGame(lineData[0].Trim(), lineData[1].Trim(), lineData[2].Trim(), lineData[3].Trim(), lineData[4].Trim(), Convert.ToDouble(lineData[5].Trim()),
                      Convert.ToDouble(lineData[6].Trim()), Convert.ToDouble(lineData[7].Trim()), Convert.ToDouble(lineData[8].Trim()), Convert.ToDouble(lineData[9].Trim()));
        videoGames.Add(vg);
    }

}

//begin text adventure portion, 1st is variable declaration

//dictionary creation
//-------------------------------------------------------------------------------
videoGames.Sort();
Dictionary<int, string> videoGameDictionary = new Dictionary<int, string>();
int dictionaryCounter = 1;

//shuffling the list for the game
//-------------------------------------------------------------------------------
videoGames = Shuffle(videoGames);

//stack creation
//-------------------------------------------------------------------------------

Stack<VideoGame> stackOfGames = new Stack<VideoGame>();

//queue creation
//-------------------------------------------------------------------------------
Queue<VideoGame> queueOfGames = new Queue<VideoGame>();

//counter creation to keep track of how many 'disks' are on the ground
int counter = videoGames.Count - 1;

//game
int menuSelection = 0;
while(menuSelection != 2)
{
    Console.WriteLine("WELCOME TO DISK ADVENTURE VERSION 1.0");
    Console.WriteLine("-----------------------------------------------------");
    Console.WriteLine("1. Start");
    Console.WriteLine("2. Exit");
    Console.Write("Please choose your selection: ");

    //input validation - see method at the bottom
    //-------------------------------------------------------------------------------
    menuSelection = IntegerSelection(Console.ReadLine(), 1, 2);
        
    Console.Write("Please enter your name: ");
    string name = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine("You're at home. The mail comes, and you discover you've received a letter from your father.\n-\n");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Dear {name}, \n\n" +
        $"I know our correspondences have been sparse, so you must be surprised that I am writing you. " +
        $"I have recently acquired a friend's Compact Disk collection, and I'd like you to come take a look at them. " +
        $"You always were so good with CDs. You may take any you are interested in, if that's incentive enough to make the drive. " +
        $"\n\nBest regards,\n" +
        $"Dad");

    Console.ResetColor();
    Console.WriteLine("\nPress enter to continue.");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.ReadLine();
    Console.Clear();
    Console.ResetColor();

    Console.WriteLine("I'm good with CDs? What is he talking about? I do love me some CDs, though. What about I make a visit? It's only a 6 hour drive.");
    Console.WriteLine("1. Make the visit");
    Console.WriteLine("2. Ignore him");
    Console.Write("Please enter your selection: ");

    //begin CD game portion
    //-------------------------------------------------------------------------------

    int goToDadsSelection = IntegerSelection(Console.ReadLine(), 1, 2);

    switch (goToDadsSelection)
    {
        //choosing to make the drive 
        //-------------------------------------------------------------------------------
        case 1:
            Console.Clear();

            Console.WriteLine("After an uneventful drive, you pull up to the house. It's just as you remember it.. but something's off. " +
                "You sigh and ready yourself for the daunting task that lies ahead. What hidden treasures will you find?");

            Console.WriteLine("What should you do next?\n");

            Console.WriteLine("1. Knock on the door");
            Console.WriteLine("2. Look around the house\n");

            Console.Write("Enter your choice: ");

            int houseSelection = IntegerSelection(Console.ReadLine(), 1, 2);

            //begin choice at house
            //-------------------------------------------------------------------------------
            switch (houseSelection)
            { 
                case 1:
                    Console.Clear();
                    Console.WriteLine("You knock on the door, however, no one answers. You knock again, only for the deadbolt to seemingly unlock on its own. " +
                        "The door slowly creaks open, revealing the vast expanse of the house. You notice vast swaths of CDs scattered about the floor of the house.\n\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A voice calls from deep within the darkness: 'My apologies for the mess, just find a clean spot and examine them, will you?" +
                        "That book you see augurs the worth of the disk once you've picked it up.'\n\n");
                    Console.ResetColor();

                    Console.WriteLine("You pick up the book labeled 'Disktionary' and open it. " +
                        "It's blank, but you guess it will fill up when you collect disks. You look down at the scattered pile before you. " +
                        "Interestingly, many titles here seem to not have been created for CD playing devices. What's going on?\n");
                    Console.WriteLine("1. Begin collecting disks onto your CD stack");
                    Console.WriteLine("2. Leave");
                    Console.Write("Selection: ");

                    //begin functionality of stack, queue, and dictionary
                    //-------------------------------------------------------------------------------
                    int activitySelection = IntegerSelection(Console.ReadLine(), 1, 2);

                    
                    switch (activitySelection)
                    {
                        case 1:
                            int stackingSelection = 2;
                            while(stackingSelection != -1)
                            {
                                Console.Clear();
                                Console.WriteLine($"You pick up a disk off the ground. It reads '{videoGames[counter].Name}'. You add it to the stack. It's written to your disktionary.\n\n");

                                //adding video game to disktionary after adding to stack
                                //-------------------------------------------------------------------------------
                                videoGameDictionary.Add(dictionaryCounter++, "Name: " + videoGames[counter].Name + " | " + "Platform: " + videoGames[counter].Platform + " | " +
                                    "Sales (in millions USD): " + videoGames[counter].GlobalSales);
                                if(counter < videoGames.Count)
                                    stackOfGames.Push(videoGames[counter]);
                                else
                                {
                                    Console.WriteLine("You've finally picked up all the CDs. Congratulations!");
                                }

                                Console.WriteLine("1. Stop Stacking");
                                Console.WriteLine("2. Keep Stacking");
                                Console.WriteLine("3. Pop some disks off your stack");
                                Console.WriteLine("4. Look in your disktionary");
                                Console.WriteLine("5. Add the disk into 'To Try' queue");
                                Console.WriteLine("6. Leave with your haul");
                                
                                Console.Write("Enter your selection: ");

                                stackingSelection = IntegerSelection(Console.ReadLine(), 1, 6);

                                if(stackingSelection == 1)
                                {
                                    Console.WriteLine("You stop stacking and take a break. Once you get past the impenetrable wall of darkness, this place really isn't that bad. " +
                                        "Much larger than your meagre apartment in the city. You turn on your phone flashlight and walk a little into the darkness, but don't find anything interesting.");
                                    Console.WriteLine("Press enter to continue stacking");
                                    Console.ReadLine();
                                }
                                if(stackingSelection == 2)
                                {
                                    Console.Clear();
                                    counter--;
                                    continue;
                                }


                                else if(stackingSelection == 3)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"You firmly plant your thumb under the top disk, {stackOfGames.Pop().Name} before flinging it into the darkness beyond. " +
                                        $"No clatter of the disk hitting the floor is heard. It must be lost forever.");
                                    Console.WriteLine("Press enter to continue.");
                                    counter--;
                                    Console.ReadLine();
                                }


                                else if (stackingSelection == 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"You've cataloged {videoGames.Count() - counter} CDs so far. You write a number next to each disk to identify it (starting with 1)");
                                    Console.Write("Enter the number of your disk: ");
                                    int diskNum = IntegerSelection(Console.ReadLine(), 1, videoGameDictionary.Count());
                                    Console.WriteLine($"The {diskNum} entry in your disktionary is {videoGameDictionary.ElementAt(diskNum - 1)}\n\n");
                                    Console.WriteLine("It's up to you to judge whether this is worth keeping.\n\n");
                                    counter--;
                                    Console.WriteLine("Press enter to continue.");
                                    Console.ReadLine();
                                }

                                else if (stackingSelection == 5)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"You pop off the top disk and add it into the next available slot in your CD case. You can't wait to try {stackOfGames.Last().Name} " +
                                        $"when you get home!\n\n");
                                    queueOfGames.Enqueue(stackOfGames.Pop());
                                    Console.WriteLine("Press enter to continue.");
                                    counter--;
                                    Console.ReadLine();
                                }


                                else if (stackingSelection == 6)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You set down your father's stack of CDs and turn to leave. As you're leaving, a voice calls out to you.\n\n");
                                    Console.ForegroundColor = ConsoleColor.Red;

                                    Console.WriteLine($"'Come back soon {name}. Your work is unfinished'\n\n");

                                    Console.ResetColor();
                                    Console.WriteLine("As you step through the threshold of the doorway, a cold gust of wind slams the door closed.");
                                    Console.WriteLine($"You collected {queueOfGames.Count()} CDs for yourself!");
                                    Console.WriteLine($"You stacked {stackOfGames.Count()} CDs!");
                                    Console.WriteLine($"You cataloged {videoGameDictionary.Count()} CDs!");
                                    if(queueOfGames is not null)
                                        Console.WriteLine($"The first game you try when you get home is {queueOfGames.Dequeue().Name}. It's awesome!");
                                    Console.WriteLine("And then everyone lived happily ever after. The end.\n\n");

                                    Console.WriteLine("Press enter to exit");
                                    Console.ReadLine();
                                    menuSelection = 2;
                                }
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("You're incredibly sketched out by this whole situation. An infinite house, a disembodied voice imitating " +
                                "your father coming from the impenetrable darkness, and the disarray of the CDs has sent off your alarm bells. You close the door behind you and leave.");
                            Console.WriteLine("Press exit to close.");
                            Console.ReadLine();
                            menuSelection = 2;
                            stackingSelection = -1;
                            break;
                    }
                    break;

                //wraps back to case 1 for game purposes (decision game where you don't really have a choice, what's new?)
                case 2:
                    Console.Clear();
                    Console.WriteLine("You look around the right side of the house and discover it stretches an infinite distance behind itself. The left side is the same. You return to the door.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    goto case 1;
            }
            break;
        //game-ending choice
        case 2:
            Console.Clear();
            Console.WriteLine("You don't go to your Dad's. Wait a minute, he doesn't know your new address, does he? Who's writing?");
            Console.WriteLine("The end");
            Console.WriteLine("\nPress enter to exit");
            Console.ReadLine();
            break;
    }
}



videoGames.Sort();
Console.WriteLine(videoGames[1]);



Console.WriteLine(videoGames[1]);


Random rand = new Random();
int randomGame = rand.Next(0, videoGames.Count);



Dictionary<string, string> videoGameData = new Dictionary<string, string>();



List<VideoGame> Shuffle(List<VideoGame> videoGames)
{
    Random rand = new Random();
    for (int i = 0; i < videoGames.Count; i++)
    { 
        int r = rand.Next(videoGames.Count - 1);
        VideoGame temp = new VideoGame(videoGames[i]);
        videoGames[i] = videoGames[r];
        videoGames[r] = temp;
    }
    return videoGames;
}

int IntegerSelection(string input, int minValue, int maxValue)
{
    int selection;

    while (Int32.TryParse(input, out selection) == false || selection > maxValue || selection < minValue)
    {
        Console.Write("Invalid input. Please provide an appropriate selection: ");
        input = Console.ReadLine();
    }

    return selection;
}

