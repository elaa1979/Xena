namespace Xena.Application.Common.Models
{
    public class Where
    {
        public string Field { get; set; }
        public FilterType FilterType { get; set; }
        public string Value { get; set; }
    }
}