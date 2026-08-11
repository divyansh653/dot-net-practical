using _10_Augest.Models;

namespace _10_Augest.Repository
{
    public interface ICompanyService
    {
        Company CreateCompany(Company company);

        List<Company> GetCompanies();

        Company? GetCompanyById(int id);
    }
}