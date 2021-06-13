using CommandApi.Models;
using System.Collections.Generic;


namespace CommandApi.Data
{
    interface ICommandRepo
    {
        IEnumerable<Command> GetAllCommands();

        Command GetCommandById(int id);
    }
}
