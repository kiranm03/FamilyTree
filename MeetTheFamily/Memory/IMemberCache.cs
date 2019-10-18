using MeetTheFamily.Model;

namespace MeetTheFamily.Memory
{
    public interface IMemberCache
    {
        void AddOrUpdateMember(Member member);
        Member Search(string name);
    }
}
