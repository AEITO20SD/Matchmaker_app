using System;

namespace Matchmaker_app;

public partial class MainPage : ContentPage
{

    int points;
    char[] vowelsArray;
    string name;
    string name2;
    char[] loveArray;
    char[] alphabet;





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


    private void CalculateMatchByAsciiValue(object sender, EventArgs e)
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
        string result = hundredDifference.ToString();
        TxtResult.Text = result;
    }

    double CustomEase(double t)
    {
        return t == 0 || t == 1 ? t : (int)(5 * t) / 5.0;
    }
    private async void CalculateMatch(object sender, EventArgs e)
    {
        TxtResult.Text = "";
        await progressbar.ProgressTo(0, 0, Easing.Default );
        Random rnd = new Random();
        int random = rnd.Next(1000, 3000);

        await progressbar.ProgressTo(0.5, (uint)random, (Easing)CustomEase);
        Thread.Sleep(500);
        await progressbar.ProgressTo(1, (uint)random, (Easing)CustomEase);

        int points = 0;
        string name = firstnamefield.Text;
        string name2 = secondnamefield.Text;
        name = name.ToLower();
        name2 = name2.ToLower();
        string name1FirstChar = name.Substring(0, 1);
        string name2FirstChar = name2.Substring(0, 1);
        vowelsArray = new char[] { 'a', 'e', 'i', 'o', 'u'};
        loveArray = new char[] { 'l', 'o', 'v', 'e' };


        int isName1FirstLetterAVowel = CountChars(name1FirstChar, vowelsArray, false);
        int isName2FirstLetterAVowel = CountChars(name2FirstChar, vowelsArray, false);
        if (isName1FirstLetterAVowel == isName2FirstLetterAVowel)
        {
            points = points + 10;
        }

        int isName1FirstLetterAConstant = CountChars(name1FirstChar, vowelsArray, true);
        int isName2FirstLetterAConstant = CountChars(name2FirstChar, vowelsArray, true);
        if ( isName1FirstLetterAConstant == isName2FirstLetterAConstant)
        {
            points = points + 10;
        }


        int numberOfLettersName1 = name.Count();
        int numberOfLettersName2 = name2.Count();
        if (numberOfLettersName1 == numberOfLettersName2)
        {
            points = points + 20;
        }

        int numberOfVowelsName1 = CountChars(name, vowelsArray, false); //klinkers
        int numberOfVowelsName2 = CountChars(name2, vowelsArray, false);
        if (numberOfVowelsName1 == numberOfVowelsName2)
        {
            points = points + 20;
        }

        int numberOfConstantsName1 = CountChars(name, vowelsArray, true); //medeklinkers
        int numberOfConstantsName2 = CountChars(name2, vowelsArray, true);
        if (numberOfConstantsName1 == numberOfConstantsName2)
        {
            points = points + 20;
        }

        int numberOfLoveName1 = CountChars(name, loveArray, false);
        int numberOfLoveName2 = CountChars(name2, loveArray, false);

        if (numberOfLoveName1 != 0) {
            numberOfLoveName1 = numberOfLoveName1 * 5;
            points = points + numberOfLoveName1;
        }
        if (numberOfLoveName2 != 0)
        {
            numberOfLoveName2 = numberOfLoveName2 * 5;
            points = points + numberOfLoveName2;
        }
        string result = points.ToString();
        TxtResult.Text = result;
    }
}

