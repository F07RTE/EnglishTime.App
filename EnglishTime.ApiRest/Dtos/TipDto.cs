using System.Collections.Generic;

namespace EnglishTime.ApiRest.Dtos
{
    public class TipDto
    {
        public int Id { get; set; }
        public string Phrase { get; set; }
        public string Description { get; set; }
        public string Example { get; set; }

        public ErrorDto VerifyTipParameters()
        {
            var errorDto = new ErrorDto();
            errorDto.Messages = new List<string>();

            if (string.IsNullOrEmpty(this.Phrase))
                errorDto.Messages.Add("Phrase is a required parameter");

            if (string.IsNullOrEmpty(this.Description))
                errorDto.Messages.Add("Email is a required parameter");

            if (!isPhraseLengthValid())
                errorDto.Messages.Add("Phrase cannot exceed 300 characters");

            if (!isDescriptionLengthValid())
                errorDto.Messages.Add("Description cannot exceed 1000 characters");

            if (!isExampleLengthValid())
                errorDto.Messages.Add("Description cannot exceed 1000 characters");

            if (errorDto.Messages.Count > 0)
                errorDto.Error = true;

            return errorDto;
        }

        private bool isPhraseLengthValid()
        {
            if (this.Phrase.Length > 300)
                return false;
            return true;
        }

        private bool isDescriptionLengthValid()
        {
            if (this.Description.Length > 1000)
                return false;
            return true;
        }

        private bool isExampleLengthValid()
        {
            if (this.Example.Length > 1000)
                return false;
            return true;
        }
    }
}