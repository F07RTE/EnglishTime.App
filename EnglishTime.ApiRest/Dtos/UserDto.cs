using System.Collections.Generic;

namespace EnglishTime.ApiRest.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public ErrorDto VerifyUserParameters()
        {
            var errorDto = new ErrorDto();
            errorDto.Messages = new List<string>();

            if (string.IsNullOrEmpty(this.Name))
                errorDto.Messages.Add("Name is a required parameter");

            if (string.IsNullOrEmpty(this.Email))
                errorDto.Messages.Add("Email is a required parameter");

            if (string.IsNullOrEmpty(this.Password))
                errorDto.Messages.Add("Password is a required parameter");

            if (!isPasswordLengthValid())
                errorDto.Messages.Add("Password must have min 8 and max 25 characters");

            if (this.RoleId <= 0)
                errorDto.Messages.Add("RoleId is a required parameter");

            if (errorDto.Messages.Count > 0)
                errorDto.Error = true;

            return errorDto;
        }

        private bool isPasswordLengthValid()
        {
            if (this.Password.Length < 8 || this.Password.Length > 25)
                return false;
            return true;
        }
    }
}