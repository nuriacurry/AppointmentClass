using System;

public class Appointment
{
    // 2D array to track minute availability: [period][minute]
    // periods 1-8, minutes 0-59 for each period
    private bool[,] schedule;
    
    /// <summary>
    /// Constructor - Initializes the appointment schedule
    /// All minutes in all periods start as available (true)
    /// </summary>
    public Appointment()
    {
        // Initialize schedule: 8 periods (1-8) x 60 minutes (0-59)
        // Using periods 1-8, so array size is 9 to use indices 1-8
        schedule = new bool[9, 60];
        
        // Initialize all minutes as available (true)
        for (int period = 1; period <= 8; period++)
        {
            for (int minute = 0; minute < 60; minute++)
            {
                schedule[period, minute] = true;
            }
        }
    }
    
    /// <summary>
    /// Helper Method: Check if a specific minute in a period is free
    /// Preconditions: 1 <= period <= 8, 0 <= minute <= 59
    /// </summary>
    /// <param name="period">The class period (1-8)</param>
    /// <param name="minute">The minute within the period (0-59)</param>
    /// <returns>True if the minute is available, false if reserved</returns>
    public bool isMinuteFree(int period, int minute)
    {
        // Validate preconditions
        if (period < 1 || period > 8 || minute < 0 || minute > 59)
        {
            throw new ArgumentException("Invalid period or minute value");
        }
        
        return schedule[period, minute];
    }
    
    /// <summary>
    /// Helper Method: Reserve a consecutive block of minutes in a period
    /// Preconditions: 1 <= period <= 8, 0 <= startMinute <= 59, 1 <= duration <= 60
    /// </summary>
    /// <param name="period">The class period (1-8)</param>
    /// <param name="startMinute">Starting minute of the block (0-59)</param>
    /// <param name="duration">Duration in minutes (1-60)</param>
    public void reserveBlock(int period, int startMinute, int duration)
    {
        // Validate preconditions
        if (period < 1 || period > 8 || startMinute < 0 || startMinute > 59 || 
            duration < 1 || duration > 60 || startMinute + duration > 60)
        {
            throw new ArgumentException("Invalid parameters for reserveBlock");
        }
        
        // Mark consecutive minutes as reserved (false)
        for (int minute = startMinute; minute < startMinute + duration; minute++)
        {
            schedule[period, minute] = false;
        }
    }
    
    /// <summary>
    /// Part (a): Find the earliest available block of specified duration in a period
    /// </summary>
    /// <param name="period">The class period to search (1-8)</param>
    /// <param name="duration">Required duration in minutes</param>
    /// <returns>Starting minute of the earliest free block, or -1 if none found</returns>
    public int findFreeBlock(int period, int duration)
    {
        // Validate parameters
        if (period < 1 || period > 8 || duration < 1 || duration > 60)
        {
            return -1;
        }
        
        // Search for consecutive free minutes
        for (int startMinute = 0; startMinute <= 60 - duration; startMinute++)
        {
            bool blockAvailable = true;
            
            // Check if the entire block is available
            for (int minute = startMinute; minute < startMinute + duration; minute++)
            {
                if (!isMinuteFree(period, minute))
                {
                    blockAvailable = false;
                    break;
                }
            }
            
            // If entire block is available, return starting minute
            if (blockAvailable)
            {
                return startMinute;
            }
        }
        
        // No suitable block found
        return -1;
    }
    
    /// <summary>
    /// Part (b): Make an appointment within a range of periods
    /// </summary>
    /// <param name="startPeriod">Starting period to search (1-8)</param>
    /// <param name="endPeriod">Ending period to search (1-8)</param>
    /// <param name="duration">Required duration in minutes</param>
    /// <returns>True if appointment successfully made, false otherwise</returns>
    public bool makeAppointment(int startPeriod, int endPeriod, int duration)
    {
        // Validate parameters
        if (startPeriod < 1 || startPeriod > 8 || endPeriod < 1 || endPeriod > 8 ||
            startPeriod > endPeriod || duration < 1 || duration > 60)
        {
            return false;
        }
        
        // Search through each period in the range
        for (int period = startPeriod; period <= endPeriod; period++)
        {
            // Find free block in current period
            int freeStartMinute = findFreeBlock(period, duration);
            
            // If free block found, reserve it and return success
            if (freeStartMinute != -1)
            {
                reserveBlock(period, freeStartMinute, duration);
                return true;
            }
        }
        
        // No suitable block found in any period
        return false;
    }
    
    /// <summary>
    /// Utility method for testing: Display current schedule status
    /// </summary>
    public void displaySchedule()
    {
        Console.WriteLine("Current Schedule Status:");
        Console.WriteLine("Period | Minutes Available");
        Console.WriteLine("-------|------------------");
        
        for (int period = 1; period <= 8; period++)
        {
            Console.Write($"   {period}   | ");
            
            for (int minute = 0; minute < 60; minute += 10)
            {
                int available = 0;
                for (int m = minute; m < Math.Min(minute + 10, 60); m++)
                {
                    if (isMinuteFree(period, m)) available++;
                }
                Console.Write($"{minute}-{Math.Min(minute + 9, 59)}({available}/10) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}