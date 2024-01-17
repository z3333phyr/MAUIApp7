using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp7.Models
{
    public class StudentRepository
    {
        private readonly string _dbPath;
        private SQLiteConnection _conn;

        public string StatusMessage { get; set; }

        private void Init()
        {
            if (_conn != null)
                return;

            _conn = new SQLiteConnection(_dbPath);
            _conn.CreateTable<Student>();
        }

        public StudentRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewStudent(string name)
        {
            int result = 0;
            try
            {
                Init();

                //Basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = _conn.Insert(new Student { Name = name });

                StatusMessage = $"Record added (Name: {name})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to add {name}. Error: {ex.Message}";
            }
        }

        public List<Student> GetSection()
        {
            try
            {
                Init();
                return _conn.Table<Student>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data. {ex.Message}";
            }

            return new List<Student>();
        }
    }
}
