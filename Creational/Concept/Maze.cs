using System.Collections.Generic;

namespace Creational.Concept
{
    public class Maze
    {
        //todo: use coordinates to make it more realistic!
        private readonly Dictionary<int, Room> _rooms = new Dictionary<int, Room>();
        public void AddRoom(Room room) => _rooms.Add(room.Number, room);
        public Room? GetRoom(int number) => _rooms.TryGetValue(number, out var room) ? room : null;
    }
}