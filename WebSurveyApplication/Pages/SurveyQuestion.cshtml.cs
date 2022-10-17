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
        public string Answer { get; set; } = "";
        public bool AnswerBool { get; set; } = false;

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
            Console.WriteLine("Answer:" + AnswerBool);
            SurveyAnswerModel answer = new SurveyAnswerModel();
            answer.Answer = Answer.Length < 1 ? AnswerBool.ToString() : Answer;
            answer.SurveyModelId = SurveyModelId;
            answer.QuestionId = QuestionId;
            answer.AccountName = HttpContext.Session.GetString("Username");
            _context.AnswerModels.Add(answer);
            Console.WriteLine("Answer:" + AnswerBool);
            _context.SaveChanges();
            Console.WriteLine("Answer:" + AnswerBool);
            QuestionId++;
            if (_context.SurveyTableModel.Where(x => x.SurveyModelid == SurveyModelId).Count() > QuestionId)
                return RedirectToPage("SurveyQuestion", new { SurveyModelId, QuestionId });
            else
                return RedirectToPage("Index");
        }
    }
}
