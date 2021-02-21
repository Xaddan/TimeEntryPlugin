using System.Runtime.Serialization;

namespace TimeEntryPlugin
{
   [DataContract]
   public enum TimeEntryState
   {
      [EnumMember]
      Active = 0,

      [EnumMember]
      Inactive = 1,
   }
}