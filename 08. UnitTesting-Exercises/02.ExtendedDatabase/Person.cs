namespace _01.Database
{
    public class Person
    {
        public Person(long id, string username)
        {
            this.Id = id;
            this.UserName = username;
        }

        public long Id { get; }

        public string UserName { get; }
    }
}