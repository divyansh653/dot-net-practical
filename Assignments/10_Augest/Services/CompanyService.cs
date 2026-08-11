using _10_Augest.Data;
using _10_Augest.Models;

namespace _10_Augest.Repository
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext context;

        public CompanyService(AppDbContext context)
        {
            this.context = context;
        }

        public Company CreateCompany(Company company)
        {
            var companyAlreadyExists = context.Companies
                .Any(c => c.CompanyName == company.CompanyName);

            if (companyAlreadyExists)
                throw new ArgumentException("Company already exists");

            context.Companies.Add(company);
            context.SaveChanges();

            return company;
        }

        public List<Company> GetCompanies()
        {
            return context.Companies.ToList();
        }

        public Company? GetCompanyById(int id)
        {
            return context.Companies.FirstOrDefault(c => c.Id == id);
        }
    }
}