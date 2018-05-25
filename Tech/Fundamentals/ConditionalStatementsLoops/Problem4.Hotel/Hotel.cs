using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problem4.Hotel
{
    enum Month
    {
        May,
        June,
        July,
        August,
        September,
        October,
        December
    }

    enum Room
    {
        Studio,
        Double,
        Suite
    }


    class RoomPrices
    {
        public Dictionary<Room, decimal> Prices;

        public RoomPrices()
        {
            Prices = new Dictionary<Room, decimal>();
        }

        public RoomPrices(decimal studioPrice, decimal doublePrice, decimal suitePrice) : this()
        {
            Prices.Add(Room.Studio, studioPrice);
            Prices.Add(Room.Double, doublePrice);
            Prices.Add(Room.Suite, suitePrice);
        }
    }

    class DiscountPair
    {
        public int DiscountPercent;
        public int DiscountDays;
    }


    class Hotel
    {
        private static readonly Dictionary<Month, RoomPrices> seasonPrices = new Dictionary<Month, RoomPrices>
        {
            {Month.May, new RoomPrices(50, 65, 75)},
            {Month.October, new RoomPrices(50, 65, 75)},
            {Month.June, new RoomPrices(60, 72, 82)},
            {Month.September, new RoomPrices(60, 72, 82)},
            {Month.August, new RoomPrices(68, 77, 89)},
            {Month.July, new RoomPrices(68, 77, 89)},
            {Month.December, new RoomPrices(68, 77, 89)},
        };

        private static readonly List<Func<Month, Room, int, DiscountPair>> discounts =
            new List<Func<Month, Room, int, DiscountPair>>
            {
                (month, room, nights) =>
                    (month == Month.May || month == Month.October) && nights > 7 && room == Room.Studio
                        ? new DiscountPair{DiscountDays = 0,DiscountPercent = 5}
                        : new DiscountPair{DiscountDays = 0,DiscountPercent = 0},

                (month, room, nights) => (month == Month.June || month == Month.September) && nights > 14 &&
                                         room == Room.Double
                    ? new DiscountPair {DiscountDays = 0, DiscountPercent = 10}
                    : new DiscountPair {DiscountDays = 0, DiscountPercent = 0},
                
                (month, room, nights) =>
                    (month == Month.July || month == Month.August || month == Month.December) && nights > 14 &&
                    room == Room.Suite
                        ?new DiscountPair {DiscountDays = 0, DiscountPercent = 15}
                        : new DiscountPair {DiscountDays = 0, DiscountPercent = 0},

                (month, room, nights) => (month == Month.September || month == Month.October) && nights > 7 &&
                                         room == Room.Studio
                    ? new DiscountPair {DiscountDays = 1, DiscountPercent = 0}
                    : new DiscountPair {DiscountDays = 0, DiscountPercent = 0},

                
            };


        static void Main()
        {
            var month = (Month) Enum.Parse(typeof(Month), Console.ReadLine());
            var nights = int.Parse(Console.ReadLine());
            var roomPrices = getRoomPrice(month, nights);
            printPrices(roomPrices);
        }

        private static void printPrices(RoomPrices roomPrices)
        {
            foreach (var roomPrice in roomPrices.Prices)
            {
                Console.WriteLine($"{roomPrice.Key.ToString()}: {roomPrice.Value:0.00} lv.");
            }
        }

        static RoomPrices getRoomPrice(Month month, int nightCount)
        {
            var basePrices = seasonPrices[month];
            var resultPrices = new RoomPrices();
           
            
            foreach (var roomPrice in basePrices.Prices)
            {
                var discounts = getDiscounts(month, nightCount, roomPrice.Key);
                var nightsToCharge= nightCount- discounts.DiscountDays;
                var discountPercent = discounts.DiscountPercent;
                decimal resultPrice = (roomPrice.Value * nightsToCharge) * (decimal)(1 - discountPercent / 100.0);
                resultPrices.Prices.Add(roomPrice.Key, resultPrice);
                
            }
            

            return resultPrices;
        }

        private static DiscountPair getDiscounts(Month month, int nightCount, Room room)
        {
            var totalDiscounts = new DiscountPair();
            foreach (var discount in discounts)
            {
                var discountPair = discount(month, room, nightCount);
                totalDiscounts.DiscountDays += discountPair.DiscountDays;
                totalDiscounts.DiscountPercent += discountPair.DiscountPercent;

            }

            return totalDiscounts;


        }
    }
}