using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessLibrary.Model;
using System.Linq;


namespace BusinessLibrary
{
    public interface IPhoenixRepository
    {
        Task<List<Member>> GetAllMember();
        Task<bool> SaveMember(Member model);
    }
}

namespace BusinessLibrary
{
    public class MemberRepository : IPhoenixRepository
    {
        public async Task<List<Members>> GetAllMember()
        {
            using (phoenix2Context db = new phoenix2Context())
            {
                return await(from a in db.Members
                             select new Members
                             {
                                 MemberID = a.MemberId,
                                 Username = a.Username,
                                 UserPw = a.UserPw,
                                 First = a.First,
                                 Last = a.Last,
                                 Photo = a.Photo,
                                 Company = a.Company,
                                 Profession = a.Profession,
                                 Phone = a.Phone,
                                 Email = a.Email,
                                 Website = a.Website,

                             }).ToListAsync();
            }
        }

        public async Task<;bool> SaveMember(Member model)
        {
            using (MemberDBContext db = new MemberDBContext())
            {
                Members Member = db.Members.Where
                        (x => x.MemberId == model.MemberId).FirstOrDefault();
                if (Member == null)
                {
                    Member = new Members()
                    {
                        MemberID = model.MemberId,
                        Username = model.Username,
                        UserPw = model.UserPw,
                        First = model.First,
                        Last = model.Last,
                        Photo = model.Photo,
                        Company = model.Company,
                        Profession = model.Profession,
                        Phone = model.Phone,
                        Email = model.Email,
                        Website = model.Website,
                    };
                    db.Members.Add(Member);

                }
                else
                {
                    Member.First = model.First;
                    Member.Last = model.Last;
                    Member.Email = model.Email;
                    Member.Phone = model.Phone;
                }

                return await db.SaveChangesAsync() >= 1;
            }
        }

        public Task<List<Members>> GetAllMember()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveMember(Members model)
        {
            throw new NotImplementedException();
        }
    }
}