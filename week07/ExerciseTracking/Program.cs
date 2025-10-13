using System;
using System.Collections.Generic;

class program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2025, 10, 3), 30, 3.0));
        activities.Add(new cycling(new DateTime(2025, 10, 5), 30, 9.7));
        activities.Add(new Swimming(new DateTime(2025, 10, 7), 30, 40));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }

}