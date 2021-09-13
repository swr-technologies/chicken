using System;
using System.Collections.Generic;

namespace Chicken.Entities
{
    public class ItemDTO
    {
        public Dictionary<string, int[]> TimeIntervals { get; set; } = new Dictionary<string, int[]>();

        public ItemDTO()
        {
            TimeSpan time = TimeSpan.Parse("00:00");

            var format = @"hh\:mm";

            while (time <= TimeSpan.Parse("23:59"))
            {
                string from = time.ToString(format);

                time = time.Add(TimeSpan.Parse("00:30"));
                string to = time.ToString(format);

                TimeIntervals.Add($"{from}_{to}", new int[3] { 0, 0, 0 });
            }
        }
    }
}
