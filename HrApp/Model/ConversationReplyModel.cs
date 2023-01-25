using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Model
{
	public class ConversationReplyModel
	{
		public long ID { get; set; }
		public bool IsOwnerMessage { get; set; }
		public string FileName { get; set; }
		public byte[] FileContent { get; set; }
		public string FileContentAsString { get; set; }
		public bool notowner
	{
        get { return !IsOwnerMessage; }
      
    }


    public DateTime CreationDate { get; set; }
		public DateTime ModificationDate { get; set; }

		/// <summary>
		/// The sender user id.
		/// </summary>
		public long SenderUserId { get; set; }

		/// <summary>
		/// The conversation reply content
		/// </summary>
		public string Content { get; set; }

		public string SenderDisplayName { get; set; }





	public long ConversationID { get; set; }
		/// <summary>
		/// The  association of the conversation   
		/// </summary>
		//[ForeignKey("ConversationId")]
		public int IsReadByStuff { get; set; }
		public int IsReadByAgent { get; set; }


	}
}
