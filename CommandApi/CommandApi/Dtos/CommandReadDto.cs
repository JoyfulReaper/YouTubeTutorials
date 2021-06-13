using System;

namespace CommandApi.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

        // Demo removing a property from a Model
        //public string Platform { get; set; }
    }
}
