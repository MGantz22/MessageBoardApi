namespace MessageBoard.Models
{
    public class Post
    {
        public int PostId {get; set;}
        public DateTime date {get; set;} = DateTime.Now;
        public string MessageBody {get; set;}

        public int GroupId {get; set;}
        public Group Group {get; set;}
        //public string GroupName = _db.Groups.Find(GroupId).GroupName
        public User User {get; set;}
        public int UserId {get;set;}
    }
}
