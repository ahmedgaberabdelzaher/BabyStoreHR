using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Model
{
    public class ConversationModel
    {
        public long ID { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        /// <summary>
        /// The conversation replies.
        /// </summary>
        public ICollection<ConversationReplyModel> ConversationsReplies { get; set; }

        /// <summary>
        /// The first user id.
        /// </summary>
        public long UserOneID { get; set; }


        /// <summary>
        /// The second user id.
        /// </summary>
        public long UserTwoID { get; set; }

        public string user { get; set; }
        public string message { get; set; }
        public int conversationId { get; set; }


    }
}
