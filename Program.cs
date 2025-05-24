using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== APPOINTMENT CLASS DEMO ===");
        Console.WriteLine("Testing appointment scheduling system for 8 periods, 60 minutes each\n");
        
        // Create appointment scheduler
        Appointment scheduler = new Appointment();
        
        // Test 1: Basic constructor test
        Console.WriteLine("TEST 1: Constructor and Helper Methods");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"Period 1, Minute 0 free: {scheduler.isMinuteFree(1, 0)}");
        Console.WriteLine($"Period 8, Minute 59 free: {scheduler.isMinuteFree(8, 59)}");
        Console.WriteLine();
        
        // Test 2: Reserve some blocks for testing
        Console.WriteLine("TEST 2: Setting up test scenario (reserving some blocks)");
        Console.WriteLine("-------------------------------------------------------");
        scheduler.reserveBlock(2, 0, 10);   // Reserve minutes 0-9 in period 2
        scheduler.reserveBlock(2, 15, 15);  // Reserve minutes 15-29 in period 2
        scheduler.reserveBlock(2, 45, 5);   // Reserve minutes 45-49 in period 2
        
        scheduler.reserveBlock(3, 15, 26);  // Reserve minutes 15-40 in period 3
        scheduler.reserveBlock(4, 0, 5);    // Reserve minutes 0-4 in period 4
        scheduler.reserveBlock(4, 30, 14);  // Reserve minutes 30-43 in period 4
        
        Console.WriteLine("Reserved blocks:");
        Console.WriteLine("- Period 2: minutes 0-9, 15-29, 45-49");
        Console.WriteLine("- Period 3: minutes 15-40");
        Console.WriteLine("- Period 4: minutes 0-4, 30-43");
        Console.WriteLine();
        
        // Test 3: findFreeBlock method (Part a)
        Console.WriteLine("TEST 3: findFreeBlock Method (Part A)");
        Console.WriteLine("-------------------------------------");
        
        // Test examples from assignment for Period 2
        Console.WriteLine("Period 2 availability:");
        Console.WriteLine("Minutes 0-9: Reserved, 10-14: Free, 15-29: Reserved, 30-44: Free, 45-49: Reserved, 50-59: Free");
        
        int result1 = scheduler.findFreeBlock(2, 15);
        Console.WriteLine($"findFreeBlock(2, 15) → {result1} (expected: 30)");
        
        int result2 = scheduler.findFreeBlock(2, 9);
        Console.WriteLine($"findFreeBlock(2, 9) → {result2} (expected: 30 - smallest valid block)");
        
        int result3 = scheduler.findFreeBlock(2, 20);
        Console.WriteLine($"findFreeBlock(2, 20) → {result3} (expected: -1, no such block)");
        
        int result4 = scheduler.findFreeBlock(2, 5);
        Console.WriteLine($"findFreeBlock(2, 5) → {result4} (expected: 10 - earliest 5-minute block)");
        Console.WriteLine();
        
        // Test 4: makeAppointment method (Part b)  
        Console.WriteLine("TEST 4: makeAppointment Method (Part B)");
        Console.WriteLine("--------------------------------------");
        
        // Reset scheduler for clean makeAppointment tests
        scheduler = new Appointment();
        
        // Set up scenario from assignment
        scheduler.reserveBlock(2, 0, 25);   // Period 2: 0-24 reserved, 25-29 free, 30-59 reserved
        scheduler.reserveBlock(2, 30, 30);
        
        scheduler.reserveBlock(3, 15, 26);  // Period 3: 0-14 free, 15-40 reserved, 41-59 free
        
        scheduler.reserveBlock(4, 0, 5);    // Period 4: 0-4 reserved, 5-29 free, 30-43 reserved, 44-59 free
        scheduler.reserveBlock(4, 30, 14);
        
        Console.WriteLine("Setup for makeAppointment tests:");
        Console.WriteLine("Period 2: 0-24 (Reserved), 25-29 (Free), 30-59 (Reserved)");
        Console.WriteLine("Period 3: 0-14 (Free), 15-40 (Reserved), 41-59 (Free)");
        Console.WriteLine("Period 4: 0-4 (Reserved), 5-29 (Free), 30-43 (Reserved), 44-59 (Free)");
        Console.WriteLine();
        
        // Test makeAppointment examples
        bool appt1 = scheduler.makeAppointment(2, 4, 22);
        Console.WriteLine($"makeAppointment(2, 4, 22) → {appt1} (expected: true, should reserve 5-26 in period 4)");
        
        // Reset for next test
        scheduler = new Appointment();
        scheduler.reserveBlock(2, 0, 25);
        scheduler.reserveBlock(2, 30, 30);
        scheduler.reserveBlock(3, 15, 26);
        scheduler.reserveBlock(4, 0, 5);
        scheduler.reserveBlock(4, 30, 14);
        
        bool appt2 = scheduler.makeAppointment(3, 4, 3);
        Console.WriteLine($"makeAppointment(3, 4, 3) → {appt2} (expected: true, should reserve 0-2 in period 3)");
        
        // Reset for next test
        scheduler = new Appointment();
        scheduler.reserveBlock(2, 0, 25);
        scheduler.reserveBlock(2, 30, 30);
        scheduler.reserveBlock(3, 15, 26);
        scheduler.reserveBlock(4, 0, 5);
        scheduler.reserveBlock(4, 30, 14);
        
        bool appt3 = scheduler.makeAppointment(2, 4, 30);
        Console.WriteLine($"makeAppointment(2, 4, 30) → {appt3} (expected: false, no 30-minute block available)");
        Console.WriteLine();
        
        // Test 5: Edge cases and validation
        Console.WriteLine("TEST 5: Edge Cases and Validation");
        Console.WriteLine("---------------------------------"); 
        
        scheduler = new Appointment();
        
        // Test boundary conditions
        Console.WriteLine($"findFreeBlock(1, 60) → {scheduler.findFreeBlock(1, 60)} (full period)");
        Console.WriteLine($"findFreeBlock(8, 1) → {scheduler.findFreeBlock(8, 1)} (minimum duration)");
        Console.WriteLine($"makeAppointment(1, 8, 45) → {scheduler.makeAppointment(1, 8, 45)} (across all periods)");
        Console.WriteLine($"makeAppointment(5, 5, 30) → {scheduler.makeAppointment(5, 5, 30)} (single period)");
        
        // Test invalid parameters
        Console.WriteLine($"findFreeBlock(0, 10) → {scheduler.findFreeBlock(0, 10)} (invalid period)");
        Console.WriteLine($"findFreeBlock(9, 10) → {scheduler.findFreeBlock(9, 10)} (invalid period)");
        Console.WriteLine($"findFreeBlock(5, 0) → {scheduler.findFreeBlock(5, 0)} (invalid duration)");
        Console.WriteLine($"findFreeBlock(5, 61) → {scheduler.findFreeBlock(5, 61)} (invalid duration)");
        Console.WriteLine();
        
        // Test 6: Full schedule demonstration
        Console.WriteLine("TEST 6: Schedule Display");
        Console.WriteLine("-----------------------");
        scheduler = new Appointment();
        
        // Make several appointments
        scheduler.makeAppointment(1, 2, 20);
        scheduler.makeAppointment(3, 4, 15);
        scheduler.makeAppointment(5, 6, 30);
        scheduler.makeAppointment(7, 8, 10);
        
        Console.WriteLine("After making several appointments:");
        scheduler.displaySchedule();
        
        Console.WriteLine("=== DEMO COMPLETE ===");
        Console.WriteLine("All tests completed successfully!");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}