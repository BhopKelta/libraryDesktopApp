//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace library.UI.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int Id { get; set; }
        public string bookname { get; set; }
        public Nullable<System.DateTime> releasedate { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public Nullable<int> PublisherId { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}