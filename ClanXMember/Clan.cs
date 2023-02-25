namespace ClanXMember
{
    public class Clan
    {
        public int Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        private List<Member> Members { get; set; }

    }
}
