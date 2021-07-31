using System.ComponentModel;

namespace NoNonense.Application.Enums
{
    public enum UploadType : byte
    {
        [Description(@"Images\Notes")]
        Note,

        [Description(@"Images\ProfilePictures")]
        ProfilePicture,

        [Description(@"Documents")]
        Document
    }
}