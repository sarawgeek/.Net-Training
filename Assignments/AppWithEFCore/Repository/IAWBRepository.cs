using AppWithEFCore.Models;

namespace AppWithEFCore.Repository
{
    public interface IAWBRepository
    {
        int CreateAWB(AWB newAwb);
        int DeleteAWB(int newAwb);
        IEnumerable<AWB> GetAllAWBs();
        int UpdateAWB(AWB newAwb);
    }
}