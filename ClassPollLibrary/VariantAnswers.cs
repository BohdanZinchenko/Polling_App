namespace ClassPollLibrary
{
    public class VariantAnswers : IAnswers
    {
        public int IndexQuestion { get; set; }
        public string[] VariantAnswer { get; set; }

    }

    public class ReadyAnswers : IAnswers
    {
        public string[] VariantAnswer { get; set; }
        public int Age { get; set; }
        public bool IsMan { get; set; }
    }

}