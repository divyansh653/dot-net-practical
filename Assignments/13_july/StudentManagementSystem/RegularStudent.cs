using System.Linq;

public class RegularStudent : Student
{
    public override double CalculateFee()
    {
        int totalCredits = EnrolledCourses.Sum(c => c.Credits);

        return totalCredits * 1000;
    }
}