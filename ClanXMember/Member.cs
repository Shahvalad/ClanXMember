namespace ClanXMember
{
    public class Member
    {
        public int Id { get; private set; }
        public int Age { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        private Clan Clan { get; set; }
        public int ClanId { get; set; }
    }
}
