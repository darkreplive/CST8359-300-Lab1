// See https://aka.ms/new-console-template for more information
string user="";
IList<string> words = null;
while(user!= "x") //runs when user doesnt choose exit
{
    Console.WriteLine("1 - Import words from file");
    Console.WriteLine("2 - Bubble Sort words");
    Console.WriteLine("3 - LINQ/Lamdba sort words");
    Console.WriteLine("4 - Count the Distinct words");
    Console.WriteLine("5 - First ten words");
    Console.WriteLine("6 - Get and display words that start with 'j' and display the count");
    Console.WriteLine("7 - Get and display words that end with 'd' and display the count");
    Console.WriteLine("8 - Get and display words that are greater than 4 characters long, and display the count");
    Console.WriteLine("9 - Get and display words that are less than 3 characters long and start with the letter 'a', and display the count");
    Console.WriteLine("x – Exit");
    user = Console.ReadLine();
    Console.WriteLine("Select Option: " + user);
    switch (user)
    {
        case "1":
            try{
                words = File.ReadAllLines("C:\\Users\\darkr\\source\\repos\\CST8359\\Lab1\\Lab1\\Words.txt").ToArray(); //replace with whatever file path is necessary
                Console.WriteLine("File has "+words.Count+" words");
            }
            catch(Exception e){Console.WriteLine(e);}
            break;

        case "2":
            if (words != null){
                bubbleSort(words);}
            else{Console.WriteLine("No text has been chosen");}
            break;

        case "3":
            if (words != null){
                lambda(words);
            }
            else { Console.WriteLine("No text has been chosen"); }
            break;

        case "4":
            if (words != null){
                distinct(words);
            }
            else { Console.WriteLine("No text has been chosen"); }
            break;

        case "5":
            if (words != null){
                fTen(words);
            }
            else { Console.WriteLine("No text has been chosen"); }
            break;

        case "6":
            if (words != null){
                startJ(words);
            }
            else { Console.WriteLine("No text has been chosen"); }
            break;

        case "7":
            if (words != null){
                endD(words);
            }
            else { Console.WriteLine("No text has been chosen"); }
            break;

        case "8":
            if (words != null){
                fLong(words);
            }
            else { Console.WriteLine("No text has been chosen"); }
            break;

        case "9":
            if (words != null){
                tLongstartA(words);
            }
            else { Console.WriteLine("No text has been chosen"); }
            break;

        case "x":
            Console.WriteLine("Goodbye");
            break;

        default: Console.WriteLine("Please input one of the listed options");
            user = null;
            break;
    }
}//while ends

void bubbleSort(IList<string> input)
{
    IList<string> temp = input;
    var counter = input.Count - 1;
    for (var i = 0; i < counter; i++) //https://codesnippets.fesslersoft.de/bubblesort-ilists/
    {
        for (var index = counter; index > i; index--)
        {
            if (((IComparable)temp[index - 1]).CompareTo(temp[index]) <= 0) continue;
            var hold = temp[index - 1];
            temp[index - 1] = temp[index];
            temp[index] = hold;
        }
    }
    foreach(var a in temp)
    {
        Console.WriteLine(a);
    }
}

void lambda(IList<string> input)
{
    var list = input.OrderBy(x => x).ToList();
    foreach (var a in list)
    {
        Console.WriteLine(a);
    }
}

void distinct(IList<string> input)
{
    var list = input.Distinct();
    /**foreach (var a in list)
    {
        Console.WriteLine(a);
    }
    */
    Console.WriteLine(list.Count() + " many distict words");
}

void fTen(IList<string> input)
{
    var list = input.Take(10).ToList();
    foreach (var a in list)
    {
        Console.WriteLine(a);
    }
}

void startJ(IList<string> input)
{
    var list = from l in input where l.StartsWith("j") select l;
    foreach (var a in list)
    {
        Console.WriteLine(a);
    }
    Console.WriteLine(list.Count() + " words start with J");
}

void endD(IList<string> input)
{
    IList<string> temp = input;
    var list = from l in input where l.EndsWith("d") select l;
    foreach (var a in list)
    {
        Console.WriteLine(a);
    }
    Console.WriteLine(list.Count() + " words end with D");
}

void fLong(IList<string> input){
    var list = from l in input where l.Length == 4 select l;
    foreach (var a in list)
    {
        Console.WriteLine(a);
    }
    Console.WriteLine(list.Count() + " words are 4 letters long");
}

void tLongstartA(IList<string> input)
{
    var list = from l in input where l.Length == 3 && l.StartsWith("a") select l;
    foreach (var a in list)
    {
        Console.WriteLine(a);
    }
    Console.WriteLine(list.Count() + " words are 3 letters long and start with a");
}