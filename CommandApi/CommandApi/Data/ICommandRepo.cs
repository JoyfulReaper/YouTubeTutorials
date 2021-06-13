using CommandApi.Models;
using System.Collections.Generic;


namespace CommandApi.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();

        Command GetCommandById(int id);

        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);
    }
}
