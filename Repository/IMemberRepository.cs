using System.Collections.Generic;
using perpusapi.DataModel;
using perpusapi.ParamFilter;

namespace perpusapi.Repository
{
    public interface IMemberRepository 
    {
        IEnumerable<Member> GetMembers(Filter filter);
        Member GetMember(int id);
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);
    }

}