using System;

namespace Matchmaker_app;

public partial class MainPage : ContentPage
{
    int points;
    char[] vowelsArray;
    string name;
    string name2;






    public MainPage()
	{
		InitializeComponent();
	}

    private static int CountChars(string searchIn, char[] searchFor, bool inverse)
    {
        int result = 0;
        int resultReverse = 0;

        result = searchIn.Count(searchFor.Contains);
        if (inverse)
        {
            for (int i = 0; i < searchFor.Length; i++)
            {
                if (!searchIn.Contains(searchFor[i]))
                {
                    resultReverse++;
                }
            }
        }
        return inverse ? resultReverse : result;
    }

    static int GetAsciiValue(string str)
    {
        int result = 0;
        foreach (char c in str)
        {
            result += (int)c;
        }
        return result;
    }

    private void CalculateMatch(object sender, EventArgs e)
    {
        int difference;
        
        string name = firstnamefield.Text;
        string name2 = secondnamefield.Text;

        int AsciiValueName1 = GetAsciiValue(name);
        int AsciiValueName2 = GetAsciiValue(name2);

        if (AsciiValueName1 > AsciiValueName2)
        {
             difference = AsciiValueName1 - AsciiValueName2;
        }
        else
        {
             difference = AsciiValueName2 - AsciiValueName1;
        }
        int hundredDifference = 100 - difference;

        /*
        vowelsArray = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        int numberOfVowelsName1 = CountChars(name, vowelsArray, false);
        int numberOfVowelsName2 = CountChars(name2, vowelsArray, false);

        int numberOfConstantsName1 = CountChars(name, vowelsArray, true);
        int numberOfConstantsName2 = CountChars(name2, vowelsArray, true);

        int numberOfLoveName1 = CountChars(name, loveArray, false);
        */

        //TxtResult.Text = "Button pushed";
        string result = hundredDifference.ToString();
        TxtResult.Text = result;
    }

    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //count++;

    //if (count == 1)
    //CounterBtn.Text = $"Clicked {count} time";
    //else
    //CounterBtn.Text = $"Clicked {count} times";

    //SemanticScreenReader.Announce(CounterBtn.Text);
    //	}
}

