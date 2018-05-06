using System;

namespace blogBl
{
    public class VoteLine
    {
        public Post post { get; set; }
        public DateTime timestamp { get; set; }
        public int quantity { get; set; }
        public int userId { get; set; }
        public bool upVote { get; set; }
        public string upVoteText
        {
            get
            {
                return this.upVote == true ? "up" : "down";
            }
        }
    }
}