namespace TimeManagementApp
{
    public class Calculation
    {
        public int NumberOfCredits;
        public int ClassHoursPerWeek;
        public int NumberOfWeeks;

        public Calculation(int NumberOfCredits, int ClassHoursPerWeek, int NumberOfWeeks)
        {
            this.NumberOfCredits = NumberOfCredits;
            this.ClassHoursPerWeek = ClassHoursPerWeek;
            this.NumberOfWeeks = NumberOfWeeks;
        }

        public double SelfStudy()
        {
            double result = 0;
            result = ((NumberOfCredits * 10) / NumberOfWeeks) - ClassHoursPerWeek;
            return result;
        }
    }
}