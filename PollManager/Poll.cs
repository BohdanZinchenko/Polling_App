using System.Collections.Generic;

namespace PollManager
{
    public class Poll
    {
        public int Id { get; set; }
        public string PollName { get; set; }
        public string[] Questions {get; set;}
        public List<VariantAnswers> VariantAnswers { get; set; }
        
    }
}