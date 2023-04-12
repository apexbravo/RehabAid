using RehabAid.Data.Models;
using RehabAid.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json;

namespace RehabAid.Data
{
    partial class TreatmentFacility
    {
        [NotMapped]
        public FacilityType Type
        {
            get => (FacilityType)TypeId;
            set => TypeId = (int)value;
        }

        List<Attachment> _attachments;
        [NotMapped]

        public List<Attachment> Attachments
        {
            get
            {
                if (_attachments == null)
                {
                    if (!string.IsNullOrWhiteSpace(AttachmentJson))
                        _attachments = JsonSerializer.Deserialize<List<Attachment>>(AttachmentJson, JsonHelper.SerializerOptions);
                    else _attachments = new List<Attachment>();
                }

                return _attachments;
            }
        }
    }
}

