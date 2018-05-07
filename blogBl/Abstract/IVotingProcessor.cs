using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogBl.Abstract
{
    public interface IVotingProcessor
    {
        void processVoting(Voting cart);
    }
}
