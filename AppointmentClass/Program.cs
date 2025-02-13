public class Appointment {

private:

   bool schedule[8][60] = {{false}};
   bool isMinuteFree(int period, int minute) {
        
        if (period < 1 || period > 8 || minute < 0 || minute > 59) {
            return false;
        }
        
     
        return !schedule[period-1][minute];
    }

    void reserveBlock(int period, int startMinute, int duration) {
        
        if (period < 1 || period > 8 || 
            startMinute < 0 || startMinute > 59 || 
            duration < 1 || duration > 60 || 
            startMinute + duration > 60) {
            return;  
        }

      
        for (int i = 0; i < duration; i++) {
            schedule[period-1][startMinute + i] = true;  
        }
    }
   
   int findFreeBlock(int period, int duration) {
       if (duration > 60) {
            return -1;
        }
   }

    bool makeAppointment(int startPeriod, int endPeriod, int duration) {

   }

}

