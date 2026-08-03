using System.Linq;

public class ScholarshipStudent : Student
{
    public override double CalculateFee()
    {
        int totalCredits = EnrolledCourses.Sum(c => c.Credits);

        double fee = totalCredits * 1000;

        return fee * 0.5;
    }
}