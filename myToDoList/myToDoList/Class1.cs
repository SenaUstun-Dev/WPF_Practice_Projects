using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myToDoList
{
    public class Chore
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string DeadLine { get; set; }
        
        

    }
}
