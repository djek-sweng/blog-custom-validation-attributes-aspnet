using Validation.Attributes;

namespace WebApi.Dtos
{
    public class User
    {
        [LettersOnly]
        public string Name { get; set; }

        [OfLegalAge]
        public int Age { get; set; }
    }
}