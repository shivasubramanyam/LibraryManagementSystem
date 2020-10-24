namespace LibraryManagementSystem.Core.Constants
{
    public static class StoredProc
    {
        public const string GetUserByLoginCredential = "GetUserByValidatingCredential";
        public const string GetBookById = "GetBookById";
        public const string GetAllBooks = "GetAllBooks";
        public const string GetAllReviews = "GetAllReviews";

        public const string InsertBook = "AddNewBook";
        public const string InsertReview = "WriteReview";
        public const string UpdateBook = "UpdateBookDetails";
        public const string DeleteBook = "UpdateBookAsDeleted";
        public const string MarkBookAsReadByUser = "MarkBookAsReadByUser";
        public const string MarkBookAsUserFavorite = "MarkBookAsUserFavourite";
    }
}
