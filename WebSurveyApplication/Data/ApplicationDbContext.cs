using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebSurveyApplication.Models;

namespace WebSurveyApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SurveyModel> SurveyModels { get; set; }
        public DbSet<SurveyAnswerModel> AnswerModels { get; set; }
        public DbSet<SurveyTableModel> SurveyTableModel { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
