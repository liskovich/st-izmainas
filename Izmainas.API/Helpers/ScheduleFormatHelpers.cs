using Izmainas.API.Domain.Contracts.Client.Student;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Izmainas.API.Helpers
{
    public static class ScheduleFormatHelpers
    {
        public static SeparatedResult SeparateSubjectFromRoom(string input) //this
        {
            //var result = input.Split('&', StringSplitOptions.TrimEntries);
            //var output = new SeparatedResult();

            //output.Subjects = result[0].Split('/', StringSplitOptions.RemoveEmptyEntries);
            //output.Rooms = result[1].Split('/', StringSplitOptions.RemoveEmptyEntries);

            //return output;

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

        public static IEnumerable<TreeItem<T>> GetTreeItems<T, K>(
            this IEnumerable<T> collection, 
            Func<T, K> idSelector,
            Func<T, K> parentIdSelector,
            K rootId = default(K))
        {
            foreach (var c in collection.Where(c => EqualityComparer<K>.Default.Equals(parentIdSelector(c), rootId)))
            {
                yield return new TreeItem<T>
                {
                    Item = c,
                    Children = collection.GetTreeItems(idSelector, parentIdSelector, idSelector(c))
                };
            }
        }
    }

    public class SeparatedResult
    {
        public List<string> Subjects { get; set; }
        public List<string> Rooms { get; set; }
    }

    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }
}
