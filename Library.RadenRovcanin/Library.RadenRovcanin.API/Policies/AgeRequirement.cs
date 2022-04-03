using Microsoft.AspNetCore.Authorization;

namespace Library.RadenRovcanin.API.Policies
{
    public class AgeRequirement : IAuthorizationRequirement
    {
        public int Age { get; set; }
        public AgeRequirement(int age)
        {
            Age = age;
        }
    }
}
