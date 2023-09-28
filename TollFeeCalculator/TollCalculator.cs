using TollFeeCalculator;

public class TollCalculator
{
    /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

    public int GetTollFee(IVehicle vehicle, List<DateTime> dates)
    {
        if (dates is null || !dates.Any() || vehicle is null)
        {
            return -1;
        }

        if (!DatesIsSameDay(dates))
        {
            return -1;
        }

        if (vehicle.IsTollFree())
        {
            return 0;
        }

        dates = dates.OrderBy(d => d.Ticks).ToList();
        DateTime intervalStart = dates[0];
        int totalFee = 0;

        foreach (DateTime date in dates)
        {
            int nextFee = GetTollFee(date);
            int tempFee = GetTollFee(intervalStart);

            long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            long minutes = diffInMillies / 1000 / 60;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }
        }
        if (totalFee > 60)
        {
            totalFee = 60;
        }

        return totalFee;
    }

    private bool DatesIsSameDay(List<DateTime> dates)
    {
        var minDate = dates.Min();
        var maxDate = dates.Max();

        if (minDate.Date != maxDate.Date)
        {
            return false;
        }
        return true;
    }

    private int GetTollFee(DateTime date)
    {
        if (IsTollFreeDate(date))
        {
            return 0;
        }

        int hour = date.Hour;
        int minute = date.Minute;

        return hour switch
        {
            6 when (minute >= 0 && minute <= 29) => 8,
            6 when (minute >= 30 && minute <= 59) => 13,
            7 when (minute >= 0 && minute <= 59) => 18,
            8 when (minute >= 0 && minute <= 29) => 13,
            8 when (minute <= 30 && minute <= 59) => 8,
            9 when (minute >= 0 && minute <= 59) => 8,
            10 when (minute >= 0 && minute <= 59) => 8,
            11 when (minute >= 0 && minute <= 59) => 8,
            12 when (minute >= 0 && minute <= 59) => 8,
            13 when (minute >= 0 && minute <= 59) => 8,
            14 when (minute >= 0 && minute <= 59) => 8,
            15 when (minute >= 0 && minute <= 29) => 13,
            15 when (minute >= 30 && minute <= 59) => 18,
            16 when (minute >= 0 && minute <= 59) => 18,
            17 when (minute >= 0 && minute <= 59) => 13,
            18 when (minute >= 0 && minute <= 29) => 8,
            _ => 0,
        };
    }

    private bool IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            return true;
        }

        if (year == 2013)
        {
            switch (month)
            {
                case 1 when day == 1:
                    return true;

                case 3 when (day == 28 || day == 29):
                    return true;

                case 4 when (day == 1 || day == 30):
                    return true;

                case 5 when (day == 1 || day == 8 || day == 9):
                    return true;

                case 6 when (day == 5 || day == 8 || day == 21):
                    return true;

                case 7:
                    return true;

                case 11 when day == 1:
                    return true;

                case 12 when (day == 24 || day == 25 || day == 26 || day == 31):
                    return true;
            }
        }
        return false;
    }
}