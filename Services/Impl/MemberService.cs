using System.Collections.Generic;
using perpusapi.DataModel;
using perpusapi.Repository;
using perpusapi.ParamFilter;

namespace perpusapi.Services.Impl 
{
    public class MemberService : IMemberService 
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void AddMember(Member member)
        {
            _memberRepository.AddMember(member);
        }

        public void DeleteMember(int id)
        {
            _memberRepository.DeleteMember(id);
        }

        public Member GetMember(int id)
        {
            return _memberRepository.GetMember(id);
        }

        public IEnumerable<Member> GetMembers(Filter filter)
        {
            return _memberRepository.GetMembers(filter);
        }

        public void UpdateMember(Member member)
        {
            _memberRepository.UpdateMember(member);
        }
    }
}