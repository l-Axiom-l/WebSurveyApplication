namespace WebSurveyApplication.Models
{
    public class SurveyAnswerModel
    {
        public int id { get; set; }
        public int SurveyModelId { get; set; }
        public string Answer { get; set; }
        public int QuestionId { get; set; }
        public string AccountName { get; set; }
    }
}
