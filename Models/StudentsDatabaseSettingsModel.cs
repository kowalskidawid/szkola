using System;
namespace Szkoła.Models
{
    public class StudentsDatabaseSettingsModel : SchoolSerivces
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface SchoolSerivces
    {
        string BooksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
