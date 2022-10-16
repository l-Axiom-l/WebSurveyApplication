using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSurveyApplication.Data;
using WebSurveyApplication.Models;

namespace WebSurveyApplication.Pages
{
    [BindProperties(SupportsGet = true)]
    public class SurveyQuestionModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public int SurveyModelId { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }

        public SurveyQuestionModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            List<SurveyTableModel> Questions = _context.SurveyTableModel.Where(x => x.SurveyModelid == SurveyModelId).ToList();
            Question = Questions.ElementAt(QuestionId).Question;
            QuestionType = Questions.ElementAt(QuestionId).QuestionType;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
