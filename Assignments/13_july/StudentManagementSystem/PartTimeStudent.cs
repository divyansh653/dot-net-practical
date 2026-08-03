using System.Linq;

public class PartTimeStudent : Student
{
    public override double CalculateFee()
    {
        int totalCredits = EnrolledCourses.Sum(c => c.Credits);

        return totalCredits * 700;
    }
}