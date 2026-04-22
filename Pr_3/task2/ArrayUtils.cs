using System;
using System.Collections.Generic;
using System.Text;

static class ArrayUtils
{
    public static string FindMostPopularCity(Person[] people)
    {
        string mostCity = "";
        int maxCount = 0;
        for (int i = 0; i < people.Length; i++)
        {
            string currentCity = people[i].City;
            int count = 0;

            for (int j = 0; j < people.Length; j++)
            {
                if (people[j].City == currentCity)
                    count++;
            }
            if (count > maxCount)
            {
                maxCount = count;
                mostCity = currentCity;
            }
        }
        return mostCity;
    }
}