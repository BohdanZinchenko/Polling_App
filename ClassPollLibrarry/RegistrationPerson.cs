namespace PollManager
{
    public class RegistrationPerson : IPerson
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public bool IsGenderMan { get; set; }
    }
}