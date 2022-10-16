using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using WebSurveyApplication.Data;
using WebSurveyApplication.Models;
using System.Linq;

namespace WebSurveyApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        [BindProperty(SupportsGet = true)] public List<SurveyModel> surveyModels{ get; set; }
        [BindProperty(SupportsGet = true)] public static string test { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Test()
        {
            SurveyTableModel model = new SurveyTableModel()
            {
                Question = "Why is the Grass green",
                QuestionType = "string"
            };

            SurveyTableModel model2 = new SurveyTableModel()
            {
                Question = "Why is the Smaragd green",
                QuestionType = "string"
            };

            SurveyTableModel model3 = new SurveyTableModel()
            {
                Question = "Why is the Paint green",
                QuestionType = "string"
            };
            SurveyModel temp = new SurveyModel { Name = "Test2Survey", Description = "Green Survey", Questions = new List<SurveyTableModel> {model, model2, model3 } };
            _context.SurveyModels.Add(temp);
            _context.SaveChanges();
            Debug.WriteLine("Fuck you");
            test = test == "HalloWelt" ? "HelloWorld" : "HalloWelt";
            return Page();
        }

        public void OnGet()
        {
            surveyModels = _context.SurveyModels.ToList<SurveyModel>();
        }
    }
}