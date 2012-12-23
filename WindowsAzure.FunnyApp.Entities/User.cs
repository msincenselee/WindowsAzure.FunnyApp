namespace WindowsAzure.FunnyApp.Entities
{
    using System;

    public class User : EntityBase
    {
        public string UserName { get; set; }

        public Guid MemberShipId { get; set; }
    }
}