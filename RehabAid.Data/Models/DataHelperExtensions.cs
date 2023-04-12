using RehabAid.Lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RehabAid.Data.Models
{
    public static class DataHelperExtensions
    {

        public static List<Attachment> GetAttachments(this IAttachmentContainer container)
        {
            if (container.AttachmentsJson == null) return new List<Attachment>();
            return JsonSerializer.Deserialize<List<Attachment>>(container.AttachmentsJson, JsonHelper.SerializerOptions);
        }

        public static void AddAttachment(this IAttachmentContainer container, Attachment attachment)
        {
            var attachments = container.GetAttachments();
            attachments.Add(attachment);
            container.AttachmentsJson = JsonSerializer.Serialize(attachments, JsonHelper.SerializerOptions);
        }
    }
}
