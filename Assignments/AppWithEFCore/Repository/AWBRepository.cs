using AppWithEFCore;
using AppWithEFCore.Models;

namespace AppWithEFCore.Repository
{
    public class AWBRepository : IAWBRepository
    {
        ApplicationDBContext _context;
        public AWBRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<AWB> GetAllAWBs()
        {
            return _context.AWBs.ToList();
        }

        public int CreateAWB(AWB newAwb)
        {
            _context.AWBs.Add(newAwb);
            _context.SaveChanges();
            return newAwb.AWBNumber;
        }

        public int UpdateAWB(AWB newAwb)
        {
            var existingAWB = _context.AWBs.FirstOrDefault(x => x.AWBNumber == newAwb.AWBNumber);
            if (existingAWB != null)
            {
                existingAWB.Status_Type = newAwb.Status_Type;
                existingAWB.Sender = newAwb.Sender;
                existingAWB.Reciever = newAwb.Reciever;
                _context.SaveChanges();
                return existingAWB.AWBNumber;
            }

            return -1;

        }

        public int DeleteAWB(int newAwb)
        {
            var existingAWB = _context.AWBs.FirstOrDefault(x => x.AWBNumber == newAwb);
            if (existingAWB != null)
            {
                _context.AWBs.Remove(existingAWB);
                _context.SaveChanges();
                return existingAWB.AWBNumber;
            }
            return -1;
        }
    }
}
