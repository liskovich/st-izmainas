using Izmainas.API.Domain.Contracts.Client.Student;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Izmainas.API.Helpers
{
    /// <summary>
    /// Class used to format schedule data before sending it to end user
    /// </summary>
    public static class ScheduleFormatHelpers
    {
        /// <summary>
        /// Method used for splitting combined rooms and subjects each into their separate rows in UI
        /// </summary>
        /// <param name="input">String which contains concatinated rooms and subjects</param>
        /// <returns>Separated room and subject pair</returns>
        public static SeparatedResult SeparateSubjectFromRoom(string input)
        {
            var result = input.Split('&', StringSplitOptions.TrimEntries);
            var output = new SeparatedResult();

            var subjs = result[0].Split('/', StringSplitOptions.RemoveEmptyEntries).ToList();
            var rooms = result[1].Split('/', StringSplitOptions.RemoveEmptyEntries).ToList();

            var roomCount = rooms.Count();
            var subjCount = subjs.Count();
            var smallestCount = Math.Min(roomCount, subjCount);

            var largestArray = roomCount > subjCount ? rooms : subjs;
            var largestArrayName = roomCount > subjCount ? "rooms" : "subjs";
            var smallestArray = roomCount < subjCount ? rooms : subjs;
            var smallestArrayName = roomCount < subjCount ? "rooms" : "subjs";

            for (int i = 0; i < largestArray.Count(); i++)
            {
                if (i >= smallestCount)
                {
                    var lastFromSmallest = smallestArray.Last();
                    smallestArray.Add(lastFromSmallest);
                }
            }

            if (largestArrayName == "rooms" && smallestArrayName == "subjs")
            {
                rooms = largestArray;
                subjs = smallestArray;
            }
            if (largestArrayName == "subjs" && smallestArrayName == "rooms")
            {
                rooms = smallestArray;
                subjs = largestArray;
            }

            output.Rooms = rooms;
            output.Subjects = subjs;

            return output;
        }
    }

    public class SeparatedResult
    {
        public List<string> Subjects { get; set; }
        public List<string> Rooms { get; set; }
    }
}
