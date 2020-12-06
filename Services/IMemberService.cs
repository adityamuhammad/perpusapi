using System.Collections.Generic;
using perpusapi.DataModel;

namespace perpusapi.Services {
    public interface IMemberService {
        IEnumerable<Member> GetMembers();
        Member GetMember(int id);
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);
    }
}