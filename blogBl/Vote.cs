using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogBl
{
    public class Voting
    {
        private List<VoteLine> lineCollection = new List<VoteLine>();
        public void upVote(Post post, int userId)
        {
            voting(post, userId, true);
        }
        public void downVote(Post post, int userId)
        {
            voting(post, userId,false);
        }

        private bool isFirstVoteByUser(Post post, int userId,bool upVote)
        {
            return ! lineCollection
            .Any(p => p.post.idPost == post.idPost && p.userId == userId && p.upVote == upVote);
        }


        private void voting(Post post, int userId, bool upVote)
        {
            if (isFirstVoteByUser(post, userId, upVote))
            {
                VoteLine line = lineCollection.Where(x => x.post == post && x.upVote == upVote)
                                .FirstOrDefault();

                if (line == null)
                {
                    lineCollection.Add(new VoteLine
                    {
                        post = post,
                        timestamp = DateTime.Now,
                        quantity = 1,
                        userId = userId,
                        upVote = upVote
                    });
                }
                else
                {
                    line.quantity += 1;
                }
            }
        }

        public IEnumerable<VoteLine> lines
        {
            get { return lineCollection; }
        }
    }
}
