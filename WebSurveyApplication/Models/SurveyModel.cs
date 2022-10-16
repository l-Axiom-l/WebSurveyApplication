namespace WebSurveyApplication.Models
{
    public class SurveyModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SurveyTableModel> Questions { get; set; }
    }
}
