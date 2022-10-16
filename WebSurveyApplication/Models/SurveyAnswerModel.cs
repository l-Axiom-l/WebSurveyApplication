namespace WebSurveyApplication.Models
{
    public class SurveyAnswerModel
    {
        public int id { get; set; }
        public int SurveyModelId { get; set; }
        public string Answer { get; set; }
    }
}
