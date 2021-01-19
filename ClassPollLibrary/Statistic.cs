using System.Collections.Generic;

namespace ClassPollLibrary
{
    public class Statistic
    {
       public int  ManTo18 { get; set; }
       public int ManFrom18To30 { get; set; }
       public int ManFrom30 { get; set; }
       public int WomanTo18 { get; set; }
       public int WomanFrom18To30 { get; set; }
       public int WomanFrom30 { get; set; }

       public List<ReadyAnswers> Answers { get; set; }
       

    }
}