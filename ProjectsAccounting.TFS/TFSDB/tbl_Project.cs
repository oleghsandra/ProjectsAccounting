//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectsAccounting.TFS.TFSDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Project
    {
        public int PartitionId { get; set; }
        public int ProjectId { get; set; }
        public int DataspaceId { get; set; }
        public string ProjectUri { get; set; }
        public string ProjectName { get; set; }
        public int SequenceId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsResolutionStateCustomized { get; set; }
        public bool IsFailureTypeCustomized { get; set; }
        public int MigrationState { get; set; }
        public string MigrationError { get; set; }
    }
}
