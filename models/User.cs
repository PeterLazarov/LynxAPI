using System;

namespace Models
{
    public class User: BaseModel
    {
        public string username {get; set;}
        public string password {get; set;}
    }
}