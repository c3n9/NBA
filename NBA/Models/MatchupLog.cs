//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NBA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MatchupLog
    {
        public int Id { get; set; }
        public int MatchupId { get; set; }
        public int Quarter { get; set; }
        public string OccurTime { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public int ActionTypeId { get; set; }
        public string Remark { get; set; }
    
        public virtual ActionType ActionType { get; set; }
        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }
    }
}
