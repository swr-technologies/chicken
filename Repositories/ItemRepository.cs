using Chicken.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Chicken.Repositories
{
    public class ItemRepository
    {

        private IEnumerable<Item> items;

        public ItemRepository()
        {
            StreamReader r = new StreamReader("ChickenData.json");
            string v = r.ReadToEnd();
            string jsonString = v;
            items = JsonConvert.DeserializeObject<IEnumerable<Item>>(jsonString);
        }

        public ItemDTO GetResult()
        {
            /*
                 1. Check date range
                 2. Check time range (30 min interval from 00:00 - 23:59)
                 3. Sum category 0, 1, 2 based on Logic
                    if hasMajorLesion = true (Category 2)
                    else if hasMediumLesion = true (Category 1)
                    else Category 0

             */

            ItemDTO itemDto = new ItemDTO();

            foreach (Item item in items)
            {
                string[] result = item.entryTimeUtc.Split('T')[1].Split('.');
                TimeSpan time = TimeSpan.Parse(result[0]);

                foreach (KeyValuePair<string, int[]> interval in itemDto.TimeIntervals)
                {
                    int cat0 = !item.hasMajorLesion && !item.hasMediumLesion ? 1 : 0;
                    int cat1 = !item.hasMajorLesion && item.hasMediumLesion ? 1 : 0;
                    int cat2 = item.hasMajorLesion ? 1 : 0;

                    var key = interval.Key.Split('_');

                    TimeSpan from = TimeSpan.Parse(key[0]);
                    TimeSpan to = TimeSpan.Parse(key[1]);

                    if (from <= time && time < to)
                    {
                        itemDto.TimeIntervals[interval.Key][0] += cat0;
                        itemDto.TimeIntervals[interval.Key][1] += cat1;
                        itemDto.TimeIntervals[interval.Key][2] += cat2;
                    }
                }
            }

            return itemDto;
        }
    }
}
