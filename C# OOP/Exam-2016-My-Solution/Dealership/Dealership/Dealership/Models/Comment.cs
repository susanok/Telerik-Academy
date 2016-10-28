namespace Dealership.Models
{
    using Dealership.Contracts;
    using Dealership.Common;

    public class Comment : IComment
    {
        private const string ContentAsString = "Content";
        private const string ContentCanNotBeNull = "Content can not be null.";

        public string Author { get; set; }

        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            private set
            {
                int valueLength = value.Length;
                Validator.ValidateIntRange(valueLength, Constants.MinCommentLength, Constants.MaxCommentLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, Comment.ContentAsString,
                    Constants.MinCommentLength, Constants.MaxCommentLength));
                Validator.ValidateNull(value, Comment.ContentCanNotBeNull);

                this.content = value;
            }
        }
    }
}
