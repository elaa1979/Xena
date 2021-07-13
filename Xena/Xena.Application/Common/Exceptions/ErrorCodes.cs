namespace Xena.Application.Common.Exceptions
{
    public static class ErrorCodes
    {
        public static string EmailNotValid = "Email address is not valid";
        public static string EmailAlreadyExists = "Email address already exists";
        public static string PasswordsNotMatch = "Passwords don't match";
        public static string IncorrectCredentials = "Email or password is incorrect";
        public static string UserNotExists = "User don't exist";
        public static string FolderNotExists = "Folder with provided id not exists";
        public static string Forbidden = "You don't have access to this resource";
        public static string InvalidPhoneNumber = "Phone number is invalid";

        public static string VaultNotExists = "Vault don't exist";
        public static string VaultIsBlocked = "Vault is blocked, please try again later";
        public static string InvalidParameters = "Invalid Parameters";
        public static string VaultAlreadyExists = "Vault with this name already exists";
        public static string InvalidBase64 = "Invalid Base64 was provided";

        public static string FolderNotFound = "Folder not found";

        public static string AmazonProfileNotExists = "Amazon Profile don't exist";
        public static string AmazonKeywordNotExists = "Amazon Keyword don't exist";
        public static string AmazonAdGroupNotExists = "Amazon AdGroup don't exist";
        public static string AmazonCampaignNotExists = "Amazon Campaign don't exist";

        public static string CategoryNotExists = "Caregoy don't exist";
        public static string InternalServerError = "Something went wrong, please try again later";
        public static string FileNotUploaded = "File not uploaded";

        public static string VendorNotExists = "Vendor not found";
        public static string EventNotExists = "Event not found";
        public static string PostNotExists = "Post not found";
        public static string JobNotExists = "Job not found";
        public static string TicketNotExists = "Ticket not found";
        public static string TicketCommentNotExists = "Comment not found";
        public static string InvalidFilter = "Invalid filter";
        public static string QuoteNotExists = "Quote not found";
        public static string EmployeeNotExists = "Employee not found";
        public static string CustomerNotExists = "Customer not found";
        public static string CandidateNotExists = "Candidate not found";
        public static string PtoNotExists = "PTO not found";
        public static string TaskNotExists = "Task not found";
        public static string TaskCommentNotExists = "Task comment not found";
        public static string TaskFileNotExists = "Task File not found";
        public static string TaskGroupNotExists = "Task Group not found";
        public static string TaskSpaceNotExists = "Task Space not found";
        public static string CandidateJobNotExists = "Candidate Job not found";
        public static string TaskInChargeNotExists = "Task In Charge not found";
        public static string ForumNotExists = "Forum  not found";
        public static string ForumCommentNotExists = "Forum Comment not found";
        public static string PollNotExists = "Poll not found";
        public static string PollQuestionNotExists = "Poll Question not found";
        public static string FurnitureNotExists = "Furniture not found";
        public static string FurnitureFileNotExists = "Furniture File not found";
        public static string FurnitureNoteNotExists = "Furniture Note  found";
        public static string SaleNotExists = "Sale not found";
        public static string SaleNoteNotExists = "Sale Note not found";
        public static string ProjectNotExists = "Project not found";
        public static string ProjectNoteNotExists = "Project note not found";
        public static string ProjectFileNotExists = "Project file not found";

        public static string PhotoOftheDayNotExists = "Image not found";
        public static string QuoteOfTheDayNotExists = "Quote not found";
        public static string HolidaysNotExists = "Holidays not found";
        public static string WeatherReportNotExists = "Weather Report not found";
        public static string CalendarEventsNotExists = "Calendar events not found";

    }
}