using System;

namespace AmigaWorld.Entity
{
    public class Magazine
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public byte[] Document { get; set; }
    }
}